var ClientMasterApp = angular.module('ClientMasterApp', [])

ClientMasterApp.controller('ClientMasterController', function ($scope) {

    $scope.AddClient = function() {
        Pageredirect("/ClientMaster/CreateNewClient");
    }

    $scope.cancel = function() {
        Pageredirect("/ClientMaster/ClientDashboard")
    }
    $scope.ClientDetails = function (cid) {
        document.cookie="ID"+cid
        Pageredirect("/ClientMaster/ClientDetails");
    }
    $scope.edit = function (cid) {
        document.cookie = "ID" + cid
        Pageredirect("/ClientMaster/ClientEdit");
    }

    
});