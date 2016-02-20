module MCM{
  export class StaticPageCtrl{
    public static $inject="$scope";

    public scope:any;

    constructor($scope){
      this.scope = $scope;
      console.log("CONTROLLER MO FO", this.scope.pageReference)
    }
  }

  export function StaticPageDir():any{
    return {
      scope: {'pageReference': '@ref'},
      restrict: "E",
      link: (scope, ele, attrs, controllers, transcludeFn)=> {

      },
      template: "<div>This Is A Test</div>",
      controller:StaticPageCtrl
    }
  }
}
