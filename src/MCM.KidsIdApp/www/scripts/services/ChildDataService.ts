/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../models/models.ts" />
/// <reference path="../services/applicationDataService.ts" />


module MCM{
    export class ChildDataService{

        public static $inject = ['$q', 'applicationDataService'];

        constructor(private $q: angular.IQService, private applicationDataService: ApplicationDataService){
            
        }

        public add(add: Child): angular.IPromise<number | boolean> {
            if(!add || !add.id){
                return this.$q.resolve(false);
            }

            return this.getAllChildren().then(children => {
                let alreadyExists = children.some((child: Child) => child.id === add.id);
                return alreadyExists ? false : children.push(add);
            }).then(numOrFalse => {
                if (numOrFalse === false) {
                    return numOrFalse;
                }
                else {
                    return this.saveChanges().then(() => numOrFalse);
                }
            });
        }


        public get(get:Child): angular.IPromise<Child> {
            if(!get || !get.id){
                return null;
            }

            return this.findChild(get.id);
        }

        public getAllChildren(): angular.IPromise<Child[]> {
            //return [<Child>{ id: "", givenName: "Fred", familyName: "" }];
            //return this.$q.resolve([<Child>{ id: "", givenName: "Fred", familyName: "" }]);
            return this.applicationDataService.getApplicationData()
                .then(appData => appData.Family.children);
        }

        public getById(id: number): angular.IPromise<Child> {
            return this.findChild(id);
        }

        public update(upd: Child): angular.IPromise<Child | boolean> {
            if(!upd || !upd.id){
                return this.$q.resolve(false);
            }

            let findChildPromise = this.findChild(upd.id);
            return findChildPromise.then(child => {
                if (child) {
                    var props = Object.getOwnPropertyNames(upd);
                    props.forEach((property, index) => {
                        child[property] = upd[property];
                    });
                    return child;
                }
                else {
                    return this.getAllChildren().then(children => {
                        children.push(upd);
                        return upd;
                    });
                }
            }).then(child => this.saveChanges().then(() => child));

        }

        public delete(del: Child): angular.IPromise<boolean> {
            if(!del || !del.id){
                return this.$q.resolve(false);
            }
            return this.getAllChildren().then(children => {
                for (var i = children.length - 1; i >= 0; --i) {
                    if (children[i].id == del.id) {
                        children.splice(i, 1);
                        return this.saveChanges().then(() => true);
                    }
                }
                return false;
            });
        }

        /**
         * From http://stackoverflow.com/a/8809472
         */
        public generateUUID() {
            var d = new Date().getTime();
            if (window.performance && typeof window.performance.now === "function") {
                d += performance.now(); //use high-precision timer if available
            }
            var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
                var r = (d + Math.random() * 16) % 16 | 0;
                d = Math.floor(d / 16);
                return (c == 'x' ? r : (r & 0x3 | 0x8)).toString(16);
            });
            return uuid;
        }

        private hasChild(childId): angular.IPromise<boolean> {
            return this.getAllChildren()
                .then(children => children.some((child: Child) => child.id === childId ));
        }
        private findChild(childId): angular.IPromise<Child> {
            return this.getAllChildren()
                .then(children => children.filter((child:Child) => (child.id === childId))[0] || null);
        }
        
        private saveChanges(): angular.IPromise<void> {
            return this.applicationDataService.saveApplicationData();
        }
    }
}

angular.module('mcmapp').service('childDataService', MCM.ChildDataService);
