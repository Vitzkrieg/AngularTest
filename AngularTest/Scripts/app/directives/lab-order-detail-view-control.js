angular
    .module('myApp')
    .directive('labOrderDetailViewControl',
    ['directiveTemplates',
        function (directiveTemplates) {
            var result = {
                controller: 'labOrderDetailViewController',
                //defined in constants
                templateUrl: directiveTemplates.labOrderDetailViewControl,
                restrict: 'A'
            };
            return result;
        }
    ]);