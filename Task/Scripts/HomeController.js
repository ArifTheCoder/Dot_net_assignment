var app = angular.module('myApp', []);
app.controller('HomeController', function ($scope, $http, $sce) {

    //$scope.loader = false;
    $scope.data = {};
    $scope.events = {};
    $scope.event = {};
    $scope.scust = {};
    $scope.sevent = {};

    $scope.getData = function () {
        $.ajax({
            type: "get",
            url: "https://localhost:44361/api/customers",
            data: {},
            contenttype: "texta/json; charset=utf-8",
            success: function (msg) {
                $scope.data = msg;
                $scope.$apply();
                console.log($scope.data);

            },
            error: function (xmlhttprequest, textstatus, errorthrown) {
                alert("error: " + errorthrown);
            }
        });

        //res.json(formatData(rawData));
    }
    $scope.getData();

    $scope.getEvents = function (CustomerId) {
        $scope.scust = CustomerId;
        $scope.events = {};
        $scope.event = {};
        $scope.sevent = {};
        $.ajax({
            type: "get",
            url: "https://localhost:44361/api/customers/" + CustomerId,
            data: {},
            contenttype: "texta/json; charset=utf-8",
            success: function (msg) {
                $scope.events = msg;
                $scope.$apply();
                console.log($scope.events);

            },
            error: function (xmlhttprequest, textstatus, errorthrown) {
                alert("error: " + errorthrown);
            }
        });

        //res.json(formatData(rawData));
    }

    
    $scope.getEventDetails = function (EventId) {
        $scope.sevent = EventId;
        $scope.event = {};
        $.ajax({
            type: "get",
            url: "https://localhost:44361/api/events/" + EventId,
            data: {},
            contenttype: "texta/json; charset=utf-8",
            success: function (msg) {
                $scope.event = msg;
                $scope.$apply();
                console.log($scope.event);

            },
            error: function (xmlhttprequest, textstatus, errorthrown) {
                alert("error: " + errorthrown);
            }
        });

        //res.json(formatData(rawData));
    }


    $scope.change = function (event) {
        set_to = false;
        if (event.IsOpen == false) set_to = true;
        $.ajax({
            type: "put",
            url: "https://localhost:44361/api/events/" + event.Id,
            data: {
                "Id": event.Id,
                "CustomerId": event.CustomerId,
                "Content": event.Content,
                "EventDateTime": event.EventDateTime,
                "IsOpen": set_to
            },
            contenttype: "texta/json; charset=utf-8",
            success: function (msg) {
                $scope.getEventDetails(event.Id);
            },
            error: function (xmlhttprequest, textstatus, errorthrown) {
                alert("error: " + errorthrown);
            }
        });

        //res.json(formatData(rawData));
    }


});