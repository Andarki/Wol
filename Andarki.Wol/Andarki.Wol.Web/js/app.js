'use strict';

angular.module('wol', [/*'wol.filters',*/ 'wol.services'/*, 'wol.directives'*/, 'wol.controllers', 'ui.bootstrap']).
  config(['$routeProvider', function ($routeProvider) {
      $routeProvider.when('/', { templateUrl: wol.app_root + 'partials/machine-list.html', controller: 'MachineListCtrl' });
      $routeProvider.otherwise({ redirectTo: '/' });
  }]);
