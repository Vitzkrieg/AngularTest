angular
    .module('myApp')
    .controller('labOrderDetailViewController',
    [
        '$scope', 'asyncDataService', 'apiEndpoints', '$location', '$rootScope',
        function ($scope, asyncDataService, apiEndpoints, $location, $rootScope) {
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
                var url = apiEndpoints.labOrderDetail;

                var data = {
                    Id: $scope.labOrderDetail.id,
                    AmountCollected: $scope.labOrderDetail.amountCollected
                };

                asyncDataService.postDataToUrl(url, data).then(function (result) {
                    if (result && result.data && result.data.result === true) {
                        $location.path('/main');
                    } else {
                        //display error
                    }
                });
            };

            $scope.viewList = function () {
                $location.path('/main'); 
            }
        }
    ]);
