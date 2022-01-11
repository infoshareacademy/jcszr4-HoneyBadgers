Use HoneyBadgers;

INSERT INTO Genres([Name])
VALUES
    ('Action'),
    ('Adventure'),
	('Animation'),
	('Biography'),
    ('Comedy'),
	('Crime'),
	('Drama'),
	('Documentary'),
	('Fantasy'),
	('Historical'),
	('Historical fiction'),
	('Horror'),
	('Romance'),
	('Mystery'),
	('Science fiction'),
	('Thriller'),
	('Western');

INSERT INTO Movies(Title, [Year], Released, Runtime, Director, Writer, Actors, Plot, Country, ImdbRating, Poster, [Language], BoxOffice, Production,ViewsNumber)
VALUES
	(
		'Beast',
		2017,
		convert(datetime,'11 May 2018',5),
		'107 min',
		'Michael Pearce',
		'Michael Pearce',
		'Jessie Buckley, Johnny Flynn, Geraldine James',
		'A troubled woman living in an isolated community finds herself pulled between the control of her oppressive family and the allure of a secretive outsider suspected of a series of brutal murders.',
		'United Kingdom',
		6.8,
		'https://m.media-amazon.com/images/M/MV5BMWJhNTM1MWYtZTllNy00MDRhLTlmZGQtMWY5MmQwN2FjOGU2XkEyXkFqcGdeQXVyODAzODU1NDQ@._V1_SX300.jpg',
		'English',
		'$800,365',
		'Les Films Séville, Roadside Attractions, BFI Film Fund, British Film Institute, Film4, Entertainment One',
		69
	),
	(
		'The Lord of the Rings: The Fellowship of the Ring',
		2001,
		convert(datetime,'19 Dec 2001',5),
		'178 min',
		'Peter Jackson',
		'J.R.R. Tolkien, Fran Walsh, Philippa Boyens',
		'Elijah Wood, Ian McKellen, Orlando Bloom',
		'A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.',
		'New Zealand, United States',
		8.8,
		'https://m.media-amazon.com/images/M/MV5BN2EyZjM3NzUtNWUzMi00MTgxLWI0NTctMzY4M2VlOTdjZWRiXkEyXkFqcGdeQXVyNDUzOTQ5MjY@._V1_SX300.jpg',
		'English, Sindarin',
		'$315,710,750',
		'New Line Cinema, WingNut Films, Saul Zaentz Company',
		1000000
	),
	(
		'The Lord of the Rings: The Return of the King',
		2003,
		convert(datetime,'17 Dec 2003',5),
		'201 min',
		'Peter Jackson',
		'J.R.R. Tolkien, Fran Walsh, Philippa Boyens',
		'Elijah Wood, Viggo Mortensen, Ian McKellen',
		'Gandalf and Aragorn lead the World of Men against Sauron' + char(39) + 's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.',
		'New Zealand, United States',
		8.9,
		'https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg',
		'English, Quenya, Old English, Sindarin',
		'$377,845,905',
		'New Line Cinema, Saul Zaentz Company',
		1000001
	),
	(
		'Legend',
		2015,
		convert(datetime,'20 Nov 2015',5),
		'132 min',
		'Brian Helgeland',
		'Brian Helgeland, John Pearson',
		'Tom Hardy, Emily Browning, Taron Egerton',
		'Identical twin gangsters Ronald and Reginald Kray terrorize London during the 1960s',
		'United Kingdom, France, United States',
		6.9,
		'https://m.media-amazon.com/images/M/MV5BMjE0MjkyODQ3NF5BMl5BanBnXkFtZTgwNDM1OTk1NjE@._V1_SX300.jpg',
		'English',
		'$1,872,994',
		'Working Title Films',
		3459
	),
	(
		'Star Wars: Episode I - The Phantom Menace - Webisodes',
		2001,
		convert(datetime,'16 Oct 2001',5),
		'58 min',
		null,
		null,
		'Kenny Baker, Jake Lloyd, George Lucas',
		'A 12-part web documentary, which originally appeared on the official website is composed of mainly used rough footage from the set. A wide variety of topics were covered, from Lucas' + char(39) + 's very ...',
		'USA',
		6.9,
		'https://m.media-amazon.com/images/M/MV5BYTdjMzdkNTMtNDdkZS00MmRkLTgxZmEtMmVhMjZiYzU3YjcwXkEyXkFqcGdeQXVyNzg5OTk2OA@@._V1_SX300.jpg',
		'English',
		null,
		null,
		14
	),
	(
		'Harry Potter and the Deathly Hallows: Part 2',
		2011,
		convert(datetime,'15 Jul 2011',5),
		'130 min',
		'David Yates',
		'Steve Kloves, J.K. Rowling',
		'Daniel Radcliffe, Emma Watson, Rupert Grint',
		'Harry, Ron, and Hermione search for Voldemort'+ char(39) + 's remaining Horcruxes in their effort to destroy the Dark Lord as the final battle rages on at Hogwarts.',
		'United Kingdom, United States',
		8.1,
		'https://m.media-amazon.com/images/M/MV5BMGVmMWNiMDktYjQ0Mi00MWIxLTk0N2UtN2ZlYTdkN2IzNDNlXkEyXkFqcGdeQXVyODE5NzE3OTE@._V1_SX300.jpg',
		'English',
		'$381,409,310',
		'Warner Bros., Moving Picture Company, Heyday Films',
		84599
	),
	(
		'It',
		2017,
		convert(datetime,'08 Sep 2017',5),
		'135 min',
		'Andy Muschietti',
		'Chase Palmer, Cary Joji Fukunaga, Gary Dauberman',
		'Bill Skarsgård, Jaeden Martell, Finn Wolfhard',
		'In the summer of 1989, a group of bullied kids band together to destroy a shape-shifting monster, which disguises itself as a clown and preys on the children of Derry, their small Maine town.',
		'United States, Canada',
		7.3,
		'https://m.media-amazon.com/images/M/MV5BZDVkZmI0YzAtNzdjYi00ZjhhLWE1ODEtMWMzMWMzNDA0NmQ4XkEyXkFqcGdeQXVyNzYzODM3Mzg@._V1_SX300.jpg',
		'English, Hebrew',
		'$328,828,874',
		'Vertigo Entertainment, RatPac-Dune Entertainment, Lin Pictures',
		1256
	);

