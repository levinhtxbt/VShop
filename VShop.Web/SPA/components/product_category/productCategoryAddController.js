(function (app) {
    'use strict';


    app.controller('productCategoryAddController', productCategoryAddController);

    productCategoryAddController.$inject = ['$scope', '$state', '$filter', 'apiService', 'notificationService', 'dateUtils'];

    function productCategoryAddController($scope, $state, $filter, apiService, notificationService, dateUtils) {

        $scope.productCategory = {
            CreateDate: moment.utc(),
            CreateBy: 'Admin',
            Status: true
        };
        $scope.parentCategories = [];
        $scope.btnSubmitTitle = "Thêm mới";
        $scope.submit = addProductCategory;
        $scope.cancel = cancel;

        $scope.$watch('productCategory.CreateDate', function (newValue) {
            $scope.createDate = dateUtils.convertUTCtoLocalDate($scope.productCategory.CreateDate.format());
        });

        function getParentCategories() {
            apiService.get('api/product-category/getall', null, function (success) {
                $scope.parentCategories = success;
            }, function (failure) {
                notificationService.displayError('Có lỗi xảy ra. Vui lòng thử lại');
                cancel();
            });
        }

        function addProductCategory() {
            apiService.post('api/product-category', $scope.productCategory, function (success) {
                notificationService.displaySuccess('Thêm mới thành công');
                $state.go('productCategory');
            });
        }

        function cancel() {
            $state.go('productCategory');
        }

        getParentCategories();

    }

})(angular.module('vshop.productCategory'));