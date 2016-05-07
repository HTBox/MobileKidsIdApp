/// <reference path="../../www/scripts/definitions/jasmine.d.ts" />
/// <reference path="../../www/scripts/definitions/angular.d.ts" />
/// <reference path="../../www/scripts/definitions/angular-mocks.d.ts" />
/// <reference path="../../www/scripts/services/applicationDataService.ts" />


describe("ApplicationDataService", function () {
    beforeEach(() => { angular.mock.module('mcmapp'); });
    
    var _applicationDataSvc: MCM.ApplicationDataService;
    var $rootScope: angular.IRootScopeService;
    
  // Store references so they are available to all tests in this describe block
    beforeEach(angular.mock.inject(function (_$rootScope_: angular.IRootScopeService,
                applicationDataService: MCM.ApplicationDataService) {
        // The injector unwraps the underscores (_) from around the parameter names when matching
        _applicationDataSvc = applicationDataService;
        $rootScope = _$rootScope_;
    }));

    it('should return application data', done => {
        angular.mock.inject(function ($state) {
            _applicationDataSvc.getApplicationData().then(appdata => {
                expect(appdata).not.toBe(null);
                done();
            });
            $rootScope.$digest(); //Need to call this in order for $q promises to process.
        });
    });

    it('should retain changes to application data after store/retrieve', done => {
        angular.mock.inject(function ($state) {
            const acknowledged = true;
            _applicationDataSvc.getApplicationData().then(appdata => {
                appdata.userApplicationProfile.legalAcknowlegeDataSecurityPolicy = acknowledged;
                return _applicationDataSvc.saveApplicationData();
            }).then(() => _applicationDataSvc.getApplicationData()).then(appdata => {
                expect(appdata.userApplicationProfile.legalAcknowlegeDataSecurityPolicy).toBe(acknowledged);
                done();
            });
            $rootScope.$digest();
        });
    });

});
