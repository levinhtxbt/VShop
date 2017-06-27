/// <reference path="E:\VShop\VShop\VShop.Web\Content/libs/angular/angular.js" />
(function (app) {
    'use strict';

    app.controller('productCategoryController', productCategoryController);

    productCategoryController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function productCategoryController($scope, apiService, notificationService, $ngBootbox, $filter) {

        $scope.productCategories = [];

        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.totalCount = 0;
        $scope.pageSize = 10;
        $scope.count = 0;
        $scope.keyword = '';
        $scope.isCheckAll = false;
        $scope.search = getAllProductCategory;
        $scope.getAllProductCategory = getAllProductCategory;
        $scope.deleteProductCategory = deleteProductCategory;
        $scope.deleteMultiple = deleteMultiple;
        $scope.checkAll = checkAll;


        function getAllProductCategory(page) {

            page = page || 0;

            var config = {
                params: {
                    pageIndex: page,
                    pageSize: $scope.pageSize,
                    keyword: $scope.keyword
                }
            }
            apiService.get('/api/product-category', config, function (success) {

                if (success.Items.length == 0) {
                    notificationService.displayWarning('Không tìm thấy bản ghi nào');
                }

                $scope.productCategories = success.Items;
                $scope.page = success.Page;
                $scope.pageCount = success.TotalPages;
                $scope.totalCount = success.TotalCount;
                $scope.count = success.count;

            });
        };

        function deleteProductCategory(id) {
            $ngBootbox.confirm('Bạn có muốn xóa bản ghi này?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }

                apiService.del('api/product-category', config, function (success) {
                    notificationService.displaySuccess('Xóa thành công');
                    getAllProductCategory($scope.page);
                });
            }, function () {

            });
        }

        function deleteMultiple() {
            $ngBootbox.confirm('Bạn có muốn xóa những bản ghi này?').then(function () {
                var listSelected = [];
                angular.forEach($scope.selected, function (item) {
                    listSelected.push(item.ID);
                })
                var config = {
                    params: {
                        ids: JSON.stringify(listSelected)
                    }
                }
                apiService.del('api/product-category/delete-multiple', config, function (success) {
                    notificationService.displaySuccess('Xóa thành công ' + success.result + ' bản ghi');
                    getAllProductCategory(0);
                });

            }, function () { });
        }

        function checkAll() {
            if ($scope.isCheckAll === true) {
                $scope.isCheckAll = false;
                $('#cbxCheckAll').prop('checked', false);

            } else {
                $scope.isCheckAll = true;
                $('#cbxCheckAll').prop('checked', true);
            }

            angular.forEach($scope.productCategories, function (item) {
                item.checked = $scope.isCheckAll;
            });
        }

        $scope.$watch('productCategories', function (n, o) {

            var checked = $filter('filter')(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDeleteMultiple').removeAttr('disabled');

                if (checked.length == $scope.productCategories.length) {
                    $('#cbxCheckAll').prop('checked', true);
                } else {
                    $('#cbxCheckAll').prop('checked', false);
                }
            } else {
                $('#btnDeleteMultiple').attr('disabled', 'disabled');
            }
        }, true);

        getAllProductCategory(0);


    }

})(angular.module('vshop.productCategory'));