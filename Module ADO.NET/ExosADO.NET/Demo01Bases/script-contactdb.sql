-- sqllocaldb c demo01ado
-- sqllocaldb s demo01ado
-- sqlcmd -S (localdb)\demo01ado
-- CREATE DATABASE ContactDB;
-- exit

CREATE DATABASE ContactDB;
GO

USE ContactDB;
GO

CREATE TABLE personne (
	id INT IDENTITY(1,1) PRIMARY KEY,
	prenom NVARCHAR(50) NOT NULL,
	nom NVARCHAR(50) NOT NULL,
	email VARCHAR(255) NOT NULL
);
GO

INSERT INTO
	personne
	(prenom, nom, email)
VALUES
	('Jean', 'Michel', 'jean@michel.fr');
GO