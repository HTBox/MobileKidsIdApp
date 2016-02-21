class NavigationLink {
    constructor($controllerTarget: string, $linkText: string) {
        this.ControllerTarget = $controllerTarget;
        this.LinkText = $linkText;
    }

    ControllerTarget: string;
    LinkText: string;
}

interface IControllerNavigation {
    NavigateToPreviousView(): void;
    NavigateToHomeScreen(): void;
    NavigationLinks(): Array<NavigationLink>;
    NavigateTo($controller: string): void;
}

