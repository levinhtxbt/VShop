(function (app) {
    app.factory('authData', [
        function () {
            var authDataFactory = {};

            var authentication = {
                userName: '',
                isAuthenticated: false
            };

            authDataFactory.authenticationData = authentication;

            return authDataFactory;
        }]);
})(angular.module('vshop.common'));