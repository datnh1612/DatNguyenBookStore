(function (app) {
    app.controller('rootController', rootController);
    rootController.$inject = ['$scope', '$state'];
    function rootController($scope, $state) {
        $scope.rootSubmit = function () {
            $state.go('login');
        }
    }
})(angular.module('datnguyenbookstore'));