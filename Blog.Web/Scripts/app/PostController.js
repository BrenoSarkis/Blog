angular.module('PostApp', [])
    .controller('PostController', function ($scope, $http) {
        $scope.tags = [];

        $scope.adicionarTag = function () {
            $scope.tags.push($scope.tag);
        }

        $scope.removerTag = function (indice) {
            $scope.tags.splice(indice, 1);
        }
    })

