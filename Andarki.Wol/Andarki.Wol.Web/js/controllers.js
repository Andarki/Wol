'use strict';

/* Controllers */

angular.module('wol.controllers', [/*'wol.services'*/]).
  controller('MachineListCtrl', ['$scope', '$timeout', 'Machine', 'WakeUp', function ($scope, $timeout, Machine, WakeUp) {
      $scope.messages = new Array();

      // Get list of machines to wake up from server
      $scope.machines = Machine.all();

      // Define the wakeUp function
      $scope.wakeUp = function (machine) {
          var temp = WakeUp.wakeUp({ Id: machine.Id },
              function successCallback() {
              var message = 'Magic packet sent to ' + machine.Name;
              $scope.messages.push(message);

              $timeout(function () {
                  // Remove the message
                  $scope.messages.splice($scope.messages.indexOf(message), 1);
              }, 4 * 1000);
          }, function failureCallback() {
              var message = 'Failed to send Magic packet to ' + machine.Name;
              $scope.messages.push(message);

              $timeout(function () {
                  // Remove the message
                  $scope.messages.splice($scope.messages.indexOf(message), 1);
              }, 4 * 1000);
          }
          );
      }
  }]);