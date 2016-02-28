/// <reference path="../www/scripts/definitions/jasmine.d.ts" />
/// <reference path="../www/scripts/definitions/angular.d.ts" />
/// <reference path="../www/scripts/definitions/angular-mocks.d.ts" />

describe("Angular Example", function () {
    beforeEach(() => { angular.mock.module('ui.router'); });
    beforeEach(() => { angular.mock.module('mcmapp'); });

    var $controller: angular.IControllerService;
    var $rootScope: angular.IRootScopeService;
    
  // Store references so they are available to all tests in this describe block
    beforeEach(angular.mock.inject(function (_$controller_, _$rootScope_) {
        // The injector unwraps the underscores (_) from around the parameter names when matching
        $controller = _$controller_;
        $rootScope = _$rootScope_;
    }));

    it('should create controller', inject(function ($state) {
        var scope = $rootScope.$new(),
            ctrl = $controller('aboutController', { $scope: scope, $state: $state });
        expect(ctrl).not.toBe(null);
    }));
    
});
