angular.module('projecteer')
    .controller('CreateController', [
        '$scope',
        '$http',
        '$state',
        'apiUrl',
        'ProjectResource',
        function ($scope, $http, $state, apiUrl, ProjectResource) {
    
            $scope.project = {};

            $scope.saveProject = function () {
                ProjectResource.save($scope.project, function (data) {
                    $scope.project = {};
                });
        };
}]);