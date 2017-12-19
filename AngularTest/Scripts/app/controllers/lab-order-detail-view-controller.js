angular
    .module('myApp')
    .controller('labOrderDetailViewController',
    [
        '$scope', 'asyncDataService', 'apiEndpoints', '$rootScope',
        function ($scope, asyncDataService, apiEndpoints, $rootScope) {
            $scope.labOrderDetail = {};

            function loadDetail() {
                //api endpoints defined in constants.js
                var url = apiEndpoints.labOrderDetail + "/" + $rootScope.labOrderId;
                asyncDataService.getDataFromUrl(url).then(function (data) {
                    $scope.labOrderDetail = data;
                });
            }
            loadDetail();

            $scope.saveLabOrderDetail = function () {
                var url = apiEndpoints.saveLabOrderDetail;
                console.log('sLOD() url: ' + url);
                var data = {
                    id: $scope.labOrderDetail.id,
                    amountCollected: $scope.labOrderDetail.amountCollected
                };
                console.log('sLOD() data: ');
                console.dir(data);
                asyncDataService.postDataToUrl(url, data).then(function (data) {
                    console.log('pDTU() data: ');
                    console.dir(data);
                });
            };
        }
    ]);
