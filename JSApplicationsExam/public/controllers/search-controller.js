var search = function(){
    
    
    function all(){
        templates.get('search')
        .then(function(template){
            $('#content').html(template());
        })
    }

    return {
        all: all
    }
}();