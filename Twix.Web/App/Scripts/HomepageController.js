app.controller('HomePageController', function ($scope, $location, $http) {
    $scope.CurrentUser = JSON.parse(sessionStorage[0]);

    //==============================Tweets=======================================
    $scope.GetTweets = function () {
        $http({ method: "GET", url: "/api/v1/tweets/" + $scope.CurrentUser.Id })
        .success(function (data) {
            $scope.CurrentUser.Tweets = data;
        })
    };

    $scope.SendTweet = function (tweet) {
        if (tweet == undefined) {
            tweet = {
                message: $scope.NewTweet,
                AuthorId: $scope.CurrentUser.Id,
                AuthorName: $scope.CurrentUser.UserName,
                retweets: 0,
                likes: 0
            };
        }

        $http({ method: "POST", url: "/api/v1/createtweet", data: tweet })
        .success(function (data) {
            sessionStorage.setItem(sessionStorage.length, JSON.stringify(data));
            $scope.GetTweets();
        })
    };

    $scope.UpdateTweet = function (tweet) {
        $http({ method: "POST", url: "/api/v1/tweets", data: tweet })
        .success(function () {
            $scope.GetTweets();
        })
    }

    $scope.AddLike = function (tweet) {
        tweet.likes++;
        $scope.UpdateTweet(tweet);
    }

    $scope.Retweet = function (tweet) {
        tweet.retweets++;
        $scope.UpdateTweet(tweet);
        $scope.SendTweet(tweet);
    }
        

    $scope.DeleteTweet = function (id) {
        $http({ method: "DELETE", url: "/api/v1/tweets/" + id })
        .success(function () {
            $scope.GetTweets();
        })
    };



    //===================================Users=====================================

    $scope.GetUsers = function () {
        $http({ method: "GET", url: "/api/v1/user/" })
        .success(function (data) {
            $scope.Tweeters = data;
        })
    };
    $scope.GetUsers();

    $scope.DeleteUser = function (id) {
        $http({ method: "DELETE", url: "/api/v1/user/" + id })
        .success(function () {
            $scope.GetUsers();
        })
    };


    $scope.Follow = function (PersonToFollowId) {
        var obj = {
            UserId: $scope.CurrentUser.Id,
            UserToFollowId:  PersonToFollowId
        }
        $http({ method: "POST", url: "/api/v1/follow/", data: obj })
            .success(function () {
                $scope.GetTweets();
            })
    };

    $scope.GetPeopleIFollow = function () {
        $http({method: "GET", url: "/api/v1/user/" + CurrentUser.Id})
    };

    $scope.LogOut = function () {
        $location.path('/');
        sessionStorage.removeItem(0);
    };
});
