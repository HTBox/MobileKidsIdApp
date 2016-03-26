/// <reference path="../definitions/angular.d.ts" />
/// <reference path="../services/UserService.ts" />
/// <reference path="../definitions/angular-ui-router.d.ts" />
/// <reference path="../models/models.ts" />

module MCM {
    export class DescriptionDetailsController {

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
            this._childId = $stateParams.childId;
            childDataService.getPhysicalDetails(this._childId).then(details => {
                details = details === null ? <PhysicalDetails>{ } : angular.copy(details);
                this.doDatePickerSetup(details.measurementDate || new Date());
                this.details = details;
            });
            this._childDataService = childDataService;
            this.doDatePickerSetup(null);
        }

        private _childId: string;        
        public details: PhysicalDetails;
        public datepickerObject;

        public checkChildHasChanges(editedDetails: PhysicalDetails, originalDetails: PhysicalDetails): boolean {
          if ((originalDetails == null) != (editedDetails == null)) return true;
          return !angular.equals(originalDetails, editedDetails);
        }

        public NavigateToPreviousView() {
            let hasChangesPromise = this._childDataService.getPhysicalDetails(this._childId)
              .then(dtl => this.checkChildHasChanges(this.details, dtl));
            
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
                this._childDataService.getById(this._childId).then(child => {
                    child.physicalDetails = this.details;
                    this._childDataService.update(child);
                });
            }
        }

        private doDatePickerSetup(defaultDate: Date) {
            //See this page for available options: https://github.com/rajeshwarpatlolla/ionic-datepicker
            this.datepickerObject = {
                titleLabel: 'Select Date',
                inputDate: defaultDate,
                templateType: 'popup',
                to: new Date(),
                callback: (newDate => { this.details.measurementDate = newDate; }).bind(this),
            };
        }
        
    }
}

angular.module('mcmapp').controller('descriptionDetailsController', MCM.DescriptionDetailsController);