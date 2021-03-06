﻿/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('datnguyenbookstore.product_categories', ['datnguyenbookstore.common']).config(config);

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('productCategories', {
            url: '/productCategories',
            templateUrl: '/SPA/component/product_categories/productCategoryListView.html',
            controller: 'productCategoryListController'
        }).state('productCategoryAdd', {
            url: '/productCategoryAdd',
            templateUrl: '/SPA/component/product_categories/productCategoryAddView.html',
            controller: 'productCategoryAddController'
        }).state('productCategoryEdit', {
            url: '/productCategoryEdit/:id',
            templateUrl: '/SPA/component/product_categories/productCategoryEditView.html',
            controller: 'productCategoryEditController'
        });
    }
})();