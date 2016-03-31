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

        public static $inject = ['$scope', '$state', '$stateParams', '$ionicScrollDelegate',
                '$ionicPopup', 'childDataService', 'contactsService'];

        constructor($scope: ng.IScope, private $state: angular.ui.IStateService, $stateParams: any,
                private $ionicScrollDelegate: ionic.scroll.IonicScrollDelegate,
                private $ionicPopup: ionic.popup.IonicPopupService,
                private childDataService: MCM.ChildDataService,
                private contactsService: MCM.ContactsService) {
            //this._scope = $scope;
            let childId = $stateParams.childId;
            childDataService.getById(childId).then(child => {
                const childDetails = (child && child.childDetails) ?
                        angular.copy(child.childDetails) : <ChildDetails>{ givenName: "", familyName: "" };
                this.doDatePickerSetup(childDetails.birthday || new Date());
                const contactId = childDetails.contact ? childDetails.contact.contactId : null;
                contactsService.findContactById(contactId).then(contact => {
                    this.populatePhoneContactInfoFromContact(contact);
                });
                this.childDetails = childDetails;
            });
            this._childId = childId;
            this.doDatePickerSetup(null);
        }
        
        private _childId: string
        public childDetails: ChildDetails;
        public phoneContact: Contact;
        public datepickerObject;

        public checkChildDetailsHasChanges(editedChildDetails: ChildDetails,
                        originalChildDetails: ChildDetails): boolean {
            if ((originalChildDetails == null) != (editedChildDetails == null)) return true;
            return !angular.equals(originalChildDetails, editedChildDetails);
        }

        public NavigateToPreviousView() {
            let childChangeInfoPromise = this.childDataService.getById(this._childId)
                .then(chld => {
                    const hasChanges = !chld || this.checkChildDetailsHasChanges(this.childDetails, chld.childDetails);
                    return { isChildPersisted: chld != null, hasChanges };
                });
            
            childChangeInfoPromise.then(childChangeInfo => {
                let go = () => this.$state.go("childProfileItem", { childId: this._childId });
                if (childChangeInfo.hasChanges) {
                    this.$ionicPopup.confirm({
                        title: 'Confirm Leave Page',
                        template: 'There are unsaved changes. Ignore changes and leave?'
                    }).then(answer => {
                        if (answer) {
                            if (childChangeInfo.isChildPersisted) {
                                go();
                            } else {
                                //If leaving the page and the child has never been persisted, go all the
                                //way back to child profile list.
                                this.$state.go("childProfileList");
                            }
                        }
                    });
                } else {
                    go();
                }
            });
        }

        private populatePhoneContactInfoFromContact(contact: Contact) {
            this.phoneContact = contact;
            //Calling resize here was an attempt at fixing an issue on a Android 4.3 phone where content
            //gets cut off at the bottom of the screen, but not sure that it helped anything.
            const doResize = this.$ionicScrollDelegate.resize();
            setTimeout(doResize, 500);
        }

        public linkToContact() {
            return this.contactsService.pickContact().then(contact => {
                this.childDetails.contact = {
                    contactId: contact.id
                };
                if (contact.name) {
                    if (!this.childDetails.givenName && contact.name.givenName) {
                        this.childDetails.givenName = contact.name.givenName;
                    }
                    if (!this.childDetails.familyName && contact.name.familyName) {
                        this.childDetails.familyName = contact.name.familyName;
                    }
                    if (!this.childDetails.additionalName && contact.name.middleName) {
                        this.childDetails.additionalName = contact.name.middleName;
                    }
                }
                this.populatePhoneContactInfoFromContact(contact);
            });
        }

        public saveChanges(formValid: boolean) {
            if (formValid) {
                return this.childDataService.getById(this._childId).then(child => {
                    if (!child) {
                        child = <Child>{ id: this._childId };
                    }
                    child.childDetails = this.childDetails;
                    return this.childDataService.update(child);
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

    }
}

angular.module('mcmapp').controller('basicDetailsController', MCM.BasicDetailsController);