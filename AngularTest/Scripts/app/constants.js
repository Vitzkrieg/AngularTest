angular
    .module('myApp')
    .constant('apiEndpoints',
        {
            labOrderList: '/api/labOrderList',
            labOrderDetail: '/api/labOrderDetail',
            saveLabOrderDetail: '/api/saveLabOrderDetail'
        }).constant('directiveTemplates',
        {
            labOrderListViewControl: '/scripts/app/directives/templates/lab-order-list-view-control.html',
            labOrderDetailViewControl: '/scripts/app/directives/templates/lab-order-detail-view-control.html'
        });