INSERT INTO Users (first_name, last_name, birth_date, job, birth_location, age, salary)
VALUES
    ('John', 'Doe',  '1995-05-12','Developer', 'New York', 21, 1500),
    ('John', 'Doe',  '1995-05-12','Developer', 'New York', 21, 1500),
    ('John', 'Doe',  '1995-05-12','Developer', 'New York', 21, 1500),
    ('Leandre', 'Vaucher', '1984-08-17', 'Developer', 'Amiens', 40, 3000),
    ('Guillaume', 'Mairesse',  '1975-12-21','Developer', 'Amiens', 70, 50);

SELECT * FROM Users;

-- on évitera de préciser les clés primaires (id),
-- si la table est bien faite, elle est générée
-- de plus on risque de créer un id qui rentre en conflit avec un autre existant

-- si on ne précise pas les colonnes => toutes les colones dans l'ordre y compris l'id !

UPDATE Users
SET first_name = 'Guillaume', last_name = 'Mairesse',  birth_date = '1975-12-21',job = 'Developer', birth_location = 'Amiens', age = 70, salary = 50; -- > pas de WHERE => tout le monde devient Guillaume !


UPDATE Users
SET salary = salary * 1.1;


SELECT * FROM Users;

UPDATE Users
SET job = 'Developer C#'
WHERE birth_location = 'Amiens';

-- Mettre à jour la colonne "age" avec les âges calculés à partir de la date de naissance
UPDATE Users
SET age = DATEDIFF(YEAR, birth_date, GETDATE())  -- différence de l'année => birth_date - Maintenant => récupérer l'année
    - CASE                                       -- moins (une autre valeur) => ici CASE est un ternaire
        WHEN MONTH(birth_date) > MONTH(GETDATE()) 
             OR (MONTH(birth_date) = MONTH(GETDATE()) AND DAY(birth_date) > DAY(GETDATE())) 
        THEN 1 --anniversaire pas encore passé => moins 1
        ELSE 0 --anniversaire passé => moins 0
      END;
-- Ce calcul détermine l'âge exact en années en soustrayant 1 
-- si l'anniversaire de l'utilisateur cette année n'est pas encore passé, 
-- sinon il utilise simplement la différence brute d'années.


-- Mettre à jour la colonne "salary" avec des valeurs aléatoires entre 1200 et 3500
UPDATE Users
SET salary = FLOOR(1200 + RAND(CHECKSUM(NEWID())) * (3500 - 1200));


DELETE FROM Users
WHERE id != 1 AND first_name = 'John' AND last_name = 'Doe';


SELECT * FROM Users;



CREATE TABLE Students (
    student_id INT PRIMARY KEY IDENTITY(1,1),
    first_name NVARCHAR(50) NOT NULL,
    last_name NVARCHAR(50) NOT NULL,
    age INT,
    grade NVARCHAR(10)
);


INSERT INTO Students (first_name,last_name,age,grade)
VALUES
    ('Maria', 'Rodriguez', 21, 'B'),
    ('Ahmed', 'Khan', 19, 'A'),
    ('Emily', 'Baker', 22, 'C');

UPDATE Students 
SET grade = 'A'
WHERE first_name = 'Maria';

UPDATE Students 
SET age = age + 1;

DELETE Students
WHERE  first_name = 'Emily';

DELETE Students
WHERE  age < 20;

TRUNCATE TABLE Students;

