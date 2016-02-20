/// <reference path="../Definitions/angular.d.ts" />

module MCM {
  export class StaticContentCtrl {

    public static $inject = ["$scope"];
    public scope:any;
    public id:string;

    constructor($scope:ng.IScope) {
      this.scope = $scope;
      this.id = this.scope.content+this.scope.title
    }
  }
}

angular.module('mcmapp').controller('StaticContentCtrl', MCM.StaticContentCtrl);
