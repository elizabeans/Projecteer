angular.module('projecteer')
    .controller('ProjectDetailController', [
    '$scope',
    '$http',
    '$state',
    '$stateParams',
    'apiUrl',
    'ProjectResource',
    function ($scope, $http, $state, $stateParams, apiUrl, ProjectResource) {

        $scope.id = ProjectResource.get({ ProjectId: $stateParams.id });

        $http.get(apiUrl + '/projects/' + $scope.id.ProjectId)
            .then(function(response) {
                $scope.project = response.data;
            })
            .catch(function(err) {
                alert("Project didn't load");
            });
    }]
);