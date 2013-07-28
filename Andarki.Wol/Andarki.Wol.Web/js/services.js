'use strict';

/* Services */

angular.module('wol.services', ['ngResource']).
    factory('Machine', ['$resource', function ($resource) {
        return $resource('/api/machine/', {}, {
            all: { method: 'GET', params: {}, isArray: true }
        })
    }]).
    factory('WakeUp', ['$resource', function ($resource) {
        return $resource('/api/WakeUp/:machineId', {machineId: '@Id'}, {
            wakeUp: { method: 'POST', params: {}, isArray: false }
        })
    }]);
