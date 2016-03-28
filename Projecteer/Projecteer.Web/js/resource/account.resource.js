angular.module('projecteer')
    .factory('AccountResource', [
        '$resource',
        'apiUrl',
        function ($resource, apiUrl) {

            return $resource(apiUrl + '/ProjecteerUser/:ProjecteerUserId', { ProjecteerUserId: '@ProjecteerUserId' },
            {
                'update': {
                    method: 'PUT'
                }
            });
        }]
    );