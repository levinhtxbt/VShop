(function () {
    'use strict';

    angular.module('vshop', ['vshop.product', 'vshop.productCategory','vshop.brand', 'vshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider']

    function config($stateProvider, $urlRouterProvider, $locationProvider) {
        
        $locationProvider.hashPrefix('');

        $stateProvider.state('home', {
            url: '/',
            templateUrl: "/SPA/components/home/homeView.html",
            controller: 'homeController'
        });
        $urlRouterProvider.otherwise('/');
    }
})();