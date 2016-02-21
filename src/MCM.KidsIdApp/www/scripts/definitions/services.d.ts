/// <reference path="../definitions/angular.d.ts" />

declare module MCM {

    interface IFileService {

        saveTextToFile(text: string): angular.IPromise<void>
        getFileText(): angular.IPromise<string>
    }


}