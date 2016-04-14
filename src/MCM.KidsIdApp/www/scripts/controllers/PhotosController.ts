/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../Services/UserService.ts" />
/// <reference path="../Services/DocumentService.ts" />
/// <reference path="../Definitions/angular-ui-router.d.ts" />


module MCM {
    

    export class PhotosController {

        private $scope: any
        private $state: angular.ui.IStateService
        private $ionicPopup: ionic.popup.IonicPopupService
        private $q: angular.IQService
        private _childDataService: MCM.ChildDataService
        private _childId: string

        public static $inject = ['$scope', '$state', '$stateParams', '$ionicPopup', '$q', 'childDataService',
                'documentService'];

        constructor($scope: any, $state: angular.ui.IStateService, $stateParams: any,
                $ionicPopup: ionic.popup.IonicPopupService, $q: angular.IQService,
                childDataService: MCM.ChildDataService,
                private documentService: MCM.DocumentService) {
            this.$scope = $scope;
            
            this.$state = $state;
            this.$ionicPopup = $ionicPopup;
            this.$q = $q;
            let childId = $stateParams.childId;
            this._childId = childId;
            this._childDataService = childDataService;

            this.documentInfos = null;
            this.getStoredDocumentInfos().then(docInfos => this.documentInfos = docInfos);
        }

        public documentInfos: Array<DocumentInfo>;


        private getStoredDocumentInfos(): angular.IPromise<Array<DocumentInfo>> {
            return this.documentService.getDocumentInfos(this._childId);
        }

        public processSelectedFiles = (files: Array<File>) => {
            angular.forEach(files, (file, i) => {
                this.$ionicPopup.prompt({
                    title: 'File Description',
                    template: 'Enter file description',
                    inputPlaceholder: 'Your description'
                }).then(res => {
                    this.documentService.saveDocument(this._childId, file, res).then(() => {
                        this.getStoredDocumentInfos().then(docInfos => this.documentInfos = docInfos);
                    });
                });
                
            });
        };

        public removeDocument(docInfo: DocumentInfo) {
            this.documentService.removeDocument(this._childId, docInfo).then(() => {
                this.getStoredDocumentInfos().then(docInfos => {
                    this.documentInfos = docInfos
                });
            }, err => console.log("Error removing doc: " + err));
        }

    }
    
}

angular.module('mcmapp').controller('photosController', MCM.PhotosController);
