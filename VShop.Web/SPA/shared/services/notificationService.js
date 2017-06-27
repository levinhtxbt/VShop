(function (app) {
    'use strict';

    app.factory('notificationService', notificationService);

    function notificationService() {
        
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-bottom-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "3000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

        return {
            displaySuccess: displaySuccess,
            displayWarning: displayWarning,
            displayError: displayError,
            displayInfo: displayInfo
        }

        function displaySuccess(message) {
            toastr.success(message);
        }

        function displayWarning(message) {
            toastr.warning(message);
        }

        function displayError(message) {
            toastr.error(message);
        }

        function displayInfo(message) {
            toastr.info(message);
        }
    }

})(angular.module('vshop.common'));