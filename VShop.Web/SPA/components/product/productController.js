(function (app) {
    'use strict';

    app.controller('productController', productController);

    productController.$inject = ['$scope', 'apiService', 'notificationService', '$filter', '$ngBootbox'];

    function productController($scope, apiService, notificationService, $filter, $ngBootbox) {
        $scope.products = [];
        $scope.selected = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.totalCount = 0;
        $scope.keyword = '';
        $scope.count = 0;
        $scope.pageSize = 10;
        $scope.isCheckAll = false;
        $scope.checkAll = checkAll;
        $scope.search = getAllProduct;
        $scope.getAllProduct = getAllProduct;
        $scope.deleteMultiple = deleteMultiple;
        $scope.deleteProduct = deleteProduct;

        function getAllProduct(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    pageIndex: page,
                    pageSize: $scope.pageSize
                }
            }
            apiService.get('api/product', config, function (success) {
                if (success.Items.length == 0) {
                    notificationService.displayWarning('Không tìm thấy bản ghi nào');
                }
                $scope.products = success.Items;
                $scope.page = success.Page;
                $scope.count = success.Count;
                $scope.pageCount = success.TotalPages;
                $scope.totalCount = success.TotalCount;
            });

        }

        function checkAll() {
            if ($scope.isCheckAll === true) {
                $scope.isCheckAll = false;
                $('#cbxCheckAll').prop('checked', false);

            } else {
                $scope.isCheckAll = true;
                $('#cbxCheckAll').prop('checked', true);
            }

            angular.forEach($scope.products, function (item) {
                item.checked = $scope.isCheckAll;
            });
        }

        function deleteProduct(id) {
            $ngBootbox.confirm('Bạn có muốn xóa bản ghi này?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }

                apiService.del('api/product', config, function (success) {
                    notificationService.displaySuccess('Xóa thành công');
                    getAllProduct($scope.page);
                });
            }, function () {});
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
                apiService.del('api/product/delete-multiple', config, function (success) {
                    notificationService.displaySuccess('Xóa thành công ' + success.data + ' bản ghi');
                    getAllProduct(0);
                });

            }, function () {});
        }

        $scope.$watch('products', function (n, o) {
            var checked = $filter('filter')(n, {
                checked: true
            });

            if (checked.length) {
                $scope.selected = checked;
                $('#btnDeleteMultiple').removeAttr('disabled');

                if (checked.length == $scope.products.length) {
                    $('#cbxCheckAll').prop('checked', true);
                } else {
                    $('#cbxCheckAll').prop('checked', false);
                }
            } else {
                $('#btnDeleteMultiple').attr('disabled', 'disabled');
            }
        }, true);

        getAllProduct(0);
    }
})(angular.module('vshop.product'));