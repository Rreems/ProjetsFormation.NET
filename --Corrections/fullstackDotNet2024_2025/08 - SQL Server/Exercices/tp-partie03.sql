
-- Q1
CREATE TABLE Cats (
	id INT IDENTITY(1,1),
	name NVARCHAR(50) NOT NULL,
	age INT NOT NULL,
	color NVARCHAR(50),
	owner_id INT,
	CONSTRAINT pk_cats_id PRIMARY KEY(id),
	CONSTRAINT fk_cats_owner_id FOREIGN KEY(owner_id) REFERENCES People(id)
);
GO

-- Q2
CREATE TABLE RelationshipCatsDogs (
	cat_id INT NOT NULL,
	dog_id INT NOT NULL,
	relation_type NVARCHAR(50) NOT NULL,
	CONSTRAINT ch_relation_type CHECK(relation_type IN('loves', 'hates', 'neutral')),
	CONSTRAINT pk_relationship_cats_dogs PRIMARY KEY(cat_id, dog_id),
	CONSTRAINT fk_relationship_cats_dogs_cat_id FOREIGN KEY(cat_id) REFERENCES Cats(id),
	CONSTRAINT fk_relationship_cats_dogs_dog_id FOREIGN KEY(dog_id) REFERENCES Dogs(id)
);
GO

-- Q3
INSERT INTO Cats
	([name], age, color, owner_id)
VALUES
	('Garfield', 5, 'orange', (SELECT id FROM People WHERE first_name = 'Gandalf')),
	('Salem', 7, 'noir', (SELECT id FROM People WHERE first_name = 'Frodo'));
GO

-- Q4
SELECT id, [name] FROM Dogs UNION SELECT id, [name] FROM Cats;

INSERT INTO RelationshipCatsDogs
	(cat_id, dog_id, relation_type)
VALUES
	(1, 1, 'loves'),
	(2, 2, 'hates'),
	(1, 4, 'neutral');
GO

-- Q5
ALTER TABLE People
ADD gender NVARCHAR(10);
GO

ALTER TABLE People
ADD CONSTRAINT ch_gender CHECK(gender IN('Male', 'Female', 'Other'));
GO

-- Q6
ALTER TABLE Dogs
ALTER COLUMN size DECIMAL(6,2);
GO

-- Q7
DROP TABLE RelationshipCatsDogs;
GO

-- Q8
ALTER TABLE Dogs
DROP COLUMN [weight];
GO

-- BONUS 

-- Q1
SELECT
	[name],
	[color],
	[first_name],
	[last_name]
FROM
	Cats
INNER JOIN
	People ON People.id = Cats.owner_id;
GO

-- Q2
SELECT
	d.[name] AS Dogs,
	r.[relation_type] AS Relation,
	c.[name] AS Cats
FROM
	Dogs d
INNER JOIN
	RelationshipCatsDogs r ON r.dog_id = d.id
INNER JOIN
	Cats c ON r.cat_id = c.id;
GO

-- Q3
UPDATE RelationshipCatsDogs
SET relation_type = 'loves'
WHERE cat_id = 1 AND dog_id = 4;
GO