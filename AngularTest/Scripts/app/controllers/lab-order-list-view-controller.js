angular
    .module('myApp')
    .controller('labOrderListViewController',
        [
            '$scope', 'asyncDataService', 'apiEndpoints', '$location', '$rootScope',
            function ($scope, asyncDataService, apiEndpoints, $location, $rootScope) {

                function loadData() {
                    //api endpoints defined in constants.js
                    var url = apiEndpoints.labOrderList;
                    asyncDataService.getDataFromUrl(url).then(function (data) {
                        $scope.labOrders = data;
                    });
                };
                loadData();
                
                $scope.displayDetail = function (data) {
                    var id = (data && !isNaN(data.labOrderId)) ? data.labOrderId : "";
                    $rootScope.labOrderId = id;
                    $location.path('/detail/' + id); 
                };
            }
        ]);
