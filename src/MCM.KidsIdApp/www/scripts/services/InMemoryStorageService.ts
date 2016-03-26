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
    }
}

angular.module('mcmapp').service('inMemoryStorageService', MCM.InMemoryStorageService);