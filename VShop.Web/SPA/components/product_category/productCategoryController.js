(function (app) {
    'use strict';

    app.controller('productCategoryController', productCategoryController);

    productCategoryController.$inject = ['$scope', 'apiService', 'notificationService'];

    function productCategoryController($scope, apiService, notificationService) {

        $scope.productCategories = [];

        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.totalCount = 0;
        $scope.count = 0;
        $scope.keyword = '';
        $scope.search = GetAllProductCategory;
        $scope.GetAllProductCategory = GetAllProductCategory;

        function GetAllProductCategory(page) {

            page = page || 0;

            var config = {
                params: {
                    pageIndex: page,
                    pageSize: 2,
                    keyword:  $scope.keyword
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

            }, function (failure) {
                console.log(failure);
            });
        }

        GetAllProductCategory(0);

      
    }

})(angular.module('vshop.productCategory'));