/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../Definitions/ionic/ionic.d.ts" />
/// <reference path="../models/models.ts" />
/// <reference path="../services/ChildDataService.ts" />
/// <reference path="../Definitions/angular-ui-router.d.ts" />

class ChildProfileListController {
    private _state: angular.ui.IStateService;
    private _scope: angular.IScope;
    private _ionicPopup: ionic.popup.IonicPopupService;
    private _childDataService: MCM.ChildDataService;

    constructor($scope: angular.IScope, $state, $ionicPopup: ionic.popup.IonicPopupService,
                childDataService: MCM.ChildDataService) {
        this._state = $state;
        this._scope = $scope;
        this._ionicPopup = $ionicPopup;
        this._childDataService = childDataService;
        this.reloadChildList();
        
    }

    public newChildName: string
    public children: Array<Child>

    public static $inject = ["$scope", "$state", "$ionicPopup", "childDataService"]
    

    public editChild(child: Child) {
        this._state.go("childProfileItem", { childId: child.id });
    }

    private reloadChildList(): angular.IPromise<void> {
        return this._childDataService.getAllChildren().then(children => {
            this.children = children;
        }, err => {
            console.log(err);
        });
    }

    public addNewChild(childName: string) {
        //Basic details page will treat child as a newly added child if id doesn't already exist.
        this.editChildById(this._childDataService.generateUUID());
    }
    
    public removeChild(child: Child) {
        this._ionicPopup.confirm({
            title: 'Confirm Remove',
            template: 'Are you sure you want to remove the child?'
        }).then(answer => {
            if (answer) {
                this._childDataService.delete(child)
                    .then(() => this.reloadChildList());
            }
        });
    }
    
    private editChildById(childId: string) {
        this._state.go("basicDetails", { childId: childId });
    }
}

angular.module('mcmapp').controller('childProfileListController', ChildProfileListController);