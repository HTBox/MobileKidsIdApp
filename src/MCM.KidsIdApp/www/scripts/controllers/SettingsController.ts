/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../models/models.ts" />

class SettingsController {
    private _state;
    private _scope;

    constructor($scope, $state) {
        this._state = $state;
        this._scope = $scope;
        
    }

    public static $inject = ["$scope", "$state"]
    
}

angular.module('mcmapp').controller('settingsController', SettingsController);