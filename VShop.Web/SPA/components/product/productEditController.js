(function (app) {
    'use strict';

    app.controller('productEditController', productEditController);

    productEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService', 'dateUtils'];

    function productEditController($scope, $state, $stateParams, apiService, notificationService, dateUtils) {
        $scope.btnSubmitTitle = "Cập nhật";
        $scope.product = [];
        $scope.productCategories = [];
        $scope.brands = [];
        $scope.cancel = cancel;
        $scope.submit = submit;
        $scope.getProductCategories = getProductCategories;
        $scope.getBrands = getBrands;
        $scope.getProduct = getProduct;
        $scope.editorOptions = {
            language: 'en',
            //uiColor: '#000000'
        };

        function getProductCategories() {
            apiService.get('api/product-category/getall', null, function (success) {
                $scope.productCategories = success;
            }, function (failure) {
                notificationService.displayError('Không thể lấy được danh mục loại sản phẩm. Vui lòng thử lại');
                cancel();
            });
        }

        function getBrands() {
            apiService.get('api/brand/getall', null, function (success) {
                $scope.brands = success;
            }, function (failure) {
                notificationService.displayError('Không thể lấy được danh mục loại nhãn hiệu. Vui lòng thử lại');
                cancel();
            });
        }

        function cancel() {
            $state.go('product');
        }

        function submit() {
            $scope.product.UpdateDate = moment.utc();
            $scope.product.UpdateBy = "Admin";

            apiService.put('api/product', $scope.product, function (success) {
                notificationService.displaySuccess('Cập nhật thành công');
                $state.go('product');
            });
        }

        function getProduct(id) {
            apiService.get('api/product/' + id, null, function (success) {
                $scope.product = success
                $scope.createDate = dateUtils.convertUTCtoLocalDate($scope.product.CreateDate);
                if ($scope.product.UpdateDate) {
                    $scope.updateDate = dateUtils.convertUTCtoLocalDate($scope.product.UpdateDate);
                }
            });
        }

        getProduct($stateParams.id);
        getProductCategories();
        getBrands();
    }
})(angular.module('vshop.product'));