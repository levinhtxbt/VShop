(function () {
    'use strict';

    angular.module('vshop.productCategory', ['vshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider'];

    function config($stateProvider, $urlRouterProvider, $locationProvider) {
        $locationProvider.hashPrefix('');

        $stateProvider.state('productCategory', {
            url: '/product-category',
            parent: 'base',
            templateUrl: '/spa/components/product_category/productCategoryView.html',
            controller: 'productCategoryController'
        }).state('productCategoryAdd', {
            url: '/product-category/add',
            parent: 'base',
            templateUrl: '/spa/components/product_category/productCategoryForm.html',
            controller: 'productCategoryAddController'
        }).state('productCategoryEdit', {
            url: '/product-category/edit/:id',
            parent: 'base',
            templateUrl: '/spa/components/product_category/productCategoryForm.html',
            controller: 'productCategoryEditController'
        });
    }
})();