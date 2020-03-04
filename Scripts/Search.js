/// <reference path="angular.min.js" />

var app = angular.module("carModule", []).controller("carngcontroller", function ($scope) {
    $scope.message = "Hello";
});

////app.controller('carngcontroller', function ($scope) {
////        $scope.cars = cars;
////});

//app.factory("CarService", ["$http", function ($http) {
//    var CarService = {};
//    CarService.getCars = function () {
//        return $http.get("/CarsController/Advsearch");
//    };
//    return CarService;
//}]);

//var app = angular.module("carModule", [])
//    .controller("carngcontroller", function ($scope, $http) {
//        $http.get('CarsController/Adv_search')
//            .then(function (response) {
//                $scope.cars = response.data.list;
//            })
//    });

//app.controller("carngcontroller", function ($scope, CarService) {
//    CarService.getCars().then(function (c) {
//        $scope.cars = c.data.list;
//        //function getCars() {

//        //           //console.log($scope.students);
//        //        })
//        //        .error(function (error) {
//        //            $scope.status = 'Unable to load car data: ' + error.message;
//        //            console.log($scope.status);
//        //        });
//    };
//});