module MCM {

    export class FileSelectDir implements ng.IDirective {
        public restrict = 'A';
        public scope = { fileSelect: "=" };

        constructor() {
        }

        link = (scope: ng.IScope, element: ng.IAugmentedJQuery, attrs: ng.IAttributes, ctrl: any) => {
            const fileEl = angular.element("<input type='file' />");
            element.after(fileEl);
            //Apparently can't use display:none or visibility:hidden for security reasons in Android
            //so just position the ugly file input element off screen like this post suggests:
            //http://stackoverflow.com/a/7302101
            fileEl.css({ "position": "absolute", "top": "-100px" });


            element.on("click", () => {
                const event = document.createEvent("HTMLEvents");
                event.initEvent("click", true, true);
                //event.eventName = "click";
                fileEl[0].dispatchEvent(event);
            });
            fileEl.bind("change", changeEvent => {
                const files = (changeEvent.target as any).files;
                const fileSelectHandler: (files: Array<File>) => void = (scope as any).fileSelect;
                fileSelectHandler(files);
            });
        }

        static factory(): ng.IDirectiveFactory {
            const directive = () => new FileSelectDir();
            directive.$inject = [];
            return directive;
        }
    }
}

angular.module('mcmapp').directive('fileSelect', MCM.FileSelectDir.factory());