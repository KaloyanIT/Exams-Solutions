routing.init();

if(data.users.hasUser()){
     $('#container-sign-in').addClass('hidden');
      $('#btn-sign-out').on('click', function(e) {
        e.preventDefault();
        data.users.signOut()
          .then(function() {
            document.location = '#/';
            document.location.reload(true);
          });
      });    
}else {
    $('#container-sign-out').addClass('hidden');
    $('#btn-sign-in').on('click', function(e) {
      	e.preventDefault();
        var user = {
          username: $('#tb-username').val(),
          password: $('#tb-password').val()
        };
        data.users.signIn(user)
          .then(function(user) {
            document.location = '#/';
            document.location.reload(true);
          }, function(err) {
            $('#container-sign-in').trigger("reset");
            toastr.error(err.responseText);
          });
      });    
}