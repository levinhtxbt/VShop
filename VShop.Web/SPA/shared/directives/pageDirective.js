/// <reference path="E:\VShop\VShop\VShop.Web\Content/libs/angular/angular.min.js" />
(function (app) {

    app.directive('pageDirective', pageDirective);
    function pageDirective() {
        return {
            restrict: 'E',
            templateUrl: '/spa/shared/directives/pageDirective.html',
            replace: true,
            scope: {
                page: '@',
                pageCount: '@',
                totalCount: '@',
                searchFunc: '&',
                customPath: '@'
            },

            controller: ['$scope', function ($scope) {
                $scope.search = function (i) {

                    i = i || 0;

                    if (i < 0) {
                        i = 0;
                    } else if (i > $scope.pageCount - 1) {
                        i = $scope.pageCount - 1;
                    }
                    
                    if ($scope.page == i)
                        return;

                    if ($scope.searchFunc) {
                        $scope.searchFunc({ page: i });
                    }
                }

                $scope.range = function () {
                    if (!$scope.pageCount) { return []; }

                    var step = 2;
                    var doubleStep = step * 2;
                    var start = Math.max(0, $scope.page - step);
                    var end = start + 1 + doubleStep;
                    if (end > $scope.pageCount) { end = $scope.pageCount; }
                    var ret = [];

                    for (var i = start; i != end; ++i) {
                        ret.push(i);
                    }
                    return ret;
                }

                $scope.pagePlus = function (count) {
                    return +$scope.page + count;
                }

            }]
        }
    }
})(angular.module('vshop.common'))