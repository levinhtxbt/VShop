/// <reference path="E:\VShop\VShop\VShop.Web\Content/libs/angular/angular.js" />
(function () {
    'use strict';

    angular.module('vshop.brand', ['vshop.common']).config(routerConfig);

    routerConfig.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider'];
    function routerConfig($stateProvider, $urlRouterProvider, $locationProvider) {
        $stateProvider.state('brand', {
            url: '/brand',
            templateUrl: '/spa/components/brand/brandListView.html',
            controller: 'brandController'
        }).state('brandAdd', {
            url: '/brand/add',
            templateUrl: '/spa/components/brand/brandFormView.html',
            controller: 'brandAddController'
        }).state('brandEdit', {
            url: '/brand/edit',
            templateUrl: '/spa/components/brand/brandFormView.html',
            controller: 'brandEditController'
        })
    }
})();