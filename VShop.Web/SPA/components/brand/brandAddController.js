(function (app) {
    'use strict';


    app.controller('brandAddController', brandAddController);

    brandAddController.$inject = ['$scope', '$state', '$filter', 'apiService', 'notificationService', 'dateUtils'];

    function brandAddController($scope, $state, $filter, apiService, notificationService, dateUtils) {
        $scope.brand = {
            CreateDate: moment.utc(),
            CreateBy: 'Admin',
            Status: true
        };
        
        $scope.btnSubmitTitle = "Thêm mới";
        $scope.submit = addBrand;
        $scope.cancel = cancel;
        $scope.createDate = dateUtils.convertUTCtoLocalDate($scope.brand.CreateDate.format());

        function addBrand() {
            apiService.post('api/brand', $scope.brand, function (success) {
                notificationService.displaySuccess('Thêm mới thành công');
                $state.go('brand');
            });
        };

        function cancel() {
            $state.go('brand');
        }


    }
})(angular.module('vshop.brand'));