(function (app) {
    'use strict';

    app.controller('productAddController', productAddController);

    productAddController.$inject = ['$scope', '$state', 'apiService', 'notificationService', 'dateUtils', 'uploadService', 'commonService'];

    function productAddController($scope, $state, apiService, notificationService, dateUtils, uploadService, commonService) {
        $scope.product = {
            CreateDate: moment.utc(),
            CreateBy: 'Admin',
            Status: true
        };
        $scope.btnSubmitTitle = 'Thêm mới';
        $scope.productCategories = [];
        $scope.brands = [];
        $scope.cancel = cancel;
        $scope.submit = submit;
        $scope.getProductCategories = getProductCategories;
        $scope.getBrands = getBrands;
        $scope.createDate = dateUtils.convertUTCtoLocalDate($scope.product.CreateDate.format());
        $scope.editorOptions = {
            language: 'en',
            //uiColor: '#000000'
        };
        $scope.uploadImagePopup = uploadImagePopup;
        $scope.getSeoTitle = getSeoTitle;


        function uploadImagePopup() {
            uploadService.uploadImagePopup(function (file) {
                $scope.product.Image = file;
            });
        }

        function getSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

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
            apiService.post('api/product', $scope.product, function (success) {
                notificationService.displaySuccess('Thêm thành công một bản ghi mới');
                $state.go('product');
            });
        }

        getProductCategories();
        getBrands();

    }
})(angular.module('vshop.product'));