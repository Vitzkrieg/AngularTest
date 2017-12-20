angular.module('myApp').config([
    '$stateProvider','$locationProvider', '$mdIconProvider', '$urlRouterProvider', '$mdThemingProvider',
    function ($stateProvider, $locationProvider, $mdIconProvider, $urlRouterProvider, $mdThemingProvider) {

        $locationProvider.hashPrefix('');

        // theme
        $mdThemingProvider.theme('default')
            .primaryPalette('blue')
            .accentPalette('light-green')
            .foregroundPalette['1'] = 'rgb(5, 57, 72)';

        // routes
        $urlRouterProvider.otherwise('/main');

        // states
        $stateProvider
            .state('main',
            {
                url: '/main',
                templateUrl: '/scripts/app/views/main.html',
                controller: 'mainController'
            }).state('detail',
            {
                url: '/detail/:id?',
                templateUrl: '/scripts/app/views/detail.html',
                controller: 'detailController'
            });
    }
]);