function solve(){
	const EMPTY_STRING = '';
	const getId = (function(){
		let id = 1;
		return function(){
			id += 1;

			return id;
		};
	}());

	class Validator {
		static CheckIfStringIsEmpty(value){			
			if (value === EMPTY_STRING) {
				throw new Error("Description cannot be empty string");
			}
		}		

		static CheckIfStringLengthIsCorrect(min, max, value){
			Validator.CheckIfStringIsEmpty(value);
			if(value.length < min || value.length > max){
				throw `String length must be between ${min} and ${max} characters.`;
			}
		}

		static CheckIfString(value){
			if(typeof value !== "string"){
				throw "Value must be string";
			}
		}

		static CheckIfNumber(value){
			if(typeof value !== "number"){
				throw "Value must be a number";
			}
		}

		static CheckIfStringContainOnlyDigits(value){
			for (var index = 0; index < value.length; index++) {
				let element = value[index];
				if(isNaN(parseInt(element))){
					throw "Digit is not a number";
				}
			}
		}

		static CheckForGivenArguments(args){
			if(args === null){
				throw "No arguments are passed";
			}
		}
	}

	class Item {
		constructor(name, description){	
			this.id = getId();		
			this.name = name;
			this.description = description;
		}

		get name(){
			return this._name;
		}

		set name(name){
			Validator.CheckIfString(name);
			Validator.CheckIfStringLengthIsCorrect(2, 40, name);
			this._name = name;
		}

		get description(){
			return this._description;
		}

		set description(description){
			Validator.CheckIfString(description);
			Validator.CheckIfStringIsEmpty(description);
			this._description = description;
		}
	}

	class Book extends Item {
		constructor(name, isbn, genre, description){
			super(name, description);
			this.isbn = isbn;
			this.genre = genre;
		}

		get isbn(){
			return this._isbn;
		}

		set isbn(isbn){
			Validator.CheckIfString(isbn);
			if(isbn.length !== 10 && isbn.length !== 13){
				throw "Isbn length must be 10 or 13 chars."
			}
			Validator.CheckIfStringContainOnlyDigits(isbn);
			this._isbn = isbn;
		}

		get genre(){
			return this._gendre;
		}

		set genre(genre){
			Validator.CheckIfString(genre);
			Validator.CheckIfStringLengthIsCorrect(2, 20, genre);
			this._genre = genre;			
		}		
	}

	class Media extends Item {
		constructor(name, description, duration, rating){
			super(name, description);
			this.duration = duration;
			this.rating = rating;
		}

		get duration(){
			return this._duration;
		}
		
		set duration(duration){
			Validator.CheckIfNumber(duration);
			if(duration < 0){
				throw "Duration must be greater than 0";
			}
			this._duration = duration;
		}

		get rating(){
			return this._rating;
		}
		
		set rating(rating){
			Validator.CheckIfNumber(rating);
			if(number < 1 && number > 5){
				throw "Number must be between 1 and 5";
			}
			this._rating = rating
		}		
	}

	class Catalog{
		constructor(name){
			this.id = getId();
			this.name = name;
			this.items = [];
		}

		get name(){
			return this._name;
		}
		
		set name(name){
			Validator.CheckIfString(name);
			Validator.CheckIfStringLengthIsCorrect(2, 40, name);
			this._name = name;
		}

		add(...items){			
			if(Array.isArray(items[0])){
				items = items[0];
			}

			if(items.length === 0){
				throw "No items added";
			}

			this.items.push(...items);

			return this;
		}

		find(x){
			if(typeof x === "number"){
				for (var item = 0; item < this.items.length; item++) {
					var element = this.items[item];
					if(element.id === x){
						return element;
					}
				}
				return null;
			}

			if(typeof x !== null && typeof x === 'object'){
				return this.items.filter(function(item) {
					return Object.keys(x).every(function(prop) {
						return x[prop] === item[prop];
					});
				});
			}

			throw 'Invalid options or id';
		}

		search(pattern){
			if(typeof pattern !== 'string' || pattern === '') {
				throw 'Search pattern should be non-empty a string';
			}

			return this.items.filter(function(item) {
				return item.name.indexOf(pattern) >= 0
					|| item.description.indexOf(pattern) >= 0;
			});
		}
	}

	class BookCatalog extends Catalog{
		constructor(name){
			super(name);
		}

		add(...books){
			if(Array.isArray(books[0])) {
				books = books[0];
			}

			books.forEach(function(x) {
				if(!(x instanceof Book)) {
					throw 'Must add only books';
				}
			});

			return super.add(...books);
		}

		getGenres(){
			let uniq = {};
			this.items.forEach(x => uniq[x.genre] = true);
			return Object.keys(uniq);
		}

		find(x){
			return super.find(x);
		}
	}

	class MediaCatalog extends Catalog{
		constructor(name){
			super(name);
		}

		add(...media){
			if(Array.isArray(media[0])){
				media = media[0];
			}

			media.forEach(function(x){
				if(!(x instanceof Media)){
					throw "Must add only media";
				}
			});

			return super.add(...media);
		}

		getTop(count){
			Validator.CheckIfNumber(count);
			if(count < 1){
				throw "Count must be greater than one";
			}

			return this.items
				.sort((a, b) => a.rating < b.rating)
				.filter((_, ind) => ind < count)
				.map(x => ({id: x.id, name: x.name}));
		}

		getSortedByDuration(){
			return this.items
				.sort((a, b) => {
					if(a.duration === b.duration) {
						return a.id < b.id;
					}

					return a.duration > b.duration;
			});
		}
	}

	
	



	return {
		getBook(name, isbn, genre, description) {
			return new Book(name, isbn, genre, description);
		},
		getMedia(name, rating, duration, description) {
			return new Media(name, description, rating, duration);
		},
		getBookCatalog(name){
			return new BookCatalog(name);
		},
		getMediaCatalog(name) {
			return new MediaCatalog(name);
		}
	};
}

var module = solve();
var catalog = module.getBookCatalog('John\'s catalog');

var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
catalog.add(book1);
catalog.add(book2);

console.log(catalog.find(book1.id));
//returns book1

console.log(catalog.find({id: book2.id, genre: 'IT'}));
//returns book2

console.log(catalog.search('js')); 
// returns book2

console.log(catalog.search('javascript'));
//returns book1 and book2

console.log(catalog.search('Te sa zeleni'));
//returns []
