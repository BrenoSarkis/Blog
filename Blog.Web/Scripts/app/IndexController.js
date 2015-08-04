angular.module('IndexApp', [])
    .controller('IndexController', function ($scope, $http, $sce) {
        $scope.posts = [];
        $scope.tags = [];

        $scope.init = function () {
            $http({
                method: 'GET',
                url: '/api/ListarPosts/'
            }).success(function (data, status, headers, config) {
                $scope.posts = data;
                angular.forEach($scope.posts, function (value, key) {
                    value.Conteudo = $sce.trustAsHtml(value.Conteudo);
                });
            }).error(function (data, status, headers, config) {
            });

            $http({
                method: 'GET',
                url: '/api/ListarTags/'
            }).success(function (data, status, headers, config) {
                $scope.tags = data;
            }).error(function (data, status, headers, config) {
            });
        }
    })