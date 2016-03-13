/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../Definitions/ionic/ionic.d.ts" />
/// <reference path="../models/models.ts" />
/// <reference path="IControllerNavigation.ts" />
/// <reference path="../services/ChildDataService.ts" />

class ChildProfileListController implements IControllerNavigation {
    private _state;
    private _scope: angular.IScope;
    private _ionicPopup: ionic.popup.IonicPopupService;
    private _childDataService: MCM.ChildDataService;
    private _navigationLinks: Array<NavigationLink>;

    constructor($scope: angular.IScope, $state, $ionicPopup: ionic.popup.IonicPopupService,
                childDataService: MCM.ChildDataService) {
        this._state = $state;
        this._scope = $scope;
        this._ionicPopup = $ionicPopup;
        this._childDataService = childDataService;
        this.reloadChildList();

        this._navigationLinks =
            [
            ];
    }

    public newChildName: string
    public children: Array<Child>

    public static $inject = ["$scope", "$state", "$ionicPopup", "childDataService"]

    public NavigateToHomeScreen() {
        this.NavigateTo('landing');
    }

    public NavigateToPreviousView() {
        this.NavigateTo('landing');
    }

    public NavigationLinks() {
        return this._navigationLinks;
    }

    public NavigateTo(pStateName: string) {
        this._state.go(pStateName);
    }

    private reloadChildList(): angular.IPromise<void> {
        return this._childDataService.getAllChildren().then(children => {
            this.children = children;
        }, err => {
            console.log(err);
        });
    }

    public addNewChild(childName: string) {
        let newChild: Child = { id: this._childDataService.generateUUID(), givenName: childName, familyName: "" };
        this.newChildName = "";
        this._childDataService.add(newChild)
            .then(() => this.reloadChildList());
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
}

angular.module('mcmapp').controller('childProfileListController', ChildProfileListController);