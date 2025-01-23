
-- Supprimer la table Users si elle existe déjà
IF OBJECT_ID('Users', 'U') IS NOT NULL
    DROP TABLE Users;
GO

-- Créer la table Users
CREATE TABLE Users (
    id INT IDENTITY(1,1) PRIMARY KEY, -- Identifiant unique auto-incrémenté
    first_name NVARCHAR(50) NOT NULL, -- Prénom de l'utilisateur
    last_name NVARCHAR(50) NOT NULL,  -- Nom de famille
    job NVARCHAR(100),                -- Métier ou poste
    birth_date DATE,                  -- Date de naissance
    birth_location NVARCHAR(100)      -- Lieu de naissance
);
GO

-- Insertion de données aléatoires dans la table Users
INSERT INTO Users (first_name, last_name, job, birth_date, birth_location)
VALUES
    ('John', 'Doe', 'Developer', '1995-05-12', 'New York'),
    ('Alice', 'Smith', 'Designer', '1988-09-28', 'London'),
    ('Michael', 'Johnson', 'Engineer', '1977-02-05', 'Los Angeles'),
    ('Emily', 'Brown', 'Teacher', '1992-04-18', 'Paris'),
    ('David', 'Lee', 'Doctor', '1985-11-30', 'Tokyo'),
    ('Sarah', 'Wilson', 'Lawyer', '1990-06-08', 'Sydney'),
    ('Daniel', 'Anderson', 'Developer', '1983-12-21', 'Toronto'),
    ('Jessica', 'Taylor', 'Engineer', '1991-10-15', 'Berlin'),
    ('Christopher', 'Moore', 'Designer', '1997-01-04', 'Rome'),
    ('Olivia', 'Jackson', 'Teacher', '1994-08-22', 'Moscow'),
    ('James', 'Doe', 'Engineer', '1987-03-12', 'New York'),
    ('Sophia', 'Smith', 'Developer', '1993-07-28', 'London'),
    ('Emma', 'Johnson', 'Designer', '1980-09-05', 'Los Angeles'),
    ('Daniel', 'Brown', 'Doctor', '1992-02-18', 'Paris'),
    ('David', 'Lee', 'Lawyer', '1985-11-30', 'Tokyo');
GO

-- Ajouter les colonnes "age" et "salary" à la table "Users"
ALTER TABLE Users
ADD age INT,
    salary INT NOT NULL DEFAULT 0;
GO

-- Mettre à jour la colonne "age" avec les âges calculés à partir de la date de naissance
UPDATE Users
SET age = DATEDIFF(YEAR, birth_date, GETDATE())
    - CASE 
        WHEN MONTH(birth_date) > MONTH(GETDATE()) 
             OR (MONTH(birth_date) = MONTH(GETDATE()) AND DAY(birth_date) > DAY(GETDATE())) 
        THEN 1 
        ELSE 0 
      END;
GO
-- Ce calcul détermine l'âge exact en années en soustrayant 1 
-- si l'anniversaire de l'utilisateur cette année n'est pas encore passé, 
-- sinon il utilise simplement la différence brute d'années.

-- Mettre à jour la colonne "salary" avec des valeurs aléatoires entre 1200 et 3500
UPDATE Users
SET salary = FLOOR(1200 + RAND(CHECKSUM(NEWID())) * (3500 - 1200));
GO
