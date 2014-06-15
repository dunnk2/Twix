app.controller('CreateTweetController', function ($scope, $location, $http) {
    $scope.CurrentUser = JSON.parse(sessionStorage[0]);

    $scope.GetTweets = function () {
        $http({ method: "GET", url: "/api/v1/tweets/" + $scope.CurrentUser.Id })
        .success(function (data) {
            $scope.CurrentUser.Tweets = data;
        })
    };

    $scope.SendTweet = function () {
        var tweet = {
            message: $scope.NewTweet,
            AuthorId: $scope.CurrentUser.Id,
            AuthorName: $scope.CurrentUser.UserName,
            retweets: 0,
            likes: 0
        };

        $http({ method: "POST", url: "/api/v1/createtweet", data: tweet })
        .success(function (data) {
            sessionStorage.setItem(sessionStorage.length, JSON.stringify(data));
            $scope.GetTweets();
        })
    }
});