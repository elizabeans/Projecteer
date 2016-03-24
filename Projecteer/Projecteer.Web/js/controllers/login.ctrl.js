angular.module('projecteer')
    .controller('LoginController', [ 
        '$scope',
        'AuthenticationService',
        function ($scope, AuthenticationService) {
            $scope.loginData = {};

            $scope.login = function () {
                AuthenticationService.login($scope.loginData)
                    .then(function (response) {
                        location.replace('#/app');
                    }).catch(function (err) {
                        alert(err);
                    });
            };
        }]);