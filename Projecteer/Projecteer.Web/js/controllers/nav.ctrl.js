angular.module('projecteer').controller('NavController', function ($scope, localStorageService, apiUrl, AuthenticationService, $http) {

    //function activate() {
    //    $http.get(apiUrl + '/projecteerusers/user')
    //         .then(function (response) {
    //             $scope.user = response.data;
    //         })
    //         .catch(function (err) {

    //         });
    //};

    //activate();

    $scope.logout = function () {
        AuthenticationService.logout();
        location.replace('#/home');
        console.log("User has been logged out");
    };
});