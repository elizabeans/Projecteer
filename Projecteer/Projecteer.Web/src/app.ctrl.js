angular.module('projecteer')
    .controller('AppController', [
    '$scope',
    '$http',
    '$state',
    'apiUrl',
    'localStorageService',
    'AuthenticationService',
    'ProjectResource',
    'AccountResource',
    function ($scope, $http, $state, apiUrl, localStorageService, AuthenticationService, ProjectResource, AccountResource) {
        
        $scope.logout = function () {
            AuthenticationService.logout();
            location.replace('#/home');
            console.log("User has been logged out");
        };

        $scope.project = {};

        $scope.createProject = function (newProjectData) {
            ProjectResource.createProject(newProjectData).$promise
                .then(function (data) {
                    alert('Project created');
                }).catch(function (err) {
                    alert('Something went wrong when trying to create the new project!');
                });
        };
    }]
);