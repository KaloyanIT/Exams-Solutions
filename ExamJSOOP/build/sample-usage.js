"use strict";

var _get = function get(object, property, receiver) { if (object === null) object = Function.prototype; var desc = Object.getOwnPropertyDescriptor(object, property); if (desc === undefined) { var parent = Object.getPrototypeOf(object); if (parent === null) { return undefined; } else { return get(parent, property, receiver); } } else if ("value" in desc) { return desc.value; } else { var getter = desc.get; if (getter === undefined) { return undefined; } return getter.call(receiver); } };

var _typeof = typeof Symbol === "function" && typeof Symbol.iterator === "symbol" ? function (obj) { return typeof obj; } : function (obj) { return obj && typeof Symbol === "function" && obj.constructor === Symbol ? "symbol" : typeof obj; };

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _toConsumableArray(arr) { if (Array.isArray(arr)) { for (var i = 0, arr2 = Array(arr.length); i < arr.length; i++) { arr2[i] = arr[i]; } return arr2; } else { return Array.from(arr); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function solve() {
	var EMPTY_STRING = '';
	var getId = function () {
		var id = 1;
		return function () {
			id += 1;

			return id;
		};
	}();

	var Validator = function () {
		function Validator() {
			_classCallCheck(this, Validator);
		}

		_createClass(Validator, null, [{
			key: "CheckIfStringIsEmpty",
			value: function CheckIfStringIsEmpty(value) {
				if (value === EMPTY_STRING) {
					throw new Error("Description cannot be empty string");
				}
			}
		}, {
			key: "CheckIfStringLengthIsCorrect",
			value: function CheckIfStringLengthIsCorrect(min, max, value) {
				Validator.CheckIfStringIsEmpty(value);
				if (value.length < min || value.length > max) {
					throw "String length must be between " + min + " and " + max + " characters.";
				}
			}
		}, {
			key: "CheckIfString",
			value: function CheckIfString(value) {
				if (typeof value !== "string") {
					throw "Value must be string";
				}
			}
		}, {
			key: "CheckIfNumber",
			value: function CheckIfNumber(value) {
				if (typeof value !== "number") {
					throw "Value must be a number";
				}
			}
		}, {
			key: "CheckIfStringContainOnlyDigits",
			value: function CheckIfStringContainOnlyDigits(value) {
				for (var index = 0; index < value.length; index++) {
					var element = value[index];
					if (isNaN(parseInt(element))) {
						throw "Digit is not a number";
					}
				}
			}
		}, {
			key: "CheckForGivenArguments",
			value: function CheckForGivenArguments(args) {
				if (args === null) {
					throw "No arguments are passed";
				}
			}
		}]);

		return Validator;
	}();

	var Item = function () {
		function Item(name, description) {
			_classCallCheck(this, Item);

			this.id = getId();
			this.name = name;
			this.description = description;
		}

		_createClass(Item, [{
			key: "name",
			get: function get() {
				return this._name;
			},
			set: function set(name) {
				Validator.CheckIfString(name);
				Validator.CheckIfStringLengthIsCorrect(2, 40, name);
				this._name = name;
			}
		}, {
			key: "description",
			get: function get() {
				return this._description;
			},
			set: function set(description) {
				Validator.CheckIfString(description);
				Validator.CheckIfStringIsEmpty(description);
				this._description = description;
			}
		}]);

		return Item;
	}();

	var Book = function (_Item) {
		_inherits(Book, _Item);

		function Book(name, isbn, genre, description) {
			_classCallCheck(this, Book);

			var _this = _possibleConstructorReturn(this, (Book.__proto__ || Object.getPrototypeOf(Book)).call(this, name, description));

			_this.isbn = isbn;
			_this.genre = genre;
			return _this;
		}

		_createClass(Book, [{
			key: "isbn",
			get: function get() {
				return this._isbn;
			},
			set: function set(isbn) {
				Validator.CheckIfString(isbn);
				if (isbn.length !== 10 && isbn.length !== 13) {
					throw "Isbn length must be 10 or 13 chars.";
				}
				Validator.CheckIfStringContainOnlyDigits(isbn);
				this._isbn = isbn;
			}
		}, {
			key: "genre",
			get: function get() {
				return his._gendre;
			},
			set: function set(genre) {
				Validator.CheckIfString(genre);
				Validator.CheckIfStringLengthIsCorrect(2, 20, genre);
				this._genre = genre;
			}
		}]);

		return Book;
	}(Item);

	var Media = function (_Item2) {
		_inherits(Media, _Item2);

		function Media(name, description, duration, rating) {
			_classCallCheck(this, Media);

			var _this2 = _possibleConstructorReturn(this, (Media.__proto__ || Object.getPrototypeOf(Media)).call(this, name, description));

			_this2.duration = duration;
			_this2.rating = rating;
			return _this2;
		}

		_createClass(Media, [{
			key: "duration",
			get: function get() {
				return this._duration;
			},
			set: function set(duration) {
				Validator.CheckIfNumber(duration);
				if (duration < 0) {
					throw "Duration must be greater than 0";
				}
				this._duration = duration;
			}
		}, {
			key: "rating",
			get: function get() {
				return this._rating;
			},
			set: function set(rating) {
				Validator.CheckIfNumber(rating);
				if (number < 1 && number > 5) {
					throw "Number must be between 1 and 5";
				}
				this._rating = rating;
			}
		}]);

		return Media;
	}(Item);

	var Catalog = function () {
		function Catalog(name) {
			_classCallCheck(this, Catalog);

			this.id = getId();
			this.name = name;
			this._items = [];
		}

		_createClass(Catalog, [{
			key: "add",
			value: function add() {
				var _items;

				for (var _len = arguments.length, items = Array(_len), _key = 0; _key < _len; _key++) {
					items[_key] = arguments[_key];
				}

				if (Array.isArray(items[0])) {
					items = items[0];
				}

				if (items.length === 0) {
					throw "No items added";
				}

				(_items = this.items).push.apply(_items, _toConsumableArray(items));

				return this;
			}
		}, {
			key: "find",
			value: function find(x) {
				if (typeof x === "number") {
					for (var item = 0; item < items.length; item++) {
						var element = items[item];
						if (element.id === x) {
							return element;
						}
					}
					return null;
				}

				if (typeof x !== null && (typeof x === "undefined" ? "undefined" : _typeof(x)) === 'object') {
					return this.items.filter(function (item) {
						return Object.keys(x).every(function (prop) {
							return x[prop] === item[prop];
						});
					});
				}

				throw 'Invalid options or id';
			}
		}, {
			key: "search",
			value: function search(pattern) {
				if (typeof pattern !== 'string' || pattern === '') {
					throw 'Search pattern should be non-empty a string';
				}

				return this.items.filter(function (item) {
					return item.name.indexOf(pattern) >= 0 || item.description.indexOf(pattern) >= 0;
				});
			}
		}, {
			key: "name",
			get: function get() {
				return this._name;
			},
			set: function set(name) {
				Validator.CheckIfString(name);
				Validator.CheckIfStringLengthIsCorrect(2, 40, name);
				this._name = name;
			}
		}]);

		return Catalog;
	}();

	var BookCatalog = function (_Catalog) {
		_inherits(BookCatalog, _Catalog);

		function BookCatalog(name) {
			_classCallCheck(this, BookCatalog);

			return _possibleConstructorReturn(this, (BookCatalog.__proto__ || Object.getPrototypeOf(BookCatalog)).call(this, name));
		}

		_createClass(BookCatalog, [{
			key: "add",
			value: function add() {
				var _get2;

				for (var _len2 = arguments.length, books = Array(_len2), _key2 = 0; _key2 < _len2; _key2++) {
					books[_key2] = arguments[_key2];
				}

				if (Array.isArray(books[0])) {
					books = books[0];
				}

				books.forEach(function (x) {
					if (!(x instanceof Book)) {
						throw 'Must add only books';
					}
				});

				return (_get2 = _get(BookCatalog.prototype.__proto__ || Object.getPrototypeOf(BookCatalog.prototype), "add", this)).call.apply(_get2, [this].concat(_toConsumableArray(books)));
			}
		}, {
			key: "getGenres",
			value: function getGenres() {
				var uniq = {};
				this.items.forEach(function (x) {
					return uniq[x.genre] = true;
				});
				return Object.keys(uniq);
			}
		}, {
			key: "find",
			value: function find(x) {
				return _get(BookCatalog.prototype.__proto__ || Object.getPrototypeOf(BookCatalog.prototype), "find", this).call(this, x);
			}
		}]);

		return BookCatalog;
	}(Catalog);

	var MediaCatalog = function (_Catalog2) {
		_inherits(MediaCatalog, _Catalog2);

		function MediaCatalog(name) {
			_classCallCheck(this, MediaCatalog);

			return _possibleConstructorReturn(this, (MediaCatalog.__proto__ || Object.getPrototypeOf(MediaCatalog)).call(this, name));
		}

		_createClass(MediaCatalog, [{
			key: "add",
			value: function add() {
				var _get3;

				for (var _len3 = arguments.length, media = Array(_len3), _key3 = 0; _key3 < _len3; _key3++) {
					media[_key3] = arguments[_key3];
				}

				if (Array.isArray(media[0])) {
					media = media[0];
				}

				media.forEach(function (x) {
					if (!(x instanceof Media)) {
						throw "Must add only media";
					}
				});

				return (_get3 = _get(MediaCatalog.prototype.__proto__ || Object.getPrototypeOf(MediaCatalog.prototype), "add", this)).call.apply(_get3, [this].concat(_toConsumableArray(media)));
			}
		}, {
			key: "getTop",
			value: function getTop(count) {
				Validator.CheckIfNumber(count);
				if (count < 1) {
					throw "Count must be greater than one";
				}

				return this.items.sort(function (a, b) {
					return a.rating < b.rating;
				}).filter(function (_, ind) {
					return ind < count;
				}).map(function (x) {
					return { id: x.id, name: x.name };
				});
			}
		}, {
			key: "getSortedByDuration",
			value: function getSortedByDuration() {
				return this.items.sort(function (a, b) {
					if (a.duration === b.duration) {
						return a.id < b.id;
					}

					return a.duration > b.duration;
				});
			}
		}]);

		return MediaCatalog;
	}(Catalog);

	return {
		getBook: function getBook(name, isbn, genre, description) {
			return new Book(name, isbn, genre, description);
		},
		getMedia: function getMedia(name, rating, duration, description) {
			return new Media(name, description, rating, duration);
		},
		getBookCatalog: function getBookCatalog(name) {
			return new BookCatalog(name);
		},
		getMediaCatalog: function getMediaCatalog(name) {
			return new MediaCatalog(name);
		}
	};
}

var _module = solve();
var catalog = _module.getBookCatalog('John\'s catalog');

var book1 = _module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
var book2 = _module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
catalog.add(book1);
catalog.add(book2);

console.log(catalog.find(book1.id));
//returns book1

console.log(catalog.find({ id: book2.id, genre: 'IT' }));
//returns book2

console.log(catalog.search('js'));
// returns book2

console.log(catalog.search('javascript'));
//returns book1 and book2

console.log(catalog.search('Te sa zeleni'));
//returns []