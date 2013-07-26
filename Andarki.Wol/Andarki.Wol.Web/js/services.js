'use strict';

/* Services */

angular.module('wol.services', ['ngResource']).
    factory('Machine', function ($resource) {
        return $resource('/api/machine/', {}, {
            all: { method: 'GET', params: {}, isArray: true }
        })
    }).
    factory('WakeUp', function ($resource) {
        return $resource('/api/WakeUp/:machineId', {machineId: '@Id'}, {
            wakeUp: { method: 'POST', params: {}, isArray: false }
        })
    });
