angular.module('projecteer')
    .controller('AppController', [
    '$scope',
    '$http',
    '$state',
    'apiUrl',
    'localStorageService',
    'AuthenticationService',
    function ($scope, $http, $state, apiUrl, localStorageService, AuthenticationService) {
        
        //function activate() {
        //    $http.get(apiUrl + '/projecteerusers/user')
        //         .then(function (response) {
        //             $scope.user = response.data;
        //         })
        //         .catch(function (err) {
        
        //         });
        //};
        
        //activate();
        
        $scope.go = function () {
            $state.go('app.project.create');
        };
        
        $scope.logout = function () {
            AuthenticationService.logout();
            location.replace('#/home');
            console.log("User has been logged out");
        };
    }]
);