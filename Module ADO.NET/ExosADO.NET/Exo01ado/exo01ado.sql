
SELECT name FROM master.dbo.sysdatabases

USE ContactDB;


--CREATE TABLE etudiants (
--	id int IDENTITY(1,1) PRIMARY KEY,
--	nom NVARCHAR(50) NOT NULL,
--	prenom NVARCHAR(50) NOT NULL,
--	numClasse INT NOT NULL,
--	dateDiplome DATE NOT NULL
--);


SELECT *
FROM   information_schema.tables
WHERE  table_type='BASE TABLE';



SELECT * 
FROM etudiants

INSERT INTO etudiants(nom, prenom, numClasse, dateDiplome) 
VALUES ('Rob' , 'Bob' , 5 , '2015-05-22');