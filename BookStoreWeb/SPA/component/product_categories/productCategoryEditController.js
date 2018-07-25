(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);

    productCategoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams','commonService'];

    function productCategoryEditController(apiService, $scope, notificationService, $state, $stateParams,commonService) {
        $scope.productCategory = {
            Status: true
        }

        $scope.parentCategories = [];

        $scope.UpdateProductCategory = UpdateProductCategory;

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        function loadProductCategoryDetail() {
            apiService.get('api/productcategory/getbyid/' + $stateParams.id, null, function (result) {
                $scope.productCategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdateProductCategory() {
            apiService.put('api/productcategory/update', $scope.productCategory, function (result) {
                notificationService.displaySuccess('Cập nhập thành công')
                $state.go('productCategories');
            }, function (error) {
                notificationService.displayError('Cập nhập thất bại')
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
        loadProductCategoryDetail();
    }
})(angular.module('datnguyenbookstore.product_categories'));