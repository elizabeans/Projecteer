angular.module('projecteer').controller('LoginController', function ($scope, AuthenticationService) {
    $scope.loginData = {};

    $scope.login = function() {
        AuthenticationService.login($scope.loginData).then(
            function(response) {
                location.replace('#/projecteer/dashboard');
            },
            function(err) {
                alert(err.err_description);
            }
        );
    };

    var working = false;
    $('.login').on('submit', function (e) {
        e.preventDefault();
        if (working) return;
        working = true;
        var $this = $(this),
          $state = $this.find('button > .state');
        $this.addClass('loading');
        $state.html('Authenticating');
        setTimeout(function () {
            $this.addClass('ok');
            $state.html('Welcome back!');
            setTimeout(function () {
                $state.html('Log in');
                $this.removeClass('ok loading');
                working = false;
            }, 4000);
        }, 3000);
    });
});