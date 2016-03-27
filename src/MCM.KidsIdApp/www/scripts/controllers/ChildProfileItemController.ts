/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../models/models.ts" />
/// <reference path="IControllerNavigation.ts" />

module MCM {
    export class ChildProfileItemController implements IControllerNavigation {
        private _state;
        private _scope;
        private _childId: string;
        private _navLinks: Array<NavigationLink>;

        constructor($scope, $state, $stateParams: any) {
            this._state = $state;
            this._scope = $scope;
            this._childId = $stateParams.childId;
            
            this._navLinks =
                [
                    new NavigationLink("basicDetails", "Child Basics", "ion-android-person", "ion-chevron-right"),
                    new NavigationLink("photos", "Photos", "ion-ios-person-outline", "ion-chevron-right"),
                    new NavigationLink("physicalDetails", "Physical Details", "ion-ios-eye", "ion-chevron-right"),
                    new NavigationLink("doctorInfo", "Doctor Info", "ion-network", "ion-chevron-right"),
                    new NavigationLink("dentalInfo", "Dental Info", "ion-android-happy", "ion-chevron-right"),
                    new NavigationLink("medicalAlertInfo", "Medical Alert Info", "ion-medkit", "ion-chevron-right"),
                    new NavigationLink("distinguishingFeatures", "Distinguishing Features", "ion-ios-body", "ion-chevron-right"),
                    new NavigationLink("idChecklist", "I.D. Checklist", "ion-checkmark", "ion-chevron-right"),
                    new NavigationLink("documents", "Documents", "ion-ios-box", "ion-chevron-right")
                ];
        }

        public static $inject = ["$scope", "$state", "$stateParams"]

        public NavigateToHomeScreen() {
            this.NavigateTo('landing');
        }

        public NavigateToPreviousView() {
            this.NavigateTo('childProfileList');
        }

        public NavigationLinks() {
            return this._navLinks;
        }

        public NavigateTo(pStateName: string) {
            this._state.go(pStateName, { childId: this._childId });
        }
    }
}

angular.module('mcmapp').controller('childProfileItemController', MCM.ChildProfileItemController);