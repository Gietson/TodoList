'use strict';

var app = angular.module('app', ['ngMaterial']);

app.controller('mainCtrl', function ($scope, $http, $timeout, $mdSidenav, $log, $mdDialog) {

  $scope.toggleLeft = buildDelayedToggler('left');

  $scope.privateTodoLists = ['Fill mug', 'Shopping list'];
  $scope.publicTodoLists = ['Write email', 'Develop new app'];

  $scope.items = [];
  $scope.isBusy = true;

  $http.get('api/todo')
    .then(function(response) {
        // Success
        console.log(response.data);
        angular.copy(response.data, $scope.items);
      },
      function(err) {
        // Error
        //vm.errorMessage = "Failed to load stops: " + err;
        console.log('err= ' + err);
      })
    .finally(function() {
      $scope.isBusy = false;
    });


  $scope.getTodoList = function(event) {
    console.log('event=' + JSON.stringify(event));
  }


  $scope.addTodo = function () {
    console.log('message=' + $scope.message);
    $scope.items.push({ message: $scope.message, active: true });
    $scope.message = '';
  };



  $scope.doSecondaryAction = function ($event) {
    $mdDialog.show({
      targetEvent: $event,
      template: '<md-content layout-gt-sm="row" layout-padding> <div><md-input-container><label>Channel name</label><input ng-model="name"></md-input-container><md-input-container><md-button class="md-raised md-primary">Create</md-button></md-input-container></div></md-content>'
    });
    /*
    $mdDialog.show(
      $mdDialog.alert()
      .title('Add new todo list')
      .textContent('<md-content md-theme="docs-dark" layout-gt-sm="row" layout-padding> <div><md-input-container><label>Title</label><input ng-model="user.title"></md-input-container><md-input-container><label>Email</label><input ng-model="user.email" type="email"></md-input-container></div></md-content>')
      .ariaLabel('Secondary click demo')
      .ok('Create!')
      .targetEvent(event)
    );*/
  };

    /**
     * Build handler to open/close a SideNav; when animation finishes
     * report completion in console
     */
  function buildDelayedToggler(navID) {
    return debounce(function() {
        // Component lookup should always be available since we are not using `ng-if`
        $mdSidenav(navID)
          .toggle()
          .then(function() {
            $log.debug("toggle " + navID + " is done");
          });
      },
      200);
  }
  /**
     * Supplies a function that will continue to operate until the
     * time is up.
     */
  function debounce(func, wait, context) {
    var timer;

    return function debounced() {
      var context = $scope,
        args = Array.prototype.slice.call(arguments);
      $timeout.cancel(timer);
      timer = $timeout(function () {
        timer = undefined;
        func.apply(context, args);
      }, wait || 10);
    };
  }
});
