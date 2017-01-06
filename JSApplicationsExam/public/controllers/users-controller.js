var usersController = function() {
    var $element = $('#content');
  function all() {   
    var users;
    data.users.get()
      .then(function(resUsers) {
        users = resUsers;
        return templates.get('users');
      })
      .then(function(template) {
        $element.html(template(users));
        $('.btn-add-friend').on('click', function() {
          var id = $(this).parents('.user-box').attr('data-id');
          data.friends.sentRequest(id);
        });
      });
  }

  function register() {      
    templates.get('register')
      .then(function(template) {
        $element.html(template());   
        
        $('#btn-register').on('click', function() {
          var user = {
            username: $('#tb-reg-username').val(),
            password: $('#tb-reg-pass').val()
          };

          data.users.register(user)
            .then(function() {
              toastr.success('User registered!');
              routing.goto('#/');
              document.location.reload(true);
            });
        });
      });
  }

  function findByUsername(params){
      var foundUsers;
      data.users.findByUsername(params)
      .then(function(resFoundUsers){
        foundUsers = resFoundUsers;
        return templates.get('found-user');
      })
      .then(function(template){
        $element.html(template(foundUsers));
      });
  }

  return {
    all: all,
    register: register,
    findByUsername: findByUsername
  };
}();
