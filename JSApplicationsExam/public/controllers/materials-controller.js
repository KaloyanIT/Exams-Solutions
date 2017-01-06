var materials = function(){
    var $content = $('#content');
  function all() { 
      var materials;

      data.materials.get()
      .then(function(resMaterials){
          materials = resMaterials;
          return templates.get('materials');
      })
      .then(function(template){
          $content.html(template(materials));
      });   
  }

    return {
        all : all
    }

}();