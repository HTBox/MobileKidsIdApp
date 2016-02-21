/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../models/models.ts"/>

class LandingController implements IControllerNavigation {
    private _state;
    private _scope: Data;
    private _navigationLinks: Array<NavigationLink>;

    constructor($scope, $state) {
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

angular.module('mcmapp').controller('landingController', LandingController);