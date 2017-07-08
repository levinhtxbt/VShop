(function () {
    'use strict';

    angular.module('vshop', ['vshop.product', 'vshop.productCategory', 'vshop.brand', 'vshop.common'])
        .config(config)
        .config(configAuthentication);

    config.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider']

    function config($stateProvider, $urlRouterProvider, $locationProvider) {

        $locationProvider.hashPrefix('');

        $stateProvider.state('base', {
            url: '',
            templateUrl: '/SPA/shared/views/baseView.html',
            abstract: true
        }).state('home', {
            url: '/home',
            parent: 'base',
            templateUrl: "/SPA/components/home/homeView.html",
            controller: 'homeController'
        }).state('login', {
            url: '/login',
            templateUrl: "/SPA/components/login/loginView.html",
            controller: 'loginController'
        });
        $urlRouterProvider.otherwise('/');
    };

    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    };

})();