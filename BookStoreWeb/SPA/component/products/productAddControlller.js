(function (app) {
    app.controller('productAddController', productAddController);

    productAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function productAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.product = {
            CreateDate: new Date(),
            Status: true
        }

        $scope.ckeditorOptions = {
            language:'vi',
            height:'200px'
        }

        $scope.productCategories = [];

        $scope.AddProduct = AddProduct;

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function AddProduct() {
            apiService.post('api/product/create', $scope.product, function (result) {
                notificationService.displaySuccess('Thêm mới thành công')
                $state.go('products');
            }, function (error) {
                notificationService.displayError('Thêm mới thất bại')
            });
        }

        function loadProductCategory() {
            apiService.get('api/productcategory/getallparent', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log("get list product category failed")
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
    }
})(angular.module('datnguyenbookstore.products'));