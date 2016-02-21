class NavigationLink {
    constructor($controllerTarget: string, $linkText: string, $leftIcon: string = "", $rightIcon: string = "") {
        this.ControllerTarget = $controllerTarget;
        this.LinkText = $linkText;
        this.LeftIcon = $leftIcon;
        this.RightIcon = $rightIcon;
    }

    ControllerTarget: string;
    LinkText: string;
    LeftIcon: string;
    RightIcon: string;
}

interface IControllerNavigation {
    NavigateToPreviousView(): void;
    NavigateToHomeScreen(): void;
    NavigationLinks(): Array<NavigationLink>;
    NavigateTo(pStateName: string): void;
}

