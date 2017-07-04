(function (app) {
    'use strict';

    app.controller('productAddController', productAddController);

    productAddController.$inject = ['$scope', '$state', 'apiService', 'notificationService', 'dateUtils'];

    function productAddController($scope, $state, apiService, notificationService, dateUtils) {
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

        function uploadImagePopup() {

            CKFinder.popup({
                chooseFiles: true,
                width: 800,
                height: 600,
                onInit: function (finder) {
                    finder.on('files:choose', function (evt) {
                        var file = evt.data.files.first();
                        //var output = document.getElementById(elementId);
                        //output.value = file.getUrl();
                        console.log(evt);
                    });

                    finder.on('file:choose:resizedImage', function (evt) {
                        //var output = document.getElementById(elementId);
                        //output.value = evt.data.resizedUrl;
                        console.log(evt);
                    });
                }
            });
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