/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../Definitions/angular-ui-router.d.ts" />
/// <reference path="../Services/UserService.ts" />
/// <reference path="../Services/DocumentService.ts" />

module MCM {
    export class IdChecklistController {
        private _state: any;
        private _childId: string;
        public checkList: PreparationChecklist;
        
        public static $inject = ['$state', '$stateParams','childDataService'];

        constructor($state: any, $stateParams: any, private _childDataService: MCM.ChildDataService) {
            this._state = $state;
            if($stateParams.childId) {
                this._childId = $stateParams.childId;
                this._childDataService.getById(this._childId).then((child) => {
                    if(child.checklist) {
                        this.checkList = child.checklist;
                    } else {
                        this.checkList = {
                            childPhoto: false,
                            birthCertificate: false,
                            socialSecurityCard: false,
                            physicalDetails: false,
                            distinguishingFeatures: false,
                            friends: false,
                            dna: false,
                            mementos: false,
                            divorceCustodyPapers: false,
                            otherParentsAndFamily: false,
                        }
                    }
                });
            }
        }
        
        public NavigateToDocuments() {
            this._state.go("documents", {childId: this._childId});
        }
        
        public SaveCheckList() {
            this._childDataService.getById(this._childId).then((child) => {
                child.checklist = this.checkList;
                this._childDataService.update(child);
            });
        }
        
    }
}

angular.module("mcmapp").controller("idChecklistController", MCM.IdChecklistController);