/// <reference path="../Controllers/StaticContentCtrl.ts" />

module MCM{
  export function StaticContentDir():any{
    return {
      scope: {
        'staticContent': '@content',
        'title': '@title'
      },
      restrict: "E",
      link: (scope, ele, attrs, controllers, transcludeFn)=> {

      },
      templateUrl: 'templates/static-content.html',
      //controller:MCM.StaticContentCtrl
    }
  }
}

angular.module('mcmapp').directive('staticContent', MCM.StaticContentDir);
