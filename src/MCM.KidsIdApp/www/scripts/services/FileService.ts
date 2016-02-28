/// <reference path="../definitions/FileSystem.d.ts" />
/// <reference path="../definitions/angular.d.ts" />
/// <reference path="../definitions/services.d.ts" />

declare let cordova: Cordova

let storageFileName = "mcmKidsIdApp.txt";

module MCM {
    export class FileService implements IFileService {

        public static $inject = ["$q"];
        private $q: angular.IQService

        constructor($q: angular.IQService) {
            this.$q = $q;
        }

        saveTextToFile(text: string): angular.IPromise<void> {
            var deferred: angular.IDeferred<void> = this.$q.defer<void>();

            window.resolveLocalFileSystemURL(cordova.file.dataDirectory, function (dir: DirectoryEntry) {
                
                dir.getFile(storageFileName, { create: true }, function (file) {

                    file.remove(() => {

                        dir.getFile(storageFileName, { create: true }, function (file) {
                            file.createWriter(function (fileWriter) {

                                fileWriter.seek(fileWriter.length);

                                let blob = new Blob([text], { type: 'text/plain' });
                                fileWriter.write(blob);
                                deferred.resolve();
                                
                                //let safe = (cordova as any).plugins.disusered.safe, key = 'someKey';
                                //let stuff = safe.encrypt(dir.nativeURL + myFileName, key, success, error);

                            }, () => deferred.reject("Creating the writer failed."));
                        }, () => deferred.reject("Getting file failed."));

                    }, err => deferred.reject("File remove failed."));

                });


            });

            return deferred.promise;
        }


        getFileText(): angular.IPromise<string> {
            var deferred = this.$q.defer<string>();

            //let success = () => {
            //    console.log("Decrypt using Safe succeeded.");
    
                window.resolveLocalFileSystemURL(cordova.file.dataDirectory, function (dir: DirectoryEntry) {

                    dir.getFile(storageFileName, { create: false }, fileEntry => {
                
                        fileEntry.file(file => {
                            let reader = new FileReader();

                            reader.onloadend = e => {
                                deferred.resolve(this.result);
                            };

                            reader.readAsText(file);
                        }, err => deferred.reject("Creating the writer failed. Code: " + err.code) );

                    }, err => deferred.reject("Getting the file failed. Code: " + err.code));
        
                }, err => deferred.reject(err) );
    

            //};
            //let error = function (theError) { console.log(theError); };
            //(cordova as any).plugins.disusered.safe.decrypt(dir.nativeURL + fileName, 'someKey', success, error);

            return deferred.promise;
        }
    }
}

angular.module('mcmapp').service('fileService', MCM.FileService);