(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);

    productCategoryAddController.$inject = ['apiService','$scope','notificationService'];

    function productCategoryAddController(apiService,$scope,notificationService) {
        $scope.productCategory = {
            CreateDate: new Date(),
            Status: true
        }

        $scope.parentCategories = [];

        function AddProductCategory() {
            var config = {
                params: {
                    productCategoryViewModel: $scope.productCategory
                }
            }

            apiService.post('api/productcategory/post', config, function (result) {
                notificationService.displaySuccess('Thêm mới thành công')
            }, function (error) {
                notificationService.displayWarning('Thêm mới thất bại')
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