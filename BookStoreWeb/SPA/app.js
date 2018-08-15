/// <reference path="../assets/admin/libs/angular/angular.js" />

(function () {
    //define module for routing, this is root module
    angular.module('datnguyenbookstore',
        [
            'datnguyenbookstore.products',
            'datnguyenbookstore.product_categories',
            'datnguyenbookstore.common'
        ]
    ).config(config).config(configAuthentication);

    //inject services of angular-ui-router, this service use for config routing for this function below
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    //this is nearly same with angular 2 about config a controller,but change directive = url
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('home', {
                url: "/admin",
                parent: 'base',
                templateUrl: "/SPA/component/home/homeView.html",
                controller: "homeController"
            }).state('base', {
                url: '',
                templateUrl: "/SPA/shared/views/baseView.html",
                abstract: true
            }).state('login', {
                url: '/login',
                templateUrl: '/SPA/component/login/loginView.html',
                controller: 'loginController'
            });
        //default state
        $urlRouterProvider.otherwise('/login');
    }

    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }
})();