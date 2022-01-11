Use HoneyBadgers;

INSERT INTO Actors([Name])
VALUES
	('Jessie Buckley'),
	('Johnny Flynn'),
	('Geraldine James'),
	('Elijah Wood'),
	('Ian McKellen'),
	('Orlando Bloom'),
	('Viggo Mortensen'),
	('Tom Hardy'),
	('Emily Browning'),
	('Taron Egerton'),
	('Kenny Baker'),
	('Jake Lloyd'),
	('George Lucas'),
	('Daniel Radcliffe'),
	('Emma Watson'),
	('Rupert Grin'),
	('Bill Skarsgård'),
	('Jaeden Martell'),
	('Finn Wolfhard');

INSERT INTO Directors([Name])
VALUES
	('Andy Muschietti'),
	('David Yates'),
	('Brian Helgeland'),
	('Peter Jackson'),
	('Michael Pearce');

INSERT INTO Writers([Name])
VALUES
	('Michael Pearce'),
	('J.R.R. Tolkien'),
	('Fran Walsh'),
	('Philippa Boyens'),
	('Brian Helgeland'),
	('John Pearson'),
	('Steve Kloves'),
	('J.K. Rowling'),
	('Chase Palmer'),
	('Cary Joji Fukunaga'),
	('Gary Dauberman');

Insert into MovieWriter(WriterId, MoviesId) Values (1, 1);
Insert into ActorMovie(ActorsId, MoviesId) Values (1, 1), (2, 1), (3, 1);
Insert into MovieWriter(WriterId, MoviesId) Values (2, 2), (3, 2), (4, 2);
Insert into ActorMovie(ActorsId, MoviesId) Values (4, 2), (5, 2), (6, 2);
Insert into MovieWriter(WriterId, MoviesId) Values (2, 3), (3, 3), (4, 3);
Insert into ActorMovie(ActorsId, MoviesId) Values (4, 3), (7, 3), (5, 3);
Insert into MovieWriter(WriterId, MoviesId) Values (5, 4), (6, 4);
Insert into ActorMovie(ActorsId, MoviesId) Values (8, 4), (9, 4), (10, 4);
Insert into ActorMovie(ActorsId, MoviesId) Values (11, 5), (12, 5), (13, 5);
Insert into MovieWriter(WriterId, MoviesId) Values (7, 6), (8, 6);
Insert into ActorMovie(ActorsId, MoviesId) Values (14, 6), (15, 6), (16, 6);
Insert into MovieWriter(WriterId, MoviesId) Values (9, 7), (10, 7), (11, 7);
Insert into ActorMovie(ActorsId, MoviesId) Values (17, 7), (18, 7), (19, 7);