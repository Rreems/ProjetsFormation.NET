INSERT INTO Users (first_name, last_name, birth_date, job, birth_location, age, salary)
VALUES
    ('John', 'Doe',  '1995-05-12','Developer', 'New York', 21, 1500),
    ('John', 'Doe',  '1995-05-12','Developer', 'New York', 21, 1500),
    ('John', 'Doe',  '1995-05-12','Developer', 'New York', 21, 1500),
    ('Leandre', 'Vaucher', '1984-08-17', 'Developer', 'Amiens', 40, 3000),
    ('Guillaume', 'Mairesse',  '1975-12-21','Developer', 'Amiens', 70, 50);

SELECT * FROM Users;

-- on �vitera de pr�ciser les cl�s primaires (id),
-- si la table est bien faite, elle est g�n�r�e
-- de plus on risque de cr�er un id qui rentre en conflit avec un autre existant

-- si on ne pr�cise pas les colonnes => toutes les colones dans l'ordre y compris l'id !

UPDATE Users
SET first_name = 'Guillaume', last_name = 'Mairesse',  birth_date = '1975-12-21',job = 'Developer', birth_location = 'Amiens', age = 70, salary = 50; -- > pas de WHERE => tout le monde devient Guillaume !


UPDATE Users
SET salary = salary * 1.1;


SELECT * FROM Users;

UPDATE Users
SET job = 'Developer C#'
WHERE birth_location = 'Amiens';

-- Mettre � jour la colonne "age" avec les �ges calcul�s � partir de la date de naissance
UPDATE Users
SET age = DATEDIFF(YEAR, birth_date, GETDATE())  -- diff�rence de l'ann�e => birth_date - Maintenant => r�cup�rer l'ann�e
    - CASE                                       -- moins (une autre valeur) => ici CASE est un ternaire
        WHEN MONTH(birth_date) > MONTH(GETDATE()) 
             OR (MONTH(birth_date) = MONTH(GETDATE()) AND DAY(birth_date) > DAY(GETDATE())) 
        THEN 1 --anniversaire pas encore pass� => moins 1
        ELSE 0 --anniversaire pass� => moins 0
      END;
-- Ce calcul d�termine l'�ge exact en ann�es en soustrayant 1 
-- si l'anniversaire de l'utilisateur cette ann�e n'est pas encore pass�, 
-- sinon il utilise simplement la diff�rence brute d'ann�es.


-- Mettre � jour la colonne "salary" avec des valeurs al�atoires entre 1200 et 3500
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

