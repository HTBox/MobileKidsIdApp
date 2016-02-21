/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../models/models.ts" />
var AboutController = (function () {
    function AboutController($scope, $state) {
        this._state = $state;
        this._scope = $scope;
        this._navigationLinks =
            [];
    }
    AboutController.prototype.NavigateToHomeScreen = function () {
        this.NavigateTo('landing');
    };
    AboutController.prototype.NavigateToPreviousView = function () {
        this.NavigateTo('landing');
    };
    AboutController.prototype.NavigationLinks = function () {
        return this._navigationLinks;
    };
    AboutController.prototype.NavigateTo = function (pStateName) {
        this._state.go(pStateName);
    };
    AboutController.$inject = ["$scope", "$state"];
    return AboutController;
})();
angular.module('mcmapp').controller('aboutController', AboutController);
var NavigationLink = (function () {
    function NavigationLink($controllerTarget, $linkText, $leftIcon, $rightIcon) {
        if ($leftIcon === void 0) { $leftIcon = ""; }
        if ($rightIcon === void 0) { $rightIcon = ""; }
        this.ControllerTarget = $controllerTarget;
        this.LinkText = $linkText;
        this.LeftIcon = $leftIcon;
        this.RightIcon = $rightIcon;
    }
    return NavigationLink;
})();
/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../models/models.ts" />
/// <reference path="IControllerNavigation.ts" />
var ChildProfileItemController = (function () {
    function ChildProfileItemController($scope, $state) {
        this._state = $state;
        this._scope = $scope;
        this._navigationLinks =
            [
                new NavigationLink("addPhoto", "Add Photo", "ion-ios-person-outline", "ion-chevron-right"),
                new NavigationLink("childBasics", "Child Basics", "ion-android-person", "ion-chevron-right"),
                new NavigationLink("measurements", "Measurements", "ion-android-calendar", "ion-chevron-right"),
                new NavigationLink("physicalDetails", "Physical Details", "ion-ios-eye", "ion-chevron-right"),
                new NavigationLink("doctorInfo", "Doctor Info", "ion-network", "ion-chevron-right"),
                new NavigationLink("dentalInfo", "Dental Info", "ion-android-happy", "ion-chevron-right"),
                new NavigationLink("medicalAlertInfo", "Medical Alert Info", "ion-medkit", "ion-chevron-right"),
                new NavigationLink("distinguishingFeatures", "Distinguishing Features", "ion-ios-body", "ion-chevron-right"),
                new NavigationLink("idChecklist", "I.D. Checklist", "ion-checkmark", "ion-chevron-right")
            ];
    }
    ChildProfileItemController.prototype.NavigateToHomeScreen = function () {
        this.NavigateTo('landing');
    };
    ChildProfileItemController.prototype.NavigateToPreviousView = function () {
        this.NavigateTo('childProfileList');
    };
    ChildProfileItemController.prototype.NavigationLinks = function () {
        return this._navigationLinks;
    };
    ChildProfileItemController.prototype.NavigateTo = function (pStateName) {
        this._state.go(pStateName);
    };
    ChildProfileItemController.$inject = ["$scope", "$state"];
    return ChildProfileItemController;
})();
angular.module('mcmapp').controller('childProfileItemController', ChildProfileItemController);
/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../models/models.ts" />
/// <reference path="IControllerNavigation.ts" />
var ChildProfileListController = (function () {
    function ChildProfileListController($scope, $state) {
        this._state = $state;
        this._scope = $scope;
        this._navigationLinks =
            [];
    }
    ChildProfileListController.prototype.NavigateToHomeScreen = function () {
        this.NavigateTo('landing');
    };
    ChildProfileListController.prototype.NavigateToPreviousView = function () {
        this.NavigateTo('landing');
    };
    ChildProfileListController.prototype.NavigationLinks = function () {
        return this._navigationLinks;
    };
    ChildProfileListController.prototype.NavigateTo = function (pStateName) {
        this._state.go(pStateName);
    };
    ChildProfileListController.$inject = ["$scope", "$state"];
    return ChildProfileListController;
})();
angular.module('mcmapp').controller('childProfileListController', ChildProfileListController);
/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../models/models.ts" />
/// <reference path="IControllerNavigation.ts" />
var ForgotPasswordController = (function () {
    function ForgotPasswordController($scope, $state) {
        this._state = $state;
        this._scope = $scope;
        this._navigationLinks =
            [];
    }
    ForgotPasswordController.prototype.NavigateToHomeScreen = function () {
        this.NavigateTo('landing');
    };
    ForgotPasswordController.prototype.NavigateToPreviousView = function () {
        this.NavigateTo('landing');
    };
    ForgotPasswordController.prototype.NavigationLinks = function () {
        return this._navigationLinks;
    };
    ForgotPasswordController.prototype.NavigateTo = function (pStateName) {
        this._state.go(pStateName);
    };
    ForgotPasswordController.$inject = ["$scope", "$state"];
    return ForgotPasswordController;
})();
angular.module('mcmapp').controller('forgotPasswordController', ForgotPasswordController);
/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../models/models.ts" />
var InstructionIndexController = (function () {
    function InstructionIndexController($scope, $state) {
        this._state = $state;
        this._scope = $scope;
        this._navigationLinks =
            [];
    }
    InstructionIndexController.prototype.NavigateToHomeScreen = function () {
        this.NavigateTo('landing');
    };
    InstructionIndexController.prototype.NavigateToPreviousView = function () {
        this.NavigateTo('landing');
    };
    InstructionIndexController.prototype.NavigationLinks = function () {
        return this._navigationLinks;
    };
    InstructionIndexController.prototype.NavigateTo = function (pStateName) {
        this._state.go(pStateName);
    };
    InstructionIndexController.$inject = ["$scope", "$state"];
    return InstructionIndexController;
})();
angular.module('mcmapp').controller('instructionIndexController', InstructionIndexController);
/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../models/models.ts" />
/// <reference path="IControllerNavigation.ts" />
var LandingController = (function () {
    function LandingController($scope, $state) {
        this._state = $state;
        this._scope = $scope;
        this._navigationLinks = [
            new NavigationLink("myChildren", "My Children"),
            new NavigationLink("instructionIndex", "Instructions"),
            new NavigationLink("profiles", "Profiles"),
            new NavigationLink("about", "About"),
            new NavigationLink("settings", "Settings")
        ];
    }
    LandingController.prototype.NavigateToHomeScreen = function () {
        this.NavigateTo('landing');
    };
    LandingController.prototype.NavigateToPreviousView = function () {
        this.NavigateTo('landing');
    };
    LandingController.prototype.NavigationLinks = function () {
        return this._navigationLinks;
    };
    LandingController.prototype.NavigateTo = function (pStateName) {
        this._state.go(pStateName);
    };
    LandingController.$inject = ["$scope", "$state"];
    return LandingController;
})();
angular.module('mcmapp').controller('landingController', LandingController);
/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../models/models.ts" />
/// <reference path="IControllerNavigation.ts" />
var MyChildrenController = (function () {
    function MyChildrenController($scope, $state) {
        this._state = $state;
        this._scope = $scope;
        this._navigationLinks =
            [
                new NavigationLink("addChildController", "Add a Child")
            ];
    }
    MyChildrenController.prototype.NavigateToHomeScreen = function () {
        this.NavigateTo('landing');
    };
    MyChildrenController.prototype.NavigateToPreviousView = function () {
        this.NavigateTo('landing');
    };
    MyChildrenController.prototype.NavigationLinks = function () {
        return this._navigationLinks;
    };
    MyChildrenController.prototype.NavigateTo = function (pStateName) {
        this._state.go(pStateName);
    };
    MyChildrenController.$inject = ["$scope", "$state"];
    return MyChildrenController;
})();
angular.module('mcmapp').controller('myChildrenController', MyChildrenController);
/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../models/models.ts" />
/// <reference path="IControllerNavigation.ts" />
var SettingsController = (function () {
    function SettingsController($scope, $state) {
        this._state = $state;
        this._scope = $scope;
        this._navigationLinks =
            [];
    }
    SettingsController.prototype.NavigateToHomeScreen = function () {
        this.NavigateTo('landing');
    };
    SettingsController.prototype.NavigateToPreviousView = function () {
        this.NavigateTo('landing');
    };
    SettingsController.prototype.NavigationLinks = function () {
        return this._navigationLinks;
    };
    SettingsController.prototype.NavigateTo = function (pStateName) {
        this._state.go(pStateName);
    };
    SettingsController.$inject = ["$scope", "$state"];
    return SettingsController;
})();
angular.module('mcmapp').controller('settingsController', SettingsController);
/// <reference path="../Definitions/angular.d.ts" />
var MCM;
(function (MCM) {
    var StaticContentCtrl = (function () {
        function StaticContentCtrl($scope) {
            this.scope = $scope;
            this.id = this.scope.content + this.scope.title;
        }
        StaticContentCtrl.$inject = ["$scope"];
        return StaticContentCtrl;
    })();
    MCM.StaticContentCtrl = StaticContentCtrl;
})(MCM || (MCM = {}));
angular.module('mcmapp').controller('StaticContentCtrl', MCM.StaticContentCtrl);
/// <reference path="../Controllers/StaticContentCtrl.ts" />
var MCM;
(function (MCM) {
    function StaticContentDir() {
        return {
            scope: {
                'staticContent': '@content',
                'title': '@title'
            },
            restrict: "E",
            link: function (scope, ele, attrs, controllers, transcludeFn) {
            },
            templateUrl: 'templates/static-content.html',
            controller: MCM.StaticContentCtrl
        };
    }
    MCM.StaticContentDir = StaticContentDir;
})(MCM || (MCM = {}));
angular.module('mcmapp').directive('staticContent', MCM.StaticContentDir);

//# sourceMappingURL=appBundle.js.map
