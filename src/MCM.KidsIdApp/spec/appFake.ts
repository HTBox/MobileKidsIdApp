//This is a minimal app initialization for testing. It excludes the route configuration because otherwise
// you seem to get errors if you call scope.$digest in a test.

var app = angular.module('mcmapp', ['ionic'])
app.factory('storageService', function ($window, $injector) {
    return $injector.get('inMemoryStorageService');
});