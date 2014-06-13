var app = angular.module("myApp", ['ngRoute']);

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', {
        //controller: 'LoginController',
        templateUrl: 'Views/Gate.html'
    })
    .when('/signup/', {
        controller: 'SignupController',
        templateUrl: 'Views/Signup.html'
    })
    .when('/login/', {
        controller: 'LoginController',
        templateUrl: 'Views/Login.html'
    })
    .when('/user/:id', {
        controller: 'HomepageController',
        templateUrl: 'Views/userhome.html'
    })
    .otherwise({ redirectTo: '/' });
}])