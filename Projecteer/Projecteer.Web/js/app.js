angular.module('projecteer', ['ngResource', 'ui.router', 'LocalStorageModule']);

angular.module('projecteer').value('apiUrl', 'http://localhost:63171/api');

angular.module('projecteer').config(function ($stateProvider, $urlRouterProvider, $httpProvider) {
    $httpProvider.interceptors.push('AuthenticationInterceptor');

    $urlRouterProvider.otherwise('/home');

    $stateProvider
        .state('home', { url: '/home', templateUrl: '/templates/home.html', controller: 'HomeController' })
        .state('register', { url: '/register', templateUrl: '/templates/register.html', controller: 'RegisterController' })
        .state('login', { url: '/login', templateUrl: '/templates/login.html', controller: 'LoginController' });
    /* Site Flow */
    /* Home - landing page
     * Register - create an account
     * Login
     *
     *     Dashboard - main page after logging in - see all projects
     *         Create - create a project
     *         My Projects - see all projects that belong to user (created and joined)
     *             Look at Created Projects 
     *                 My Project Details - edit user's created projects
     *             Look at Joined Projects
     *         Profile - Look at user's profile where they can edit profile and account settings
     *         Project Details - click on a project to see more details
     *
     *
     */

});

angular.module('projecteer').run(function (AuthenticationService) {
    AuthenticationService.initialize();
});