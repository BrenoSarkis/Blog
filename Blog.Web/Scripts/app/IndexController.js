angular.module('IndexApp', [])
    .controller('IndexController', function ($scope, $http, $sce) {
        $scope.posts = [];
        $scope.init = function () {
            debugger;
            $http({
                method: 'GET',
                url: '/api/ListarPosts/'
            }).success(function (data, status, headers, config) {
                $scope.posts = data;
                angular.forEach($scope.posts, function (value, key) {
                    value.Conteudo = $sce.trustAsHtml(value.Conteudo);
                });
            }).error(function (data, status, headers, config) {
                debugger;
            });
        }
    })