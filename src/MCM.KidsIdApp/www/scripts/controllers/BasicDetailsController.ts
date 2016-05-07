/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../Services/UserService.ts" />
/// <reference path="../Services/ChildDataService.ts" />
/// <reference path="../Services/ContactsService.ts" />
/// <reference path="../Definitions/angular-ui-router.d.ts" />
/// <reference path="../Definitions/ionic/ionic.d.ts" />
/// <reference path="../models/models.ts" />
/// <reference path="../Definitions/contacts.d.ts" />

module MCM {
    export class BasicDetailsController {
        
        public static $inject = ['$scope', '$rootScope', '$state', '$stateParams', '$ionicScrollDelegate',
            '$ionicPlatform', '$ionicHistory', '$ionicPopup', 'childDataService', 'contactsService'];

        constructor($scope: ng.IScope, $rootScope: any,
                $state: angular.ui.IStateService, $stateParams: any,
                private $ionicScrollDelegate: ionic.scroll.IonicScrollDelegate,
                $ionicPlatform: ionic.platform.IonicPlatformService,
                $ionicHistory: any,
                private $ionicPopup: ionic.popup.IonicPopupService,
                private childDataService: MCM.ChildDataService,
                private contactsService: MCM.ContactsService) {
            let childId = $stateParams.childId;
            childDataService.getById(childId).then(child => {
                const childDetails: ChildDetails = (child && child.childDetails) ?
                        angular.copy(child.childDetails) : this.createDefaultChildDetails();
                this.doDatePickerSetup(childDetails.birthday || new Date());
                const contactId = childDetails.contact ? childDetails.contact.contactId : null;
                contactsService.findContactById(contactId).then(contact => {
                    this.populatePhoneContactInfoFromContact(contact);
                });
                this.childDetails = childDetails;
            });
            this._childId = childId;
            this.doDatePickerSetup(null);

            let unsubscribeStateChangeStart = $scope.$on('$stateChangeStart', this.onStateChangeStart.bind(this));
            this.internalGoBack = () => {
                unsubscribeStateChangeStart();
                $rootScope.$ionicGoBack();
            };
        }
        

        private _childId: string
        public childDetails: ChildDetails;
        public phoneContact: Contact;
        public datepickerObject;

        private createDefaultChildDetails(): ChildDetails {
            return { givenName: "", familyName: "" };
        }

        public checkChildDetailsHasChanges(editedChildDetails: ChildDetails,
                        originalChildDetails: ChildDetails): boolean {
            if (originalChildDetails == null &&
                    angular.equals(editedChildDetails, this.createDefaultChildDetails())) return false;
            return !angular.equals(originalChildDetails, editedChildDetails);
        }


        private internalGoBack: () => void;
        private onStateChangeStart(event: ng.IAngularEvent, toState, toParams) {
            //Since the check for changes is asynchronous, we have to cancel the event no matter what
            //by calling preventDefault (even if it turns out there are no changes). After the check
            //finishes, we'll call internalGoBack if necessary.
            event.preventDefault();

            let hasChangesPromise = this.childDataService.getById(this._childId)
                .then(chld => {
                    const retrievedDetails = chld ? chld.childDetails : null;
                    return this.checkChildDetailsHasChanges(this.childDetails, retrievedDetails);
                });
            hasChangesPromise.then(hasChanges => {
                if (hasChanges) {
                    this.$ionicPopup.confirm({
                        title: 'Confirm Leave Page',
                        template: 'There are unsaved changes. Ignore changes and leave?'
                    }).then(answer => {
                        if (answer) {
                            this.internalGoBack();
                        }
                    });
                } else {
                    this.internalGoBack();
                }
            });
        }

        public retrieveContactFinished = false;

        private populatePhoneContactInfoFromContact(contact: Contact) {
            this.phoneContact = contact;
            //Docs say to call resize after a promise is resolved: http://ionicframework.com/docs/api/directive/ionContent/
            //Doesn't seem to do anything useful on Android but might help on other platforms.
            this.$ionicScrollDelegate.resize();
            this.retrieveContactFinished = true;
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