module MCM {

    export class PhoneContactDir implements ng.IDirective {
        public restrict = 'E';
        public scope = { phoneContactObj: "=" };
        public templateUrl = 'templates/phonecontact.html';

        constructor() {
        }

        link = (scope: ng.IScope, element: ng.IAugmentedJQuery, attrs: ng.IAttributes, ctrl: any) => {
            
        }

        static factory(): ng.IDirectiveFactory {
            const directive = () => new PhoneContactDir();
            directive.$inject = [];
            return directive;
        }
    }
}

angular.module('mcmapp').directive('phoneContact', MCM.PhoneContactDir.factory());