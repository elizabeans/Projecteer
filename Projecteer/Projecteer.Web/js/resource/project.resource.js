angular.module('projecteer')
    .factory('ProjectResource', function (apiUrl, $resource) {
        return $resource(apiUrl + '/projects/:projectId', { projectId: '@ProjectId'} ),
            {
                'update': {
                    method: 'PUT'
                }
            };
});