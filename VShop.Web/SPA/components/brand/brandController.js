(function (app) {
    'use strict';


    app.controller('brandController', brandController);

    brandController.$inject = ['$scope'];

    function brandController($scope) {
        $scope.brands = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.totalCount = 0;
        $scope.getAllBrand = getAllBrand;
        $scope.search = getAllBrand;
        $scope.deleteProductCategory = deleteProductCategory;
        $scope.checkAll = checkAll;
        $scope.deleteMultiple = deleteMultiple;

        function checkAll() {

        }

        function getAllBrand() {

        }

        function deleteProductCategory(id) {

        }

        function deleteMultiple() {

        }
    }
})(angular.module('vshop.brand'));