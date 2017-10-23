var app = angular.module('MyApp', []);
app.controller('GetList', function ($scope, $http) {
    $http.get("/Home/AccessConfigJson")
        .then(function (response) {
            $scope.list = response.data;
        });
});

app.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider.
          when('/Blank', {
              templateUrl: 'page4.html',
              controller: 'Page1Controller'
          }).
          otherwise({
              redirectTo: '/page4'
          });
    }]);

app.controller("Page1Controller", ['$scope', function ($scope) {
    $scope.myName = "Tejas Trivedi";
}]);