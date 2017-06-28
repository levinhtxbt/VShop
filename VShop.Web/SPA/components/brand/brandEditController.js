(function (app) {
    'use strict';


    app.controller('brandEditController', brandEditController);

    brandEditController.$inject = ['$scope', '$state', '$stateParams', 'apiService', 'notificationService', 'dateUtils'];

    function brandEditController($scope, $state, $stateParams, apiService, notificationService, dateUtils) {
        $scope.btnSubmitTitle = "Cập nhật";
        $scope.brand = [];
        $scope.getBrand = getBrand;
        $scope.cancel = cancel;
        $scope.submit = submit;

        function getBrand(id) {
            apiService.get('api/brand/' + id, null, function (success) {
                $scope.brand = success;
                $scope.createDate = dateUtils.convertUTCtoLocalDate($scope.brand.CreateDate);
                if ($scope.brand.UpdateDate) {
                    $scope.updateDate = dateUtils.convertUTCtoLocalDate($scope.brand.UpdateDate);
                }

            }, function (failure) {
                notificationService.displayError('Không thể lấy thông tin bản ghi. Vui lòng thử lại');
                $state.go('brand');
            });
        }

        function submit() {
            $scope.brand.UpdateDate = moment.utc();
            $scope.brand.UpdateBy = 'Admin';    
            apiService.put('api/brand', $scope.brand, function (success) {
                notificationService.displaySuccess('Cập nhật thành công');
                $state.go('brand');
            });
        }

        function cancel() {
            $state.go('brand');
        }

        getBrand($stateParams.id);
    }
})(angular.module('vshop.brand'));