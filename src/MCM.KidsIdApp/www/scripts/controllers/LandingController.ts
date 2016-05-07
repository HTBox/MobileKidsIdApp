/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../models/models.ts" />
/// <reference path="NavigationLink.ts" />

class LandingController {
    private _state;
    private _scope;
    private _navigationLinks: Array<MCM.NavigationLink>;

    constructor($scope, $state) {
        this._state = $state;
        this._scope = $scope;

        this._navigationLinks = [
            new MCM.NavigationLink("instructionIndex", "Instructions"),
            new MCM.NavigationLink("childProfileList", "Child Profiles"),
            new MCM.NavigationLink("about", "About"),
            new MCM.NavigationLink("settings", "Settings")
        ];
    }

    public static $inject = ["$scope", "$state"]

    public NavigationLinks() {
        return this._navigationLinks;
    }

    public NavigateTo(pStateName: string) {
        this._state.go(pStateName);
    }
}

angular.module('mcmapp').controller('landingController', LandingController);