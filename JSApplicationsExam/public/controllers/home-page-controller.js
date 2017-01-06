var homeController = function() {
    var $content = $('#content');
  function all(context) {      
    templates.get('home')
      .then(function(template) {
        $content.html(template());
      });
  }

  return {
    all: all
  };
}();
