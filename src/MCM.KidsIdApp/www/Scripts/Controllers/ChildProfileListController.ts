/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../models/models.ts" />
/// <reference path="IControllerNavigation.ts" />

class ChildProfileListController implements IControllerNavigation {
    private _state;
    private _scope;
    private _navigationLinks: Array<NavigationLink>;

    constructor($scope, $state) {
        this._state = $state;
        this._scope = $scope;

        this._navigationLinks =
            [
            ];
    }

    public static $inject = ["$scope", "$state"]

    public NavigateToHomeScreen() {
        this.NavigateTo('landing');
    }

    public NavigateToPreviousView() {
        this.NavigateTo('landing');
    }

    public NavigationLinks() {
        return this._navigationLinks;
    }

    public NavigateTo($controller: string) {
        this._state.go($controller);
    }
}

angular.module('mcmapp').controller('childProfileListController', ChildProfileListController);