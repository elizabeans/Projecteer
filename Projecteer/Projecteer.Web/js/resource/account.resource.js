angular.module('projecteer').factory('AccountResource', function (apiUrl, $resource) {
    return $resource(apiUrl + '/ProjecteerUser/:ProjecteerUserId', { ProjecteerUserId: '@ProjecteerUserId' },
        {
            'update': {
                method: 'PUT'
            }
        });
});