var data = (function() {
  const LOCAL_STORAGE_USERNAME_KEY = 'signed-in-user-username',
    LOCAL_STORAGE_AUTHKEY_KEY = 'signed-in-user-auth-key';

  /* Users */

  function register(user) {
    var reqUser = {
      username: user.username,
      password: user.password
    };

    console.log(reqUser);  

    var options = {
        data: reqUser
    };
    
    console.log(options.data);

    return jsonRequester.post('api/users', options)
      .then(function(resp) {
        var user = resp.result;        
        localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, user.username);
        localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, user.authKey);
        //console.log("user");
        //console.log(user);
        return {
          username: resp.result.username
        };
      });     
    
  }


  function signIn(user) {
    var reqUser = {
      username: user.username,
      password: CryptoJS.SHA1(user.username + user.password).toString()
    };

    var options = {
      data: reqUser
    };

    return jsonRequester.put('api/users/auth', options)
      .then(function(resp) {
        var user = resp.result;
        localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, user.username);
        localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, user.authKey);
        return user;
      });
  }

  function signOut() {
    var promise = new Promise(function(resolve, reject) {
      localStorage.removeItem(LOCAL_STORAGE_USERNAME_KEY);
      localStorage.removeItem(LOCAL_STORAGE_AUTHKEY_KEY);
      resolve();
    });
    return promise;
  }

  function hasUser() {
    return !!localStorage.getItem(LOCAL_STORAGE_USERNAME_KEY) &&
      !!localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY);
  }

  function usersGet() {   
      //console.log("all users")  
    return jsonRequester.get('api/users')
      .then(function(res) {
        return res.result;
      });
  }

  function findUserByUsername(params){
      var usernameToFind = params.username;

      return jsonRequester.get(`api/profiles/${usernameToFind}`)
        .then(function(res){
            return res.result;
        });
  } 
 

  /*  Materials*/

  function materialsGet(){
      return jsonRequester.get('api/materials')
        .then(function(res){            
            return res.result;
        });
  }

  

  

  return {
    users: {
      signIn,
      signOut,
      register,
      hasUser,
      get: usersGet,
      findUserByUsername : findUserByUsername
    },
    materials: {
        get: materialsGet
    }

  };
}());