Insert into GenreMovie(GenreId, MoviesId) Values (6, 1), (7, 1), (14, 1);
Insert into GenreMovie(GenreId, MoviesId) Values (1, 2), (2, 2), (7, 2);
Insert into GenreMovie(GenreId, MoviesId) Values (1, 3), (2, 3), (7, 3);
Insert into GenreMovie(GenreId, MoviesId) Values (4, 4), (6, 4), (7, 4);
Insert into GenreMovie(GenreId, MoviesId) Values (8, 5);
Insert into GenreMovie(GenreId, MoviesId) Values (2, 6), (7, 6), (9, 6);
Insert into GenreMovie(GenreId, MoviesId) Values (12, 7);

INSERT INTO Ratings([Source], [Value], MovieId)
VALUES
	('Internet Movie Database', '6.8/10', 1),
	('Rotten Tomatoes', '92%', 1),
	('Metacritic', '74/100', 1),
	('Internet Movie Database', '8.8/10', 2),
	('Rotten Tomatoes', '91%', 2),
	('Metacritic', '92/100', 2),
	('Internet Movie Database', '8.9/10', 3),
	('Rotten Tomatoes', '93%', 3),
	('Metacritic', '94/100', 3),
	('Internet Movie Database', '6.9/10', 4),
	('Rotten Tomatoes', '61%', 4),
	('Metacritic', '55/100', 4),
	('Internet Movie Database', '6.9/10', 5),
	('Internet Movie Database', '8.1/10', 6),
	('Rotten Tomatoes', '96%', 6),
	('Metacritic', '85/100', 6),
	('Internet Movie Database', '7.3/10', 7),
	('Rotten Tomatoes', '86%', 7),
	('Metacritic', '69/100', 7);

