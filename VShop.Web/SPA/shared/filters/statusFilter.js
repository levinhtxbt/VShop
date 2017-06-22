/// <reference path="E:\VShop\VShop\VShop.Web\Content/libs/angular/angular.min.js" />
(function (app) {
    'use strict';

    app.filter('statusFilter', function () {
        return function (input) {
            return input ? 'Kích hoạt' : 'Khóa';
        }

    });


})(angular.module('vshop.common'));