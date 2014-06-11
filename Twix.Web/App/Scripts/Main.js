var app = angular.module("myApp", ['ngRoute']);

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', {
        controller: 'LoginController',
        templateUrl: 'Views/Login.html'
    })
    .when('/user/:id', {
        controller: 'HomepageController',
        templateUrl: 'Views/userhome.html'
    })
    .otherwise({ redirectTo: '/' });
}])