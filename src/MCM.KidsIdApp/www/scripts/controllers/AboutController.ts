/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../models/models.ts" />

class AboutController {
    private _state;
    private _scope;

    constructor($scope, $state) {
        this._state = $state;
        this._scope = $scope;
        
    }

    public static $inject = ["$scope", "$state"]
    
    public NavigateTo(pStateName: string) {
        this._state.go(pStateName);
    }
}

angular.module('mcmapp').controller('aboutController', AboutController);