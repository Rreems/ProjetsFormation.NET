-- Niveau 1

-- Q1
INSERT INTO
	People
	(first_name, last_name, age, phone_number, [address])
VALUES
	('Arya', 'Stark', 18, '1231231234', 'Winterfell');

SELECT * FROM People WHERE last_name = 'Stark';

-- Q2
INSERT INTO
	Dogs
	(name, breed, age, size, weight, owner_id)
VALUES
	('Nymeria', 'Loup géant', 3, 120, 60, 11);

SELECT TOP 1 * FROM Dogs ORDER BY id DESC;

-- Niveau 2

-- Q3
UPDATE
	Dogs
SET
	weight = 9.0
WHERE
	name = 'Milou';

SELECT * FROM Dogs WHERE name = 'Milou';

-- Q4
UPDATE
	People
SET
	address = 'Dragonstone'
WHERE
	first_name = 'Daenerys'
	AND
	last_name = 'Targaryen';

SELECT * FROM People WHERE last_name = 'Targaryen';

-- Q5
UPDATE
	Dogs
SET
	owner_id = (SELECT id FROM People WHERE first_name = 'Sherlock' AND last_name = 'Holmes')
WHERE
	owner_id IS NULL;

-- Niveau 3

-- Q6
DELETE FROM
	Dogs
WHERE
	weight < 5.0;

-- Q7
DELETE FROM
	Dogs
WHERE
	owner_id = (SELECT id FROM People WHERE first_name = 'Waldo' AND last_name = 'Rosembaum');

DELETE FROM
	People
WHERE
	first_name = 'Waldo' 
	AND 
	last_name = 'Rosembaum';

-- Niveau 4

SELECT * FROM Dogs;

TRUNCATE TABLE Dogs;

-- DELETE FROM Dogs; ne réinitialise pas la séquence des Ids, moins optimisé

INSERT INTO Dogs (name, breed, age, size, weight, owner_id)
VALUES 
   ('Milou', 'Fox Terrier', 5, 30.0, 8.0, 1),
   ('Idefix', 'Dogmatix', 4, 25.0, 6.0, 2), 
   ('Watson', 'Bulldog', 6, 60.0, 30.0, 3), 
   ('Hercules', 'Pitbull', 3, 60.0, 28.0, 4), 
   ('Gandalf', 'Great Dane', 8, 80.0, 50.0, 5),
   ('Chewie', 'Malamute', 7, 70.0, 40.0, 6), 
   ('Buck', 'Saint Bernard', 6, 70.0, 50.0, 7),
   ('Drogo', 'Dobermann', 5, 55.0, 35.0, 8), 
   ('Baggins', 'Shiba Inu', 4, 30.0, 10.0, NULL),
   ('Waldo', 'Chihuahua', 3, 20.0, 2.5, 10), 
   ('Rex', 'Chihuahua', 3, 20.0, 3.0, NULL), 
   ('Pepette', 'Rottweiler', 6, 60.0, 40.0, 5), 
   ('Princesse', 'Dobermann', 4, 50.0, 30.0, 5), 
   ('Rex', 'Dalmatian', 2, 45.0, 25.0, 5), 
   ('Trixie', 'Poodle', 5, 30.0, 12.0, 5), 
   ('Nina', 'Boxer', 4, 50.0, 35.0, NULL), 
   ('Pikachu', 'Corgi', 2, 25.0, 10.0, 8), 
   ('Rolo', 'Dachshund', 3, 28.0, 8.5, NULL), 
   ('Fifi', 'Maltese', 4, 25.0, 6.0, NULL), 
   ('Charlie', 'Beagle', 6, 40.0, 15.0, NULL), 
   ('Max', 'Labrador', 5, 55.0, 30.0, NULL), 
   ('Biscuit', 'Shih Tzu', 2, 25.0, 6.0, 8),
   ('Daisy', 'Pug', 3, 35.0, 10.0, NULL), 
   ('Oscar', 'Terrier', 4, 28.0, 8.0, NULL), 
   ('Nala', 'Pitbull', 4, 50.0, 30.0, NULL); 