insert into Users(FirstName, LastName, Email, [Password])
Values
	('Dean', 'Pennington', 'deanpennington@koogle.com', 'Ts+OLTQpwIFKluu4Rivm2Q=='),
	('Amanda', 'Garcia', 'amandagarcia@cosmosis.com', 'Ts+OLTQpwIFKluu4Rivm2Q=='),
	('White', 'Matthews', 'whitematthews@jasper.com', 'Ts+OLTQpwIFKluu4Rivm2Q=='),
	('Maria', 'Chandler', 'mariachandler@musaphics.com', 'Ts+OLTQpwIFKluu4Rivm2Q=='),
	('Sherri', 'Cochran', 'sherricochran@halap.com', 'Ts+OLTQpwIFKluu4Rivm2Q=='),
	('John', 'Briggs', 'johnbriggs@terrasys.com', 'Ts+OLTQpwIFKluu4Rivm2Q=='),
	('Yates', 'Chambers', 'yateschambers@hivedom.com', 'Ts+OLTQpwIFKluu4Rivm2Q=='),
	('Victoria', 'Stout', 'victoriastout@pyramax.com', 'Ts+OLTQpwIFKluu4Rivm2Q=='),
	('Larsen', 'Langley', 'larsenlangley@kage.com', 'Ts+OLTQpwIFKluu4Rivm2Q=='),
	('Sawyer', 'Cobb', 'sawyercobb@nurplex.com', 'Ts+OLTQpwIFKluu4Rivm2Q=='),
	('Petra', 'Davis', 'petradavis@geekmosis.com', 'Ts+OLTQpwIFKluu4Rivm2Q=='),
	('Thelma', 'Conrad', 'thelmaconrad@eyeris.com', 'Ts+OLTQpwIFKluu4Rivm2Q=='),
	('Alisa', 'Mercer', 'alisamercer@magneato.com', 'Ts+OLTQpwIFKluu4Rivm2Q=='),
	('Calderon', 'Mckay', 'calderonmckay@terragen.com', 'Ts+OLTQpwIFKluu4Rivm2Q=='),
	('Admin', 'Admin', 'admin@admin.test', 'Ts+OLTQpwIFKluu4Rivm2Q==');

Insert into FavoriteMovies(MovieId, UserId) Values (1, 1);
Insert into FavoriteMovies(MovieId, UserId) Values (5, 2);
Insert into FavoriteMovies(MovieId, UserId) Values (5, 3);
Insert into FavoriteMovies(MovieId, UserId) Values (5, 4);
Insert into FavoriteMovies(MovieId, UserId) Values (5, 5);
Insert into FavoriteMovies(MovieId, UserId) Values (2, 1);
Insert into FavoriteMovies(MovieId, UserId) Values (2, 2);
Insert into FavoriteMovies(MovieId, UserId) Values (2, 3);
Insert into FavoriteMovies(MovieId, UserId) Values (2, 4);
Insert into FavoriteMovies(MovieId, UserId) Values (2, 5);
Insert into FavoriteMovies(MovieId, UserId) Values (2, 6);
Insert into FavoriteMovies(MovieId, UserId) Values (2, 7);
Insert into FavoriteMovies(MovieId, UserId) Values (3, 1);
Insert into FavoriteMovies(MovieId, UserId) Values (3, 2);
Insert into FavoriteMovies(MovieId, UserId) Values (3, 3);
Insert into FavoriteMovies(MovieId, UserId) Values (3, 4);
Insert into FavoriteMovies(MovieId, UserId) Values (3, 5);
Insert into FavoriteMovies(MovieId, UserId) Values (3, 6);
Insert into FavoriteMovies(MovieId, UserId) Values (3, 7);
Insert into FavoriteMovies(MovieId, UserId) Values (4, 2);
Insert into FavoriteMovies(MovieId, UserId) Values (6, 2);
Insert into FavoriteMovies(MovieId, UserId) Values (7, 2);