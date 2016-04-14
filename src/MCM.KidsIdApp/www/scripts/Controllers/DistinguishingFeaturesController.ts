/// <reference path="../Definitions/angular.d.ts" />
/// <reference path="../Services/UserService.ts" />
/// <reference path="../Definitions/angular-ui-router.d.ts" />
/// <reference path="../models/models.ts" />

class DistinguishingFeaturesController {
    private _state: angular.ui.IStateService;
    private _navigationLinks: Array<MCM.NavigationLink>;

    public static $inject = ['$scope', '$state', '$stateParams', 'childDataService'];

    public childId: string;

    constructor($scope: ng.IScope, $state: angular.ui.IStateService, $stateParams: any, childDataService: MCM.ChildDataService) {
        this._state = $state;
        this.childId = $stateParams.childId;

        childDataService.getById(this.childId).then(child => {
            this._navigationLinks = child.distinguishingFeatures.map(df =>
                new MCM.NavigationLink("", df.description.substring(0, 20)));
        });
    }

    public NavigateToPreviousView() {
        this._state.go("childProfileItem", { childId: this.childId })
    }

    public NavigationLinks() {
        return this._navigationLinks;
    }

    public NavigateTo(pStateName: string) {
        this._state.go(pStateName);
    }
}

angular.module('mcmapp').controller('distinguishingFeaturesController', DistinguishingFeaturesController);