// Ionic Starter App

// angular.module is a global place for creating, registering and retrieving Angular modules
// 'starter' is the name of this angular module example (also set in a <body> attribute in index.html)
// the 2nd parameter is an array of 'requires'
var app = angular.module('mcmapp', ['ionic', 'ionic-datepicker'])
app.factory('storageService', function ($window, $injector) {
    //Could also have used a provider for this instead of a factory, but then we can't use the $injector
    // for instantiating the storage service implementation which is annoying.
    if ($window.tinyHippos || !window.cordova) {
        console.log("Detected Ripple emulator. Using InMemoryStorageService instead of FileStorageService.");
        return $injector.get('inMemoryStorageService');
    } else {
        return $injector.get('fileStorageService');
    }
});
//app.controller('landingController', function ($scope, $state) {
//  $scope.showinstructionindex = function () {
//    $state.go('instructionindex');
//  }
//  $scope.showchildprofilelist = function () {
//    $state.go('childprofilelist');
//  }
//  $scope.showabout = function () {
//    $state.go('about');
//  }
//  $scope.showsettings = function () {
//    $state.go('settings');
//  }
//});

//app.controller('forgotPasswordController', function ($scope, $state) {
//    // Setup scope for forgot password page
//});

//app.controller('childprofilelistController', function ($scope, $state) {
//  // Setup scope for child profile list page
//});

//app.controller('instructionindexController', function ($scope, $state) {
//  // Setup scope for instruction index page
//});

//app.controller('settingsController', function ($scope, $state) {
//  // Setup scope for settings page
//});

//app.controller('aboutController', function ($scope, $state) {
//  // Setup scope for about page
//});

app.config(function ($stateProvider, $urlRouterProvider) {

    // Ionic uses AngularUI Router which uses the concept of states
    // Learn more here: https://github.com/angular-ui/ui-router
    // Set up the various states which the app can be in.
    // Each state's controller can be found in controllers.js
    $stateProvider

    .state('login', {
        url: '/login',
        templateUrl: 'templates/login.html',
        controller: 'loginController'
    })

    .state('forgotPassword', {
        url: '/forgotpassword',
        templateUrl: 'templates/forgotpassword.html'
    })

    .state('landing', {
        url: '/landing',
        templateUrl: 'templates/landingpage.html'
    })

    .state('instructionIndex', {
      url: '/instructionindex',
      templateUrl: 'templates/instructionindex.html'
    })

    .state('childProfileList', {
      url: '/childprofilelist',
      templateUrl: 'templates/childprofilelist.html'
    })

    .state('childProfileItem', {
        url: '/childprofileitem/:childId',
      templateUrl: 'templates/childprofileitem.html'
    })

    .state('settings', {
      url: '/settings',
      templateUrl: 'templates/settingspage.html',
    })

    .state('about', {
      url: '/about',
      templateUrl: 'templates/aboutpage.html'
    })

    .state('basicDetails', {
        url: '/basicDetails/:childId',
        templateUrl: 'templates/basicdetails.html'
    })

    .state('photos', { 
        url: '/photos/:childId',
        templateUrl: 'templates/photos.html'
    })
    
    .state('idChecklist', {
        url: 'idchecklist/:childId',
        templateUrl: 'templates/idchecklist.html'
    })

    .state('physicalDetails', {
        url: '/physicalDetails/:childId',
        templateUrl: 'templates/physicaldetails.html'
    })

    // if none of the above states are matched, use this as the fallback
    $urlRouterProvider.otherwise('/login');

});

app.run(function($ionicPlatform) {
    $ionicPlatform.ready(function () {

        if (window.cordova && window.cordova.plugins && window.cordova.plugins.Keyboard) {
            if (window.tinyHippos) {
                //Ripple emulator shows an error on every screen you navigate to but setting the keyboard plugin to null seems to be a hack-ish way
                //to stop getting errors after the very first one.
                window.cordova.plugins.Keyboard = null;
            }
      // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
      // for form inputs)
        if (cordova.plugins.Keyboard.hideKeyboardAccessoryBar) {
            cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
        }

      // Don't remove this line unless you know what you are doing. It stops the viewport
      // from snapping when text inputs are focused. Ionic handles this internally for
      // a much nicer keyboard experience.
      cordova.plugins.Keyboard.disableScroll(true);
    }
    if(window.StatusBar) {
      StatusBar.styleDefault();
    }
  });
})
