app.controller('HomepageController', function ($scope, $location, $http) {
    $scope.CurrentUser = JSON.parse(sessionStorage[0]);
    alert("how many times?");


    $scope.GetTweets = function () {
        $http({ method: "GET", url: "/api/v1/tweets/" + $scope.CurrentUser.Id })
        .success(function (data) {
            $scope.tweets = data;
        })
    };
    $scope.GetTweets();
    
    $scope.AddFollowTweets = function () {
        for (var i = 0; i < $scope.CurrentUser.Followers.length; i++) {
            for (var j = 0; j < $scope.CurrentUser.Followers[i].Tweets.length; j++) {
                alert($scope.CurrentUser.Followers[i].Tweets[j].message);
                //$scope.tweets.push($scope.CurrentUser.Followers[i].Tweets[j]);
            }
        };
    };
    $scope.AddFollowTweets();

    $scope.GetUsers = function () {
        $http({ method: "GET", url: "/api/v1/user/" })
        .success(function (data) {
            $scope.Tweeters = data;
        })
    };
    $scope.GetUsers();

    $scope.DeleteTweet = function (id) {
        $http({ method: "DELETE", url: "/api/v1/tweets/" + id })
        .success(function () {
            $scope.GetTweets();
        })
    };

    $scope.DeleteUser = function (id) {
        $http({ method: "DELETE", url: "/api/v1/user/" + id })
        .success(function () {
            $scope.GetUsers();
        })
    };

    $scope.SendTweet = function () {
        var tweet = {
            message: $scope.NewTweet,
            AuthorId: $scope.CurrentUser.Id
        };

        $http({ method: "POST", url: "/api/v1/tweets", data: tweet })
        .success(function (data) {
            sessionStorage.setItem(sessionStorage.length, JSON.stringify(data));
            $scope.GetTweets();
        })
    };

    $scope.Follow = function (PersonToFollowId) {
        var obj = {
            UserId: $scope.CurrentUser.Id,
            UserToFollowId:  PersonToFollowId
        }
        $http({ method: "POST", url: "/api/v1/follow/", data: obj})
    };

    $scope.GetPeopleIFollow = function () {
        $http({method: "GET", url: "/api/v1/user/" + CurrentUser.Id})
    };

    $scope.LogOut = function () {
        $location.path('/');
        sessionStorage.removeItem(0);
    };
});
