angular.module('projecteer').controller('ProjecteerController', function ($scope, localStorageService, apiUrl, AuthenticationService, $http) {

    function activate() {
        $http.get(apiUrl + '/projecteeruser/user')
             .then(function (response) {
                 $scope.user = response.data;
             })
             .catch(function (err) {

             });
    };

    activate();

    $scope.logout = function () {
        AuthenticationService.logout();
        location.replace('#/home'); // TODO: update if needed
    };
});