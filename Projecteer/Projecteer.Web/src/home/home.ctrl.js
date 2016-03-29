angular.module('projecteer')
    .controller('HomeController', [
    '$scope',
    '$timeout',
    'AuthenticationService',
    function ($scope, $timeout, AuthenticationService) {

        $scope.loginData = {};

        $scope.login = function() {
            AuthenticationService.login($scope.loginData)
                .then(function(response) {
                    location.replace('#/app/dashboard');
                }).catch(function(err) {
                    alert(err);
                });
        };

        $scope.registration = {};

        $scope.register = function () {
            AuthenticationService.registerUser($scope.registration)
                    .then(function (response) {
                        alert("Registration complete!");

                        // transitions to login page
                        //$timeout(function () {
                        //    location.replace('#/login');
                        //}, 2000);
                    },
                    function (error) {
                        alert("Failed to Register");
                    });
        };

        $(function () {
            $('#login-form-link').click(function (e) {
                $("#login-form").delay(100).fadeIn(100);
                $("#register-form").fadeOut(100);
                $('#register-form-link').removeClass('active');
                $(this).addClass('active');
                e.preventDefault();
            });
            $('#register-form-link').click(function (e) {
                $("#register-form").delay(100).fadeIn(100);
                $("#login-form").fadeOut(100);
                $('#login-form-link').removeClass('active');
                $(this).addClass('active');
                e.preventDefault();
            });
        });

    }]
);