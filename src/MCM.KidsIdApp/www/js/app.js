///<reference path="../ts/ui/StaticPage.ts"/>

// Ionic Starter App

// angular.module is a global place for creating, registering and retrieving Angular modules
// 'starter' is the name of this angular module example (also set in a <body> attribute in index.html)
// the 2nd parameter is an array of 'requires'
var app = angular.module('mcmapp', ['ionic'])
app.controller('loginController', function ($scope, $state) {
    $scope.signIn = function (username, password) {
        // Do some login logic here.
        $state.go('landing');
    }
});

app.controller('landingController', function ($scope, $state) {
    // Setup scope for landing page
});

app.controller('forgotPasswordController', function ($scope, $state) {
    // Setup scope for landing page
});

app.controller('staticPage', MCM.StaticPageCtrl)
app.directive('staticPage', MCM.StaticPageDir)

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
        templateUrl: 'templates/forgotpassword.html',
        controller: 'forgotPasswordController'
    })

    .state('landing', {
        url: '/landing',
        templateUrl: 'templates/landingpage.html',
        controller: 'landingController'
    })

    // if none of the above states are matched, use this as the fallback
    $urlRouterProvider.otherwise('/login');

});

app.run(function($ionicPlatform) {
  $ionicPlatform.ready(function() {
    if(window.cordova && window.cordova.plugins.Keyboard) {
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
