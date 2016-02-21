/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../models/models.ts" />

class AboutController implements IControllerNavigation {
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

    public NavigateTo(pStateName: string) {
        this._state.go(pStateName);
    }
}

angular.module('mcmapp').controller('aboutController', AboutController);