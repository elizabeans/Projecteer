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

            $scope.save = function () {
                ProjectResource.createProject($scope.project, function(data) {
                    alert('Project created');
                });
            };
        }]
    );