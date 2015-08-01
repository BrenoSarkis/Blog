angular.module('PostApp', [])
    .controller('PostController', function ($scope, $http) {
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





    //.directive('ckEditor', [function () {
    //    return {
    //        require: '?ngModel',
    //        restrict: 'C',
    //        link: function (scope, elm, attr, model) {
    //            var isReady = false;
    //            var data = [];
    //            var ck = CKEDITOR.replace(elm[0]);

    //            function setData() {
    //                if (!data.length) { return; }

    //                var d = data.splice(0, 1);
    //                ck.setData(d[0] || '<span></span>', function () {
    //                    setData();
    //                    isReady = true;
    //                });
    //            }

    //            ck.on('instanceReady', function (e) {
    //                if (model) { setData(); }
    //            });

    //            elm.bind('$destroy', function () {
    //                ck.destroy(false);
    //            });

    //            if (model) {
    //                ck.on('change', function () {
    //                    scope.$apply(function () {
    //                        var data = ck.getData();
    //                        if (data == '<span></span>') {
    //                            data = null;
    //                        }
    //                        model.$setViewValue(data);
    //                    });
    //                });

    //                model.$render = function (value) {
    //                    if (model.$viewValue === undefined) {
    //                        model.$setViewValue(null);
    //                        model.$viewValue = null;
    //                    }

    //                    data.push(model.$viewValue);

    //                    if (isReady) {
    //                        isReady = false;
    //                        setData();
    //                    }
    //                };
    //            }

    //        }
    //    };
    //}]);

