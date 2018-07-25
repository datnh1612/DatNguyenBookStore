/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function (app) {
    app.factory('apiService', apiService);

    apiService.$inject = ['$http'];

    function apiService($http) {
        return {
            get: get,
            post: post
        }

        function get(url, params, success, failure) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        }
        function post(url, param, success, failure) {
            $http.post(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        }
    }
})(angular.module('datnguyenbookstore.common'));