﻿(function (app) {
    'use strict';

    app.factory('apiService', apiService);

    apiService.$inject = ['$http', 'notificationService', 'authenticationService'];

    function apiService($http, notificationService, authenticationService) {
        return {
            get: get,
            post: post,
            put: put,
            del: del
        }

        function get(url, params, success, failure) {
            authenticationService.setHeader();
            $http.get(url, params).then(function (result) {
                success(result.data);
            }, function (error) {
                console.log(error);
                if (failure)
                    failure(error);
                else
                    notificationService.displayError(error.status + ': Có lỗi xảy ra. Vui lòng thử lại');
            });
        }

        function post(url, data, success, failure) {
            authenticationService.setHeader();
            $http.post(url, data).then(function (result) {
                success(result.data);
            }, function (error) {
                console.log(error);
                if (failure)
                    failure(error);
                else
                    notificationService.displayError(error.status + ': Có lỗi xảy ra. Vui lòng thử lại');
            });
        }

        function put(url, data, success, failure) {
            authenticationService.setHeader();
            $http.put(url, data).then(function (result) {
                success(result.data);
            }, function (error) {
                console.log(error);
                if (failure)
                    failure(error);
                else
                    notificationService.displayError(error.status + ': Có lỗi xảy ra. Vui lòng thử lại');
            });
        }

        function del(url, params, success, failure) {
            authenticationService.setHeader();
            $http.delete(url, params).then(function (result) {
                success(result.data);
            }, function (error) {
                console.log(error);
                if (failure)
                    failure(error);
                else
                    notificationService.displayError(error.status + ': Có lỗi xảy ra. Vui lòng thử lại');
            });
        }
    }

})(angular.module('vshop.common'));