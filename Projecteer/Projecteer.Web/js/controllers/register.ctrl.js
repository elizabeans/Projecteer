angular.module('projecteer').controller('RegisterController', function ($scope, $timeout, AuthenticationService) {
    $scope.registration = {};

    $scope.register = function() {
        AuthenticationService.registerUser($scope.registration).then(
            function(response) {
                alert("Registration complete!");
                
                $timeout(function() {
                    location.replace('#/login');
                }, 2000);
            },
            function(error) {
                alert("Failed to Register");
            }
        )
    };
});