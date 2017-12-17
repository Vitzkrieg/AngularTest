angular
    .module('myApp')
    .controller('labOrderListViewController',
        [
            '$scope', 'asyncDataService', 'apiEndpoints',
            function ($scope, asyncDataService, apiEndpoints) {
                function loadData() {
                    //api endpoints defined in constants.js
                    var url = apiEndpoints.labOrderList;
                    console.log('loadData(): url: ' + url);
                    asyncDataService.getDataFromUrl(url).then(function (data) {
                        $scope.labOrders = data;
                        console.log('loadData(): $scope: ');
                        console.dir( $scope);
                        console.log('loadData(): data: ');
                        console.dir(data);
                    });
                }
                loadData();
            }
        ]);
