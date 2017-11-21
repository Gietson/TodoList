angular.module('app')
  .service('dataService', function ($http) {
    var result;

    this.getData = function () {

      $http({
        method: 'GET',
        url: 'api/todo'
      }).then(function (data) {
        result = data;
      }, function (err) {
        alert('error=' + JSON.stringify(err));
      });
      return result;
      /*result = $http.get('api/todo')
        .success(function(data, status) {
          result = (data);
        })
        .error(function(err) {
          alert('error=' + JSON.stringify(err));
        });
      return result;*/
    }

  })