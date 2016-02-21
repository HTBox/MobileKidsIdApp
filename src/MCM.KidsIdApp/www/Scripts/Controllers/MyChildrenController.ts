/// <reference path="../Definitions/angular.d.ts" />

class MyChildrenController implements IControllerNavigation {
    private _state;
    private _scope: Data;
    private _navigationLinks: Array<NavigationLink>;

    constructor($scope, $state) {
        this._state = $state;
        this._scope = $scope;

        this._navigationLinks =
            [
                new NavigationLink("addChildController","Add a Child")
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

angular.module('mcmapp').controller('myChildrenController', MyChildrenController);