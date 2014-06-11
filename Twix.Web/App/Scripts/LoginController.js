app.controller('LoginController', function($scope, $routeParams, $http){
    //sign up
    //get all the values and store them in js object, then send that object in a post ajax call

    $scope.userCreate = function () {
        var UserObj = {
            Username: $scope.Username,
            Firstname: $scope.Firstname,
            Lastname: $scope.Lastname,
            Password: $scope.Password
        };
        //alert(UserObj.Username);
        //alert(UserObj.Firstname);
        //alert(UserObj.Lastname);
        //alert(UserObj.Password);

        $http({ method: "POST", url: "/api/v1/User", data: UserObj})
            .success(function () {
                $location.path('/');
        })
    };

    //
    //
});