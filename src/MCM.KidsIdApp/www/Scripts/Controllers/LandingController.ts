/// <reference path="../Definitions/angular.d.ts" />

class LandingController implements IControllerNavigation {
    private _state;
    private _scope: Data;
    private _navigationLinks: Array<NavigationLink>;

    constructor($scope: Data, $state) {
        this._state = $state;
        this._scope = $scope;

        this._navigationLinks = [
            new NavigationLink("myChildren", "My Children"),
            new NavigationLink("instructionIndex", "Instructions"),
            new NavigationLink("profiles", "Profiles"),
            new NavigationLink("about", "About"),
            new NavigationLink("settings", "Settings")
        ];
    }

    public static $inject = ["$scope", "$state"]

    public NavigateToHomeScreen() {
        this._state.go('landing');
    }

    public NavigateToPreviousView() {
        this._state.go('landing');
    }

    public NavigationLinks() {
        return this._navigationLinks;
    }
}

angular.module('mcmapp').controller('landingController', LandingController);