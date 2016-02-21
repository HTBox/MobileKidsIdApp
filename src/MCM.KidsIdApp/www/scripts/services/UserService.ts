/// <reference path="../Definitions/angular.d.ts" />

module MCM {
    export class UserService {

        public static $inject = ['$q']

        q: angular.IQService;

        constructor($q) {
            this.q = $q;
            console.log('$q this.$q', $q, this.q);
        }

        public someMethod(param) {
            return this.q(function(resolve, reject) {
                console.log('UserService.someMethod(' + param + ') called');
                resolve(param);
            });
        }
    }
}


angular.module('mcmapp').service('UserService', MCM.UserService);
    