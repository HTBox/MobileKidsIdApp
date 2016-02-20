module MCM{
  export class StaticPageCtrl{
    public static $inject="$scope";

    constructor($scope){

    }
  }

  export function StaticPageDir():any{
    return {
      scope: {'pageReference': '=ref'},
      restrict: "E",
      link: (scope, ele, attrs, controllers, transcludeFn)=> {

      },
      template: "<div>This Is A Test</div>"
    }
  }
}
