angular.module('NovoPostApp', [])
    .controller('NovoPostController', function ($scope, $http) {
        $scope.post = {};
        $scope.post.Tags = [];

        $scope.adicionarTag = function () {
            $scope.post.Tags.push($scope.post.Tag);
        }

        $scope.removerTag = function (indice) {
            $scope.post.Tags.splice(indice, 1);
        }

        $scope.salvar = function () {
            $http({
                method: 'POST',
                url: '/Post/Salvar',
                data: $scope.post
            }).success(function (data, status, headers, config) {

            }).error(function (data, status, headers, config) {

            });
        }
    }).directive('ckEditor', function () {
        return {
            require: '?ngModel',
            link: function (scope, elm, attr, ngModel) {
                var ck = CKEDITOR.replace(elm[0]);

                if (!ngModel) return;

                ck.on('pasteState', function () {
                    scope.$apply(function () {
                        ngModel.$setViewValue(ck.getData());
                    });
                });

                ngModel.$render = function (value) {
                    ck.setData(ngModel.$viewValue);
                };
            }
        };
    });