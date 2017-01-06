/* globals document, window, console */

function solve() {
    return function(selector, initialSuggestions) {
        if(typeof initialSuggestions == []){
            for (var a = 0; a < initialSuggestions.length; a++) {
                if(checkForEquals(initialSuggestions[a])){
                    var li = document.createElement('li');
                    var link = document.createElement('a');
                    link.className += ' suggestion-link';
                    var strong = document.createElement('strong');
                    strong.innerHTML += initialSuggestions[a];
                    li.className += 'suggestion';
                    li.style.display = 'none';
                    link.appendChild(strong);
                    li.appendChild(link);
                    suggestionList.appendChild(li);
                } else {
                    continue;
                }
            }
        }
        var root = document.querySelector(selector);
        var addButton = document.querySelector('.btn-add');
        var button = document.createElement('button');
        var suggestionList = document.querySelector('.suggestions-list');

        var input = document.querySelector('.tb-pattern');

        button.appendChild(addButton);



    var liContent = suggestionList.getElementsByTagName('strong');

    console.log(liContent);
        function checkForEquals(element) {
            if(liContent.indexOf(element) === -1){
                return true;
            } else {
                return false;
            }
        }




        input.addEventListener('input', function() {
            for (var i = 0, itemsLength = liContent.length; i < itemsLength; i++) {

                    var searchValue = input.value.toLowerCase();
                    var liValue = liContent[i].innerHTML.toLowerCase();
                if(searchValue == null) {
                    suggestionList.style.display = "none";
                }

                if (liValue.indexOf(searchValue) === -1) {
                    suggestionList.style.display = "";
                    liContent[i].parentElement.parentElement.style.display = "none";
                }
                else {
                    suggestionList.style.display = "";
                    liContent[i].parentElement.parentElement.style.display = "";
                }
            }
        });





        button.addEventListener("click", function () {
            if(input.value == ''){

            }else {
                if(checkForEquals(input.value)){
                    var li = document.createElement('li');
                    var a = document.createElement('a');
                    a.className += ' suggestion-link';
                    var strong = document.createElement('strong');
                    strong.innerHTML += input.value;
                    li.className += ' suggestion';
                    li.style.display = 'none';
                    a.appendChild(strong);
                    li.appendChild(a);
                    suggestionList.appendChild(li);
                    input.value = '';
                } else {
                    input.value = ' ';
                }

            }
       }, false);

        //root.appendChild(inputText);
        root.appendChild(button);


    };
}

module.exports = solve;