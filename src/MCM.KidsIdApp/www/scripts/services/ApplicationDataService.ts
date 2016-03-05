/// <reference path="../models/models.ts" />
/// <reference path="serviceInterfaces.ts" />

module MCM {

    /**
     * Provides access to the root application data. Should not be used directly by controllers. Should
     * only be used by other services like the ChildDataService.
     */
    export class ApplicationDataService {

        private applicationDataPromise: angular.IPromise<ApplicationData>

        constructor(private storageService: IStorageService) {
        }

        public static $inject = ["storageService"]

        getApplicationData(): ng.IPromise<ApplicationData> {
            if (!this.applicationDataPromise) {
                this.applicationDataPromise = this.storageService.retrieveText()
                    .then(fileText => {
                        return fileText ? JSON.parse(fileText) : this.getDefaultApplicationData();
                    }, err => console.log(err));
            }
            return this.applicationDataPromise;
        }

        saveApplicationData(): ng.IPromise<void> {
            return this.applicationDataPromise.then(applicationData => {
                let saveText = JSON.stringify(applicationData);
                return this.storageService.storeText(saveText);
            });
        }

        getDefaultApplicationData(): ApplicationData {
            return <ApplicationData>{ Family: <Family>{children: []}};
        }

    }
}

angular.module('mcmapp').service('applicationDataService', MCM.ApplicationDataService);