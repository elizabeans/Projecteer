angular.module('projecteer').controller('LoginController', function ($scope, AuthenticationService) {
    $scope.loginData = {};

    $scope.login = function() {
        AuthenticationService.login($scope.loginData).then(
            function(response) {
                location.replace('#/app');
            },
            function(err) {
                alert(err.err_description);
            }
        );
    };
});