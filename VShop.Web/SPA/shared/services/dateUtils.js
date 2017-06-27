(function (app) {
    'use strict';

    app.factory('dateUtils', dateUtils);

    //dateUtils.$inject = ['moment'];

    function dateUtils() {

        return {
            convertUTCtoLocalDate: convertUTCtoLocalDate,
            convertLocalDateToUTC: convertLocalDateToUTC
        }

        function convertUTCtoLocalDate(utcDate, format) {
            if (utcDate) {

                if (utcDate.indexOf('Z') === -1 && utcDate.indexOf('+') === -1) {
                    utcDate += 'Z';
                }

                var date = moment(utcDate).local();

                if (format) {
                    return date.format(format);
                } else {
                    return date.format('DD-MM-YYYY HH:mm:ss');;
                }

            } else
                return;

        }

        function convertLocalDateToUTC(localDate) {
            if (localDate) {

            }
        }
    }


})(angular.module('vshop.common'));