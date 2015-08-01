angular.module('IndexApp', [])
    .controller('IndexController', function ($scope, $http) {
        $scope.posts = [];

        $scope.listarPosts = function () {
            $http({
                method: 'GET',
                url: '/Post/Index'
            }).success(function (data, status, headers, config) {
                debugger;
                $scope.posts = data;
            }).error(function (data, status, headers, config) {

            });
        }
    })