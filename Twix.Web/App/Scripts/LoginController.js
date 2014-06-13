/// <reference path="../Views/Login.html" />
app.controller('LoginController', function ($scope, $location, $http) {
    $scope.LoginAttempt = function () {
        var UserObj = {
            UsernameAttempt: $scope.Username,
            PasswordAttempt: $scope.Password
        };
        $http({ method: "POST", url: "/api/v1/login", data: UserObj })
        .success(function (data) {
            sessionStorage.setItem(0, JSON.stringify(data));
            $location.path('/user/' + data.Id);
        })
    };
});