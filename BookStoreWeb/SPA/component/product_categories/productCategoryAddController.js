(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);

    productCategoryAddController.$inject = ['apiService','$scope','notificationService','$state','commonService'];

    function productCategoryAddController(apiService,$scope,notificationService,$state,commonService) {
        $scope.productCategory = {
            Status: true
        }

        $scope.parentCategories = [];

        $scope.AddProductCategory = AddProductCategory;

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        function AddProductCategory() {
            apiService.post('api/productcategory/create', $scope.productCategory, function (result) {
                notificationService.displaySuccess('Thêm mới thành công')
                $state.go('productCategories');
            }, function (error) {
                notificationService.displayError('Thêm mới thất bại')
            });
        }

        function loadParentCategory() {
            apiService.get('api/productcategory/getallparent', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log("get list parent failed")
            });
        }

        loadParentCategory();
    }
})(angular.module('datnguyenbookstore.product_categories'));