/// <reference path="../definitions/angular.d.ts" />
/// <reference path="../Services/ChildDataService.ts" />

declare var blobUtil: any;

module MCM {
    export class DocumentService {

        public static $inject = ["$q", 'storageService', 'childDataService'];

        constructor(private $q: angular.IQService, private storageService: MCM.IStorageService,
            private childDataService: MCM.ChildDataService) {
        }

        
        public getDocumentInfos(childId: string): angular.IPromise<Array<DocumentInfo>> {
            let photosPromise = this.childDataService.getById(childId).then(child => child.photos);
            let promises = photosPromise.then(docMetadatas => (docMetadatas || []).map(docMetaData => {
                let thumbnailDataURLpromise: angular.IPromise<string>;
                if (docMetaData.thumbnailFileName) {
                    thumbnailDataURLpromise = this.storageService.retrieveFile(docMetaData.thumbnailFileName)
                            .then(thumbnailFile => this.getDataURLfromBlob(thumbnailFile));
                }
                else {
                    thumbnailDataURLpromise = this.$q.resolve(null);
                }
                return thumbnailDataURLpromise.then(thumbnailDataURL => {
                    return <DocumentInfo>{ FileReference: docMetaData, thumbnailDataURL: thumbnailDataURL};
                });
            }));
            return promises.then(docInfoPromises => this.$q.all(docInfoPromises));
        }

        public removeDocument(childId: string, docInfo: DocumentInfo): angular.IPromise<void> {
            let deleteFilePromise = this.storageService.deleteFile(docInfo.FileReference.fileName);
            let deleteThumbnailPromise = docInfo.FileReference.thumbnailFileName ?
                    this.storageService.deleteFile(docInfo.FileReference.thumbnailFileName) : null;
            let removeDocMetadataPromise = this.childDataService.getById(childId).then(child => {
                let docIndex: number;
                for (var i = 0; i <= child.photos.length - 1; i++) {
                    if (child.photos[i].fileName === docInfo.FileReference.fileName) {
                        docIndex = i;
                        break;
                    }
                }
                child.photos.splice(docIndex, 1);
            });
            return this.$q.all([deleteFilePromise, deleteThumbnailPromise, removeDocMetadataPromise]) as any;
        }

        /**
         * From http://stackoverflow.com/a/8809472
         */
        private generateUUID() {
            var d = new Date().getTime();
            if (window.performance && typeof window.performance.now === "function") {
                d += performance.now(); //use high-precision timer if available
            }
            var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
                var r = (d + Math.random() * 16) % 16 | 0;
                d = Math.floor(d / 16);
                return (c == 'x' ? r : (r & 0x3 | 0x8)).toString(16);
            });
            return uuid;
        }

        public saveDocument(childId: string, documentBlob: Blob, description: string): angular.IPromise<void> {

            const fileName = this.generateUUID();
            const thumbFileName = fileName + "thumb";
            const imageTypeRegex = /^image\//;
            let saveThumbnailPromise: angular.IPromise<void> = null;
            let mythumbnailDataURL: string = null;
            if (true || imageTypeRegex.test(documentBlob.type)) {
                saveThumbnailPromise = this.getDataURLfromBlob(documentBlob).then(dataURL => {
                    //On android 4.3 device the mime type is missing from image files for some reason.
                    dataURL = dataURL.replace("data:base64", "data:image/png;base64");
                    return this.getThumbnailDataURL(dataURL, 100).then(thumbnailDataURL => {
                        mythumbnailDataURL = thumbnailDataURL;
                        return blobUtil.dataURLToBlob(thumbnailDataURL).then(blob => {
                            return this.storageService.storeBlob(blob, thumbFileName);
                        });
                    });
                });
            }

            const saveOriginalPromise = this.storageService.storeBlob(documentBlob, fileName);
            let theChild: Child;
            const getChildPromise = this.childDataService.getById(childId).then(child => theChild = child);
            return this.$q.all([saveThumbnailPromise, saveOriginalPromise, getChildPromise]).then(() => {
                const docMetadata = <FileReference>{
                    description: description, fileName: fileName,
                    thumbnailFileName: thumbFileName
                };
                const docInfo = <DocumentInfo>{
                    FileReference: docMetadata,
                    thumbnailDataURL: mythumbnailDataURL
                };
                if (!theChild.photos)
                    theChild.photos = [];
                theChild.photos.push(docMetadata);
                return this.childDataService.update(theChild) as any;
            });
        }


        private getDataURLfromBlob(blob: Blob): angular.IPromise<string> {
            let deferred = this.$q.defer<string>();
            var fileReader = new FileReader();
            fileReader.onload = event => {
                var uri = (event.target as any).result;
                //On actual android 4.3 device the mime type comes back as null for some reason which
                //causes thumbnail not to display.
                uri = uri.replace("data:null;", "data:image/png;");
                deferred.resolve(uri);
            };
            fileReader.readAsDataURL(blob);
            return deferred.promise;
        }


        private getThumbnailDataURL(fullSizeDataURL: string, size: number): angular.IPromise<string> {
            let deferred = this.$q.defer<string>();
            var canvasEl = document.createElement('canvas');
            document.documentElement.appendChild(canvasEl);
            var img = new Image();
            img.src = fullSizeDataURL;
            img.onload = () => {
                canvasEl.id = "myTempCanvas";
                const scale = size / img.width;
                canvasEl.width = size;
                canvasEl.height = img.height * scale;
                if (canvasEl.getContext) {
                    var cntxt = canvasEl.getContext("2d");
                    cntxt.drawImage(img, 0, 0, canvasEl.width, canvasEl.height);
                    var dataURL = canvasEl.toDataURL("image/png");

                    if (dataURL != null && dataURL != undefined) {
                        deferred.resolve(dataURL);
                    }
                    else {
                        deferred.reject('canvas.toDataURL failed.');
                    }
                }
            }
            return deferred.promise;
        }
        //private dataURItoBlob(dataURI: string): Blob {
        //    // convert base64 to raw binary data held in a string
        //    // doesn't handle URLEncoded DataURIs
        //    var byteString = atob(dataURI.split(',')[1]);

        //    // separate out the mime component
        //    var mimeString = dataURI.split(',')[0].split(':')[1].split(';')[0];
        //    console.log("Mimestring in dataURItoBlob: " + mimeString);

        //    // write the bytes of the string to an ArrayBuffer
        //    var ab = new ArrayBuffer(byteString.length);
        //    var ia = new Uint8Array(ab);
        //    for (var i = 0; i < byteString.length; i++) {
        //        ia[i] = byteString.charCodeAt(i);
        //    }
            
        //    return this.createBlob([ab], mimeString );
        //};
        //private createBlob(data: any[], dataType: string): Blob {
        //    let theBlob: Blob;
        //    try {
        //        theBlob = new Blob(data, { type: dataType });
        //    }
        //    catch (e) {
        //        let wndw: any = window;
        //        let builder = wndw.BlobBuilder || wndw.WebKitBlobBuilder || wndw.MozBlobBuilder || wndw.MSBlobBuilder;
        //        if (e.name == 'TypeError' && builder) {
        //            var bb = new builder();
        //            bb.append(data);
        //            theBlob = bb.getBlob(dataType);
        //        }
        //        else {
        //            throw "Unable to create blob.";
        //        }
        //    }
        //    return theBlob;
        //}

    }
}

angular.module('mcmapp').service('documentService', MCM.DocumentService);