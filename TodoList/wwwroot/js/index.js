// index.js 

$(document).ready(function () {
  // Get Todos
  $.ajax({
    url: "api/todo",
    dateType: "json",
    type: "GET",
    success: function (messages) {
      $.each(messages,
        function (index, value) {
          if (value.active) {
            $('#list-items').append(
              "<li><input class='checkbox' type='checkbox' />" + value.message + "<a class='remove' id=" + value.id +">x</a><hr></li>");
          } else {
            $('#list-items').append(
              "<li class='completed'><input class='checkbox' type='checkbox' checked=checked />" + value.message + "<a class='remove' id="+ value.id +">x</a><hr></li>");
          }
        });
    },
    error: function (err) {
      console.error(err);
    }
  });


  $('.add-items').submit(function (event) {
    event.preventDefault();

    var item = $('#todo-list-item').val();

    if (item) {

      var data = {
        message: item,
        active: true
      }

      $.ajax({
        url: "api/todo",
        type: "POST",
        datatype: 'json',
        contentType: "application/json",
        data: JSON.stringify(data),
        success: function (value) {
          $('#list-items').append(
            "<li><input class='checkbox' type='checkbox' />" + value.message + "<a class='remove' id=" + value.id +">x</a><hr></li>");
        },
        error: function (err) {
          console.log('err=' + JSON.stringify(err));
        }
      });

      $('#todo-list-item').val("");
    }
  });

  $(document).on('change', '.checkbox', function () {

    var id = $(this).next().attr('id');
    var row = $(this);

    console.log(id);
    $.ajax({
      url: "api/todo/" + id,
      type: "PUT",
      datatype: 'json',
      success: function () {

        if (btn.attr('checked')) {
          btn.removeAttr('checked');
        }
        else {
          btn.attr('checked', 'checked');
        }

        btn.parent().toggleClass('completed');

      },
      error: function (err) {
        console.log('err=' + JSON.stringify(err));
      }
    });

  });
 $(document).on('click', '.remove', function () {
   
    var id = $(this).attr('id');
    var parrent = $(this).parent();
    
    $.ajax({
      url: "api/todo/" + id,
      type: "DELETE",
      datatype: 'json',
      contentType: "application/json",
      success: function () {
        parrent.remove();
      },
      error: function (err) {
        console.log('err=' + JSON.stringify(err));
      }
    });
    
  });
 

})