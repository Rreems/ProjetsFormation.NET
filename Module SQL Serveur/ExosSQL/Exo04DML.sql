--CREATE TABLE Students (
-- student_id INT PRIMARY KEY,
-- first_name VARCHAR(50) NOT NULL,
-- last_name VARCHAR(50) NOT NULL,
-- age INT,
-- grade VARCHAR(10)
--);




--Partie 1: INSERT INTO
--Ajoutez trois nouveaux �tudiants � la table :
--Pr�nom: Maria, Nom: Rodriguez, �ge: 21, Note: B
--Pr�nom: Ahmed, Nom: Khan, �ge: 19, Note: A
--Pr�nom: Emily, Nom: Baker, �ge: 22, Note: C

--INSERT INTO Students (student_id, first_name, last_name, age, grade)
--VALUES (1, 'Maria', 'Rodriguez', 21, 'B'),
--		(2, 'Ahmed', 'Khan', 21, 'B'),
--		(3, 'Emily', 'Baker', 22, 'C')



--Partie 2: UPDATE
--Mettez � jour la note de l'�tudiant ayant le pr�nom "Maria" pour la
--changer de "B" � "A".
--Augmentez l'�ge de tous les �tudiants de 1 an.
--Exercice: R�sum� sur le langage DML

--UPDATE Students
--SET Grade = 'A'
--WHERE first_name = 'Maria'

--UPDATE Students
--SET age = age+1



--Partie 3: DELETE
--Supprimez l'�tudiant ayant le pr�nom "Emily" de la table.
--Supprimez tous les �tudiants dont l'�ge est inf�rieur � 20 ans.

--DELETE FROM Students
--WHERE first_name = 'Emily'


--DELETE FROM Students
--WHERE age < 20

select * from students

--Partie 4: TRUNCATE
--Videz compl�tement la table "Students" en utilisant la commande
--TRUNCATE
TRUNCATE TABLE Students