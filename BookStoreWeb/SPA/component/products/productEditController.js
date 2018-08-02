(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function productEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.product = {}

        $scope.productCategories = [];

        $scope.UpdateProduct = UpdateProduct;

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px'
        }

        function loadProductDetail() {
            apiService.get('api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdateProduct() {
            apiService.put('api/product/update', $scope.product, function (result) {
                notificationService.displaySuccess('Cập nhập thành công')
                $state.go('products');
            }, function (error) {
                notificationService.displayError('Cập nhập thất bại')
            });
        }

        function loadProductCategory() {
            apiService.get('api/productcategory/getallparent', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log("get list parent failed")
            });
        }

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fireUrl) {
                $scope.product.Image = fireUrl;
            }
            finder.popup();
        }

        loadProductCategory();
        loadProductDetail();
    }
})(angular.module('datnguyenbookstore.products'));