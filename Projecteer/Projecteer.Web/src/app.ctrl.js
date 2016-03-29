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
    function ($scope, $http, $state, apiUrl, localStorageService, authenticationService, projectResource, accountResource) {
        
        $scope.logout = function () {
            authenticationService.logout();
            location.replace('#/home');
            console.log("User has been logged out");
        };

        $scope.project = {};

        $scope.createProject = function (newProjectData) {
            projectResource.createProject(newProjectData).$promise
                .then(function (data) {
                    alert('Project created');
                }).catch(function (err) {
                    alert('Something went wrong when trying to create the new project!');
                });
        };

        function activate() {
            $http.get(apiUrl + '/projecteerusers/user')
              .then(function (response) {
                  $scope.user = response.data;
                })
              .catch(function (err) {
                  // bootbox.alert('Please re-enter your ');
              });
        };

        activate();

    }]
);