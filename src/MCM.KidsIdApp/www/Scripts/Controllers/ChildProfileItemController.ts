/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../models/models.ts" />
/// <reference path="IControllerNavigation.ts" />

class ChildProfileItemController implements IControllerNavigation {
    private _state;
    private _scope;
    private _navigationLinks: Array<NavigationLink>;

    constructor($scope, $state) {
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

    public static $inject = ["$scope", "$state"]

    public NavigateToHomeScreen() {
        this.NavigateTo('landing');
    }

    public NavigateToPreviousView() {
        this.NavigateTo('childProfileList');
    }

    public NavigationLinks() {
        return this._navigationLinks;
    }

    public NavigateTo($controller: string) {
        this._state.go($controller);
    }
}

angular.module('mcmapp').controller('childProfileItemController', ChildProfileItemController);