(function () {
    angular.module('datnguyenbookstore.products', ['datnguyenbookstore.common']).config(config);

    config.$inject('$stateProvider', '$urlRouterProvider');

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products', {
            url: '/products',
            templateUrl: '/SPA/component/products/productListView.html',
            controller: 'productListViewController'
        });
    }
});