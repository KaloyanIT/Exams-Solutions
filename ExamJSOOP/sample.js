 const getId = (function(){
		let id = 1;
		return function(){
			id += 1;

			return id;
		};
	}());

    class Player{
        constructor(name){
            this.name = name;
            this.playlists = [];
        }

        get name(){
            return this._name;
        }
        
        set name(name){
            Validator.CheckIfString(name);
            Validator.CheckNameTitleAuthorLength(name);
            this._name = name;            
        }

        add(playlist){
            if(!(playlist instanceof Playlist))
            this.playlists.push(playlist);
        }

        getPlaylistById(id){

        }

        removePlaylist(playlist){

        }

        listPlaylists(page, size){

        }

        contains(playable, playlist){

        }

        search(pattern){

        }

    }

    
    class Playlist{
        constructor(name){
            this.name = name;
            this.id = getId();
        }

        get name(){
            return this._name;
        }
        
        set name(name){
            this._name = name;
        }
        
    }

    class Playable{
        constructor(title, author){
            this._title = title;
            this._author = author;
            this.id = getId();
        }

        get title(){
            return this._title;
        }
        
        set title(title){
            Validator.CheckIfString(title);
            Validator.CheckNameTitleAuthorLength(title);
            this._title = title;
        }

        get author(){
            return this._author;
        }
        
        set author(author){
            Validator.CheckIfString(author);            
            Validator.CheckNameTitleAuthorLength(author);
            this._author = author;            
        }

        play(){
            let result = `[${this.id}]. [${this.title}] - [${this.author}]`;
            return result;
        }
    }

    class Audio extends Playable{
        constructor(title, author, length){
            super(title, author);
            this.length = length;
        }

        get length(){
            return this._length;     
        }
        
        set length(length){
            Validator.CheckIfNumber(length);
            if(length < 0){
                throw "Length must be greater than 0.";
            }
            this._length = length;
        }

        play(){
            return super.play().concat(` - [${this.length}]`);
        }
    }

    class Video extends Playable{
        constructor(title, author, imdbRating){
            super(title, author);
            this.imdbRating = imdbRating;
        }

        get imdbRating(){
            return this._imdbRating;
        }
        
        set imdbRating(imdbRating){
            Validator.CheckIfNumber(imdbRating);
            if(imdbRating < 1 || imdbRating > 5){
                throw "Raitng must be between 1 and 5";
            }
            this._imdbRating = imdbRating;
        }

         play(){
            return super.play().concat(` - [${this.imdbRating}]`);
        }
    }

    class Validator {
        static CheckNameTitleAuthorLength(value){
            if(value.length < 3 || value.length > 25){
                throw "Input must be more than 3 and less 25 chars.";
            }
        }

        static CheckIfNumber(value){
            if(typeof value !== 'number'){
                throw "Value must be number.";
            }
        }

        static CheckIfString(value){
            if(typeof value !== 'string'){
                throw "Value must be string";
            }
        }
    }


    
   Validator.CheckIfString(120);