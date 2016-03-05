/// <reference path="../definitions/angular.d.ts" />

declare module MCM {

    interface IStorageService {

        storeText(text: string): angular.IPromise<void>
        retrieveText(): angular.IPromise<string>
    }
    
}