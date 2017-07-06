(function (app) {
    'use strict';

    app.factory('uploadService', uploadService);

    uploadService.$inject = ['notificationService'];

    function uploadService(notificationService) {
        return {
            uploadImagePopup: uploadImagePopup
        }

        function uploadImagePopup(callback) {
            CKFinder.popup({
                chooseFiles: true,
                width: 800,
                height: 600,
                onInit: function (finder) {
                    finder.on('files:choose', function (evt) {
                        var file = evt.data.files.first();
                        console.log(evt);
                        callback(file.getUrl());
                    });

                    finder.on('file:choose:resizedImage', function (evt) {
                        console.log(evt);
                        callback(file.getUrl());
                    });
                }
            });
        }
      
    }

})(angular.module('vshop.common'));