(function () {
    'use strict';

    angular.module('vshop.product', ['vshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider']

    function config($stateProvider, $urlRouterProvider, $locationProvider) {
        $locationProvider.hashPrefix('');

        $stateProvider.state('product', {
            url: '/product',
            templateUrl: '/SPA/components/product/productView.html',
            controller: "productController"
        }).state('productAdd', {
            url: '/product/add',
            templateUrl: '/SPA/components/product/productFormView.html',
            controller: "productAddController"
        }).state('productEdit', {
            url: '/product/edit/:id',
            templateUrl: '/SPA/components/product/productFormView.html',
            controller: "productEditController"
        });
    }
})();