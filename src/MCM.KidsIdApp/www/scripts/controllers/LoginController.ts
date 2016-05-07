
/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../Definitions/AzureMobileServicesClient.d.ts" />
/// <reference path="../Services/UserService.ts" />

module MCM {
  export class LoginController {

    public static $inject = ['$scope', '$state', 'UserService'];
    public scope:any;
    public state:any;
    public userService:UserService;

    constructor($scope:ng.IScope, $state:any, userService:MCM.UserService) {
      this.scope = $scope;
      this.userService = userService;
      this.state = $state;
      
      
      console.log('args length', arguments.length);
      console.log('userService', userService);
      
      this.scope.signIn = this.signIn.bind(this);
    }

    public signIn (service) {
        const that = this;
        if (service == 'test') {
            that.state.go('landing');
        } else {
            var mobileService = new WindowsAzure.MobileServiceClient(
                "http://mobilekidsidapp.azurewebsites.net",
                null
            );
            mobileService.login(service).done(
                function success(user) {
                    that.userService.someMethod('foo')
                        .then(function (param) {
                            console.log('in .then with param=' + param);
                            that.state.go('landing');
                        });
                }, function error(error) {
                    console.error('Failed to login: ', error);
                });
        }
    }
  }
}

angular.module('mcmapp').controller('loginController', MCM.LoginController);