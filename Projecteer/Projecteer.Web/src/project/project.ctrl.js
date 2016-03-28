angular.module('projecteer')
    .controller('ProjectCreateController', [
    '$scope',
    '$http',
    '$state',
    'apiUrl',
    'ProjectResource',
    'AccountResource',
    function ($scope, $http, $state, apiUrl, ProjectResource, AccountResource) {
        
        $scope.project = {};
        
        $scope.createProject = function (newProjectData) {
            ProjectResource.createProject(newProjectData).$promise
                .then(function (data) {
                    alert('Project created');
                }).catch(function(err) {
                    alert('Something went wrong when trying to create the new project!');
                });
        };
    }]
);