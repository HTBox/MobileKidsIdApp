/// <reference path="../definitions/angular.d.ts" />

declare module MCM {

    interface IStorageService {

        storeText(text: string): angular.IPromise<void>
        storeBlob(blob: Blob, fileName: string): angular.IPromise<void>
        retrieveText(): angular.IPromise<string>
        retrieveFile(fileName: string): angular.IPromise<Blob>
        deleteFile(fileName: string): angular.IPromise<void>
    }

    interface DocumentInfo {
        documentMetadata: DocumentMetadata;
        thumbnailDataURL: string
    }
    
}