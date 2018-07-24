(function (app) {
    app.filter("statusFilter", function () {
        return function statusFilter(input) {
            if (input == true)
                return "Kích hoạt";
            else
                return "Khóa";
        }
    });

})(angular.module('datnguyenbookstore.common'));