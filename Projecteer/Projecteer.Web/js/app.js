angular.module('projecteer', ['ngResource', 'ui.router', 'LocalStorageModule', 'ngMaterial']);

angular.module('projecteer').value('apiUrl', 'http://localhost:63171/api');

angular.module('projecteer').config(function ($stateProvider, $urlRouterProvider, $httpProvider) {
    $httpProvider.interceptors.push('AuthenticationInterceptor');

    $urlRouterProvider.otherwise('/home');

    $stateProvider
        .state('home', { url: '/home', templateUrl: '/templates/home.html', controller: 'HomeController' })
        .state('register', { url: '/register', templateUrl: '/templates/register.html', controller: 'RegisterController' })
        .state('login', { url: '/login', templateUrl: '/templates/login.html', controller: 'LoginController' })

        .state('app', { url: '/app', templateUrl: '/templates/nav.html', controller: 'NavController' })
            .state('app.create', { url: '/create', templateUrl: '/templates/create.html', controller: 'CreateController' });

});

angular.module('projecteer').run(function (AuthenticationService) {
    AuthenticationService.initialize();
});