/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('datnguyenbookstore.products', ['datnguyenbookstore.common']).config(config);

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products', {
            url: '/products',
            templateUrl: '/SPA/component/products/productListView.html',
            controller: 'productListController'
        }).state('productAdd', {
            url: '/product_add',
            templateUrl: '/SPA/component/products/productAddView.html',
            controller: 'productAddController'
        }).state('productEdit', {
            url: '/product_edit/:id',
            templateUrl: '/SPA/component/products/productEditView.html',
            controller: 'productEditController'
        });
    }
})();