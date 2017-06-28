(function (app) {
    'use strict';

    app.controller('brandController', brandController);

    brandController.$inject = ['$scope', 'apiService', 'notificationService', '$filter', '$ngBootbox'];

    function brandController($scope, apiService, notificationService, $filter, $ngBootbox) {
        $scope.brands = [];
        $scope.selected = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.totalCount = 0;
        $scope.count = 0;
        $scope.pagSize = 10;
        $scope.keyword = '';
        $scope.isCheckAll = false;
        $scope.getAllBrand = getAllBrand;
        $scope.search = getAllBrand;
        $scope.deleteBrand = deleteBrand;
        $scope.checkAll = checkAll;
        $scope.deleteMultiple = deleteMultiple;

        function getAllBrand(page) {
            page = page || 0;

            var config = {
                params: {
                    keyword: $scope.keyword,
                    pageIndex: page,
                    pageSize: $scope.pagSize
                }
            }

            apiService.get('api/brand', config, function (success) {

                if (success.Items.length == 0) {
                    notificationService.displayWarning('Không tìm thấy bản ghi nào');
                }
                $scope.brands = success.Items;
                $scope.page = success.Page;
                $scope.pageCount = success.TotalPages;
                $scope.totalCount = success.TotalCount;
                $scope.count = success.count;
            });
        }

        function deleteBrand(id) {
            $ngBootbox.confirm('Bạn có muốn xóa bản ghi này?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }

                apiService.del('api/brand', config, function (success) {
                    notificationService.displaySuccess('Xóa thành công');
                    getAllBrand($scope.page);
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
                apiService.del('api/brand/delete-multiple', config, function (success) {
                    notificationService.displaySuccess('Xóa thành công ' + success.result + ' bản ghi');
                    getAllBrand(0);
                });

            }, function () {});
        }

        function checkAll() {
            if ($scope.isCheckAll === true) {
                $scope.isCheckAll = false;
                $('#cbxCheckAll').prop('checked', false);

            } else {
                $scope.isCheckAll = true;
                $('#cbxCheckAll').prop('checked', true);
            }

            angular.forEach($scope.brands, function (item) {
                item.checked = $scope.isCheckAll;
            });
        }

        $scope.$watch('brands', function (n, o) {

            var checked = $filter('filter')(n, {
                checked: true
            });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDeleteMultiple').removeAttr('disabled');

                if (checked.length == $scope.brands.length) {
                    $('#cbxCheckAll').prop('checked', true);
                } else {
                    $('#cbxCheckAll').prop('checked', false);
                }
            } else {
                $('#btnDeleteMultiple').attr('disabled', 'disabled');
            }
        }, true);

        getAllBrand(0);
    }
})(angular.module('vshop.brand'));