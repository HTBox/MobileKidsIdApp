
module MCM {
    export class ContactsService {

        public static $inject = ["$q"];

        constructor(private $q: angular.IQService) {
        }

        public findContactById(id: string): angular.IPromise<Contact> {
            const deferred = this.$q.defer<Contact>();
            if (id) {
                const fieldType = (navigator.contacts as any).fieldType;
                const fields = [fieldType.id]; //, fieldType.name
                const options = new ContactFindOptions();
                options.filter = id;
                options.multiple = true;
                navigator.contacts.find(fields, contacts => {
                    if (!contacts)
                        throw "Contacts array is null/undefined.  That's weird...";
                    const contact = contacts.length > 0 ? contacts[0] : null;
                    return deferred.resolve(contact);
                }, err => deferred.reject("Contacts find error: " + err), options);
            } else {
                deferred.resolve(null);
            }
            return deferred.promise;
        }

        public pickContact(): angular.IPromise<Contact> {
            const deferred = this.$q.defer<Contact>();
            navigator.contacts.pickContact(contact => {
                deferred.resolve(contact);
            }, err => deferred.reject('Error: ' + err));
            return deferred.promise;
        }

    }
}

angular.module('mcmapp').service('contactsService', MCM.ContactsService);