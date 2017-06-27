(function (app) {
    'use strict';


    app.controller('productCategoryEditController', productCategoryEditController);

    productCategoryEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService', 'dateUtils'];

    function productCategoryEditController($scope, $state, $stateParams, apiService, notificationService, dateUtils) {
        $scope.productCategory = {};
        $scope.parentCategories = [];
        $scope.btnSubmitTitle = "Cập nhật";

        $scope.getProductCategory = getProductCategory;
        $scope.cancel = cancel;
        $scope.submit = submit;

        function getParentCategories() {
            apiService.get('api/product-category/getall', null, function (success) {
                $scope.parentCategories = success;
            }, function (failure) {
                notificationService.displayError('Có lỗi xảy ra. Vui lòng thử lại');
                cancel();
            });
        }

        function getProductCategory(id) {
            apiService.get('api/product-category/' + id, null, function (success) {
                $scope.productCategory = success

                $scope.createDate = dateUtils.convertUTCtoLocalDate($scope.productCategory.CreateDate);

                if ($scope.productCategory.UpdateDate) {
                    $scope.updateDate = dateUtils.convertUTCtoLocalDate($scope.productCategory.UpdateDate);
                }
                return;
            });
        }

        function submit() {
            $scope.productCategory.UpdateDate = moment.utc();
            $scope.productCategory.UpdateBy = "Admin";

            apiService.put('api/product-category', $scope.productCategory, function (success) {
                notificationService.displaySuccess('Cập nhật thành công');
                $state.go('productCategory');
            });
        }

        function cancel() {
            $state.go('productCategory');
        }

        getParentCategories();

        getProductCategory($stateParams.id);
    }

})(angular.module('vshop.productCategory'));