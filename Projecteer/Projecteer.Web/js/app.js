angular.module('projecteer', ['ngResource', 'ui.router', 'LocalStorageModule']);

angular.module('projecteer').value('apiUrl', 'http://localhost:63171/api');

angular.module('projecteer').config(function ($stateProvider, $urlRouterProvider, $httpProvider) {
    $httpProvider.interceptors.push('AuthenticationInterceptor');

    $urlRouterProvider.otherwise('/home');

    $stateProvider
        .state('home', { url: '/home', templateUrl: '/templates/home.html', controller: 'HomeController' })
        .state('register', { url: '/register', templateUrl: '/templates/register.html', controller: 'RegisterController' })
        .state('login', { url: '/login', templateUrl: '/templates/login.html', controller: 'LoginController' })

        .state('app', { url: '/app', templateUrl: '/templates/app.html', controller: 'AppController' })
            .state('app.dashboard', { url: '/dashboard', templateUrl:'templates/dashboard.html', controller: 'DashboardController'})
            .state('app.project', { url: '/project', abstract: true, template: '<ui-view>' })
                .state('app.project.create', { url: '/new', templateUrl: '/templates/project.create.html', controller: 'ProjectCreateController' });
});

angular.module('projecteer').run(function (AuthenticationService) {
    AuthenticationService.initialize();
});