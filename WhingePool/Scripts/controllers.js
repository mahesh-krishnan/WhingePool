'use strict';


var whingePoolUrl = '/api/WhingePool/';
var whingeUrl = '/api/Whinge/';

whingePoolApp.factory('whingePoolFactory', function ($http) {
    return {

        getWhingePools: function (userName) {
            return $http.get(whingePoolUrl);
        },
        
        getWhingePoolsByUser: function (userName) {
            return $http.get(whingePoolUrl + userName);
        },
        
        joinWhingePool: function (whingePool) {
            return $http.post(whingePoolUrl, whingePool);
        }
    };
});

whingePoolApp.factory('whingeFactory', function ($http) {
    return {

        getWhingesByUser: function (userName) {
            return $http.get(whingeUrl + userName);
        },
        getWhingesByWhingePool: function (whingePoolName) {
            return $http.get(whingePoolUrl + whingePoolName);
        },

        addWhinge: function (whinge) {
            return $http.post(whingeUrl, whinge);
        }
    };
});

whingePoolApp.factory('notificationFactory', function () {

    return {
        success: function (text) {
            toastr.success(text);
        },
        error: function (text) {
            toastr.error(text, "Error sending whinge!");
        }
    };
});

whingePoolApp.controller("whingePoolsController",
    function whingePoolsController($scope, whingePoolFactory, notificationFactory) {

        $scope.whingePools = [];
        $scope.selected = "";


        var getWhingePoolsSuccessCallback = function (data, status) {
            $scope.whingePools = data;
        };
        var successPostCallback = function (data, status, headers, config) {
            successCallback(data, status, headers, config).success(function () {
                $scope.whingePools = {};
            });
        };

        var successCallback = function (data, status, headers, config) {
            notificationFactory.success("Saved!");

            return whingePoolFactory.getWhingePools().success(getWhingePoolsSuccessCallback).error(errorCallback);
        };

        var errorCallback = function (data, status, headers, config) {
            notificationFactory.error(data.ExceptionMessage);
        };
        //var userName = encodeURIComponent($scope.param);

        whingePoolFactory.getWhingePools().success(getWhingePoolsSuccessCallback).error(errorCallback);
        //$scope.joinWhingePool = function () {
        //    var whingePool = { "WhingePool": $scope.selected, "UserId": userName };
        //    whingePoolFactory.joinWhingePool(whingePool).success(successPostCallback).error(errorCallback);
        //};

    });


whingePoolApp.controller("whingePoolsByUserController",
    function whingePoolsByUserController($scope, whingePoolFactory, notificationFactory) {
        
        $scope.whingePools = [];


        var getWhingePoolsSuccessCallback = function (data, status) {
            $scope.whingePools = data;
        };



        var errorCallback = function (data, status, headers, config) {
            notificationFactory.error(data.ExceptionMessage);
        };


        var userName = encodeURIComponent($scope.param);

        whingePoolFactory.getWhingePoolsByUser(userName).success(getWhingePoolsSuccessCallback).error(errorCallback);

 

    });

whingePoolApp.controller("whingesController",
    
    function whingesController($scope, whingeFactory, notificationFactory) {
        $scope.newWhinge = {};
        $scope.whinges = [];

        var getWhingesSuccessCallback = function (data, status) {
            $scope.whinges = data;

        };

        var successCallback = function (data, status, headers, config) {
            notificationFactory.success("Saved");

            return whingeFactory.getWhinges($scope.param).success(getWhingesSuccessCallback).error(errorCallback);
        };

        var successPostCallback = function (data, status, headers, config) {
            notificationFactory.success("Successfully whinged!");
            $scope.whinges.push($scope.newWhinge);
            //whingeFactory.getWhingesByUser(userName).success(getWhingesSuccessCallback).error(errorCallback);
            $scope.newWhinge = {};
        };

        var errorCallback = function (data, status, headers, config) {
            notificationFactory.error(data.ExceptionMessage);
        };


        var userName = encodeURIComponent($scope.param);

        whingeFactory.getWhingesByUser(userName).success(getWhingesSuccessCallback).error(errorCallback);

        $scope.addWhinge = function () {
            whingeFactory.addWhinge($scope.newWhinge).success(successPostCallback).error(errorCallback);
        };


    });
whingePoolApp.controller("whingesController",
    
    function whingesController($scope, whingeFactory, notificationFactory) {
        $scope.newWhinge = {};
        $scope.whinges = [];


        var getWhingesSuccessCallback = function (data, status) {
            $scope.whinges = data;

        };

        var successCallback = function (data, status, headers, config) {
            notificationFactory.success("Saved");

            return whingeFactory.getWhinges($scope.param).success(getWhingesSuccessCallback).error(errorCallback);
        };

        var successPostCallback = function (data, status, headers, config) {
            notificationFactory.success("Successfully whinged!");
            $scope.whinges.push($scope.newWhinge);
            //whingeFactory.getWhingesByUser(userName).success(getWhingesSuccessCallback).error(errorCallback);
            $scope.newWhinge = {};
        };

        var errorCallback = function (data, status, headers, config) {
            notificationFactory.error(data.ExceptionMessage);
        };


        var userName = encodeURIComponent($scope.param);

        whingeFactory.getWhingesByUser(userName).success(getWhingesSuccessCallback).error(errorCallback);

        $scope.addWhinge = function () {
            $scope.newWhinge.Whinger = $scope.param;
            whingeFactory.addWhinge($scope.newWhinge).success(successPostCallback).error(errorCallback);
        };


    });

whingePoolApp.controller("whingesByWhingePoolController",

    function whingesByWhingePoolController($scope, whingeFactory, notificationFactory) {
        $scope.newWhinge = {};
        $scope.whinges = [];

        var getWhingesSuccessCallback = function (data, status) {
            $scope.whinges = data;

        };


        var errorCallback = function (data, status, headers, config) {
            notificationFactory.error(data.ExceptionMessage);
        };


        whingeFactory.getWhingesByWhingePool($scope.currentWhingePool).success(getWhingesSuccessCallback).error(errorCallback);


    });
