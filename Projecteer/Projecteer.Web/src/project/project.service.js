angular.module('projecteer')
    .factory('ProjectResource', [
        '$resource',
        'apiUrl',
        function ($resource, apiUrl) {

            var resource = $resource(
                apiUrl + '/projects', {}, {
                    getProjects: {
                        method: 'GET',
                        isArray: true
                    },

                    createProject: {
                        method: 'POST'
                    },

                    update: {
                        method: 'PUT'
                    }
                }
            );

            return {
                getProjects: function () {
                    return resource.getProjects();
                },

                createProject: function (newProjectData) {
                    return resource.createProject(newProjectData);
                }
            };
        }]
    );