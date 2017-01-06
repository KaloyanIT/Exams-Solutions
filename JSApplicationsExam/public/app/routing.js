var routing = function() {
    const router = new Navigo(null, false),
        $container = $('#content');  
    

    function init() {
        router.on(homeController.all
        )
        .on('#/', homeController.all
    
        ).on('#/home', homeController.all

        ).on('#/users', usersController.all
        ).on('#/materials', materials.all
        ).on('#/materials/:id', function(params){
            let foundMaterial;
            let id = params.id;
            jsonRequester.get(`api/materials/${id}`)
                .then(function(res){
                    return res.result;
                })
                .then(function(resFoundMaterial){
                    foundMaterial = resFoundMaterial;
                    console.log(foundMaterial);
                    return templates.get('found-material');
                })
                .then(function(template){
                    $('#content').html(template(foundMaterial));
                });
        }
        ).on('#/users/register', usersController.register
        ).on('#/profiles/:username', function(params){
             var foundUsers;
             var name = params.username;
             //console.log(name);
            jsonRequester.get(`api/profiles/${name}`)
                .then(function(res){
                    return res.result;
                })
                .then(function(resFoundUsers){
                foundUsers = resFoundUsers;
                //console.log(foundUsers);
                return templates.get('found-user');
                })
                .then(function(template){
                $('#content').html(template(foundUsers));
            });
        }).on('#/search', search.all
        ).resolve();
    }

   

   

    function goto(hash) {
        router.navigate(hash.substr(1));
    }

    return{
        init : init,
        goto : goto
    }
}();

