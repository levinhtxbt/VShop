(function (app) {
    'use strict';

    app.factory('apiService', apiService);

    apiService.$inject = ['$http'];

    function apiService($http) {
        return {
            get: get
        }

        function get(url, params, success, failure) {
            $http.get(url, params).then(function (result) {
                success(result.data);
            }, function (error) {
                failure(error);
            });
        }
    }

})(angular.module('vshop.common'));