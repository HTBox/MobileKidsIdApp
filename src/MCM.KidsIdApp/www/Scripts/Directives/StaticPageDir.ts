/// <reference path="../Controllers/StaticPageCtrl.ts" />

module MCM{
  export function StaticPageDir():any{
    return {
      scope: {'staticContent': '=ref'},
      restrict: "E",
      link: (scope, ele, attrs, controllers, transcludeFn)=> {

      },
      templateUrl: 'templates/static-content.html',
      controller:MCM.StaticPageCtrl
    }
  }
}

angular.module('mcmapp').directive('staticPage', MCM.StaticPageDir);
