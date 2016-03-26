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
            let childId = $stateParams.childId;
            let descriptionId = $stateParams.descriptionId;
            childDataService.getById(childId).then(child => {
                if (child == null)
                  throw "Child does not exist";
                child = angular.copy(child);
                this.description = childDataService.getdescriptionById(child, descriptionId);
            });
            this._childDataService = childDataService;
            this.doDatePickerSetup(null);
        }
        
        public child: Child;
        public descriptions: Array<PhysicalDetails>;
        public description: PhysicalDetails;
        public datepickerObject;

        public checkChildHasChanges(editedChild: Child, originalChild: Child): boolean {
            if ((originalChild == null) != (editedChild == null)) return true;
            return  !angular.equals(originalChild.descriptions, editedChild.descriptions);
        }

        public NavigateToPreviousView() {
            let hasChangesPromise = this._childDataService.get(this.child)
                    .then(chld => this.checkChildHasChanges(this.child, chld));
            
            hasChangesPromise.then(hasChanges => {
                let go = () => this._state.go("childProfileItem", { childId: this.child.id });
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
                this._childDataService.update(this.child);
            }
        }

        private doDatePickerSetup(defaultDate: Date) {
            //See this page for available options: https://github.com/rajeshwarpatlolla/ionic-datepicker
            this.datepickerObject = {
                titleLabel: 'Select Date',
                inputDate: defaultDate,
                templateType: 'popup',
                to: new Date(),
                callback: (newDate => { this.description.measurementDate = newDate; }).bind(this),
            };
        }
        
    }
}

angular.module('mcmapp').controller('descriptionDetailsController', MCM.DescriptionDetailsController);