(function () {
    'use strict';

    angular
        .module('app')
        .controller('userCtrl', ['$scope', '$filter', 'dataService', function ($scope, $filter, dataService) {
            var users = [];

            $scope.currentPage = 1;
            $scope.itemsPerPage = 5;

            getData();
            function getData() {
                dataService.GetUsers().then(function (result) {
                    $scope.$watch('searchText', function (term) {
                        $scope.users = $filter('filter')(result, term);
                    });
                });
            };
            $scope.deleteUser = function (id) {
                dataService.deleteUser(id).then(function () {
                    toastr.success("User deletd successfully");
                    getData();
                }, function () {
                    toastr.error("Error while deleting user");
                });
            };
            $scope.sortBy = function (column) {
                $scope.sortColumn = column;
                $scope.reverse = !$scope.reverse;
            };
        }])
     .controller('userAddCtrl', ['$scope', '$location', 'dataService', function ($scope, $location, dataService) {

         $scope.createUser = function (user) {
             dataService.addUser(user).then(function (result) {
                 toastr.success('User created successfully');
                 $location.path('/');
             }, function () {
                 toastr.error("Error while creating user")
             });
         };
     }])
    .controller('userEditCtrl', ['$scope', '$routeParams', '$location', 'dataService', function ($scope, $routeParams, $location, dataService) {
        $scope.user = {};
        $scope.showUpdateButton = false;

        dataService.getUserById($routeParams.id).then(function (result) {
            $scope.user = result;
            $scope.showUpdateButton = true;
        }, function () {
            toastr.error("Error in fetching user with id " + $routeParams.id);
        });

        $scope.updateUser = function (user) {
            dataService.editUser(user).then(function () {
                toastr.success("User updated successfully");
                $location.path('/');
            }, function () {
                toastr.error("Error while updating user");
            });
        };
    }])
})();