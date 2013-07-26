'use strict';

angular.module('wol', [/*'wol.filters',*/ 'wol.services'/*, 'wol.directives'*/, 'wol.controllers']).
  config(['$routeProvider', function ($routeProvider) {
      $routeProvider.when('/', { templateUrl: 'partials/machine-list.html', controller: 'MachineListCtrl' });
      $routeProvider.otherwise({ redirectTo: '/' });
  }]);
