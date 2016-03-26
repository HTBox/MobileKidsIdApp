/// <reference path="../definitions/FileSystem.d.ts" />
/// <reference path="../definitions/angular.d.ts" />
/// <reference path="../services/serviceInterfaces.ts" />

declare let cordova: Cordova

module MCM {
    export class FileStorageService implements IStorageService {

        public static $inject = ["$q"];
        private $q: angular.IQService
        

        constructor($q: angular.IQService) {
            this.$q = $q;
        }

        public storeText(fileName: string, text: string): angular.IPromise<void> {
            return this.storeData([text], 'text/plain', fileName);
        }
        public storeData(data: any[], dataType: string, fileName: string): angular.IPromise<void> {
            let blob: Blob = blobUtil.createBlob(data, { type: dataType });
            return this.storeBlob(blob, fileName);
        }
        public storeBlob(blob: Blob, fileName: string): angular.IPromise<void> {

            let deferred: angular.IDeferred<void> = this.$q.defer<void>();
            window.resolveLocalFileSystemURL(cordova.file.dataDirectory, function (dir: DirectoryEntry) {

                dir.getFile(fileName, { create: true }, function (file) {

                    file.remove(() => {

                        dir.getFile(fileName, { create: true }, function (file) {
                            file.createWriter(function (fileWriter) {

                                fileWriter.seek(fileWriter.length);
                                fileWriter.write(blob);
                                deferred.resolve();
                                
                                //let safe = (cordova as any).plugins.disusered.safe, key = 'someKey';
                                //let stuff = safe.encrypt(dir.nativeURL + myFileName, key, success, error);

                            }, () => deferred.reject("Creating the writer failed."));
                        }, () => deferred.reject("Getting file failed."));

                    }, err => deferred.reject("File remove failed."));

                });


            }, err => deferred.reject(err));

            return deferred.promise;
        }


        public retrieveText(fileName: string): angular.IPromise<string> {
            let deferred = this.$q.defer<string>();
            //let success = () => {
            //    console.log("Decrypt using Safe succeeded.");
    
                window.resolveLocalFileSystemURL(cordova.file.dataDirectory, function (dir: DirectoryEntry) {

                    dir.getFile(fileName, { create: true }, fileEntry => {
                
                        fileEntry.file(file => {
                            let reader = new FileReader();

                            reader.onloadend = function(e) { //Can't use an arrow function because need access to correct 'this'.
                                deferred.resolve(this.result);
                            };

                            reader.readAsText(file);
                        }, err => deferred.reject("Creating the writer failed. Code: " + err.code) );

                    }, err => deferred.reject(err));
        
                }, err => deferred.reject(err) );
    

            //};
            //let error = function (theError) { console.log(theError); };
            //(cordova as any).plugins.disusered.safe.decrypt(dir.nativeURL + fileName, 'someKey', success, error);

            return deferred.promise;
        }
        retrieveFile(fileName: string): angular.IPromise<Blob> {
            let deferred = this.$q.defer<File>();
    
            window.resolveLocalFileSystemURL(cordova.file.dataDirectory, function (dir: DirectoryEntry) {

                dir.getFile(fileName, { create: true }, fileEntry => {

                    fileEntry.file(file => {
                        deferred.resolve(file);
                    }, err => deferred.reject("Getting file from fileEntry failed. Code: " + err.code));

                }, err => deferred.reject(err));

            }, err => deferred.reject(err));
    
            return deferred.promise;
        }
        
        deleteFile(fileName: string): angular.IPromise<void> {
            let deferred = this.$q.defer<void>();

            window.resolveLocalFileSystemURL(cordova.file.dataDirectory, function (dir: DirectoryEntry) {
                dir.getFile(fileName, { create: false }, fileEntry => {
                    fileEntry.remove(() => {
                        deferred.resolve();
                    });
                }, err => deferred.reject(err));
            }, err => deferred.reject(err));

            return deferred.promise;
        }


    }
}

angular.module('mcmapp').service('fileStorageService', MCM.FileStorageService);