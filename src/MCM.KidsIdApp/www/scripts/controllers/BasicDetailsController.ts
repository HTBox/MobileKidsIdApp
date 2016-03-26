/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../Services/UserService.ts" />
/// <reference path="../Services/ChildDataService.ts" />
/// <reference path="../Definitions/angular-ui-router.d.ts" />
/// <reference path="../Definitions/ionic/ionic.d.ts" />
/// <reference path="../models/models.ts" />
/// <reference path="../Definitions/contacts.d.ts" />

module MCM {
    export class BasicDetailsController {

        //private _scope: any;
        private _state: angular.ui.IStateService;
        private _ionicPopup: ionic.popup.IonicPopupService;
        private _childDataService: MCM.ChildDataService;

        public static $inject = ['$scope', '$state', '$stateParams', '$ionicPopup', 'childDataService'];

        constructor($scope: ng.IScope, $state: angular.ui.IStateService, $stateParams: any,
                $ionicPopup: ionic.popup.IonicPopupService, childDataService: MCM.ChildDataService) {
            //this._scope = $scope;
            this._state = $state;
            this._ionicPopup = $ionicPopup;
            let childId = $stateParams.childId;
            childDataService.getById(childId).then(child => {
                const childDetails = (child && child.childDetails) ?
                        angular.copy(child.childDetails) : <ChildDetails>{ givenName: "", familyName: "" };
                this.doDatePickerSetup(childDetails.birthday || new Date());
                this.childDetails = childDetails;
            });
            this._childId = childId;
            this._childDataService = childDataService;
            this.doDatePickerSetup(null);
        }
        
        private _childId: string
        public childDetails: ChildDetails;
        public datepickerObject;

        public checkChildDetailsHasChanges(editedChildDetails: ChildDetails,
                        originalChildDetails: ChildDetails): boolean {
            if ((originalChildDetails == null) != (editedChildDetails == null)) return true;
            return !angular.equals(originalChildDetails, editedChildDetails);
        }

        public NavigateToPreviousView() {
            let hasChangesPromise = this._childDataService.getById(this._childId)
                .then(chld => this.checkChildDetailsHasChanges(this.childDetails, chld.childDetails));
            
            hasChangesPromise.then(hasChanges => {
                let go = () => this._state.go("childProfileItem", { childId: this._childId });
                if (hasChanges) {
                    this._ionicPopup.confirm({
                        title: 'Confirm Leave Page',
                        template: 'There are unsaved changes. Ignore changes and leave?'
                    }).then(answer => {
                        if (answer) { go(); }
                    });
                } else {
                    go();
                }
            });
        }

        public saveChanges(formValid: boolean) {
            if (formValid) {
                return this._childDataService.getById(this._childId).then(child => {
                    if (!child) {
                        child = <Child>{ id: this._childId };
                    }
                    child.childDetails = this.childDetails;
                    return this._childDataService.update(child);
                });
            }
        }

        private doDatePickerSetup(defaultDate: Date) {
            //See this page for available options: https://github.com/rajeshwarpatlolla/ionic-datepicker
            this.datepickerObject = {
                titleLabel: 'Select Date of Birth',
                inputDate: defaultDate,
                templateType: 'popup',
                to: new Date(),
                callback: (newDate => { this.childDetails.birthday = newDate; }).bind(this),
            };
        }
        
        public test() {
            navigator.contacts.pickContact(function (contact) {
                console.log('The following contact has been selected:' + JSON.stringify(contact));
            }, function (err) {
                console.log('Error: ' + err);
            });
    }

}
}

angular.module('mcmapp').controller('basicDetailsController', MCM.BasicDetailsController);