/// <reference path="../Definitions/angular.d.ts" />

module MCM {
  export class StaticPageCtrl {

    public static $inject = ["$scope"];
    public scope:any;

    constructor($scope) {
      this.scope = $scope;
    }
  }
}

angular.module('mcmapp').controller('StaticPageCtrl', MCM.StaticPageCtrl);
