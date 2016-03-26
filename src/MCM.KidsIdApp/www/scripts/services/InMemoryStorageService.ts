/// <reference path="../definitions/FileSystem.d.ts" />
/// <reference path="../definitions/angular.d.ts" />
/// <reference path="../services/serviceInterfaces.ts" />

module MCM {
    export class InMemoryStorageService implements IStorageService {

        public static $inject = ["$q"];
        private $q: angular.IQService
        private inMemoryText: string

        constructor($q: angular.IQService) {
            this.$q = $q;
            this.inMemoryText = null;
        }

        storeText(text: string): angular.IPromise<void> {
            this.inMemoryText = text;
            return this.$q.resolve();
        }
        
        retrieveText(): angular.IPromise<string> {
            return this.$q.resolve(this.inMemoryText);
        }

        private filesDictionary: { [fileName: string]: Blob; } = {};
        public storeFile(file: File, fileName: string): angular.IPromise<void> {
            this.filesDictionary[fileName] = file;
            return this.$q.resolve();
        }
        public storeBlob(blob: Blob, fileName: string): angular.IPromise<void> {
            this.filesDictionary[fileName] = blob;
            return this.$q.resolve();
        }

        retrieveFile(fileName: string): angular.IPromise<Blob> {
            let deferred = this.$q.defer<Blob>();
            let file = this.filesDictionary[fileName];
            if (file) {
                deferred.resolve(file);
            }
            else {
                deferred.reject("Couldn't find file with name " + fileName);
            }
            return deferred.promise;
        }

        deleteFile(fileName: string): angular.IPromise<void> {
            delete this.filesDictionary[fileName];
            return this.$q.resolve();
        }
    }
}

angular.module('mcmapp').service('inMemoryStorageService', MCM.InMemoryStorageService);