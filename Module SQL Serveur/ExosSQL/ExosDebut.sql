
--SELECT * FROM [Users] ;

-- Zuper commentaire  -- Add comment: Ctrl + k + c   ; Uncomment: Ctrl + K + U

-- Lister les BDD:
--SELECT name
--FROM sys.tables

---- 1 - User dont le métier n'est pas Développeur
--SELECT *
--FROM Users
--WHERE NOT job = 'Developer' ;

---- 2. Dans une seconde requête, récupérez tous les utilisateurs dont le prénom est John.
--SELECT first_name, last_name, job
--FROM Users
--WHERE first_name = 'John' ;

---- 3. Dans une dernière requête, récupérez tous les utilisateurs dont le salaire est supérieur ou égal à 3000.
--SELECT first_name, last_name, job, salary
--FROM Users
--WHERE salary >= 3000 ;

-- EXOS NOT & OR
--1. Dans un première requête, récupérez tous les utilisateurs dont l'âge est inférieur à 30ans 
					--ou supérieur et égal à 35ans.
--SELECT DISTINCT job 
--FROM [Users]
--WHERE age < 30  OR age >= 35;

--2. Récupérez ensuite tous les utilisateurs dont le métier est professeur et le salaire est supérieur à 2600.
--SELECT * 
--FROM [Users]
--WHERE job = 'Teacher' 
--	AND salary > 2600 ;

--Créez une requête qui permet de récupérer toutes les personnes qui
--sont nées à New York, dont le salaire est compris entre 3000 et 3500
--(compris) et qui ne sont ni docteur ni avocat.
--* Toutes les conditions doivent tenir en une seule requête
--* Les trois opérateurs logiques : AND, OR et NOT doivent être utilisés.
--SELECT *
--FROM [Users]
--WHERE  birth_location = 'New York' 
--	AND (salary > 3000 AND salary <3500)
--	AND NOT (job= 'Lawyer' OR job = 'Doctor' );


--Dans notre table Users, en utilisant au moins pour une requête IN et
--pour une autre BETWEEN:
--1. Sélectionnez tous les enregistrements où le métier est "Engineer"
--SELECT * 
--FROM [Users]
--WHERE job IN ('Engineer');

--2. Sélectionnez les prénoms et les noms de famille des utilisateurs
--nés à Londres, Paris ou Berlin
--SELECT first_name, last_name, birth_location
--FROM [Users]
--WHERE birth_location IN ('London', 'Paris' , 'Berlin');

--3. Sélectionnez les utilisateurs dont l'âge est compris entre 25 et 35ans
--SELECT *
--FROM [Users]
--WHERE age BETWEEN 25 AND 35 ;

--4. Sélectionnez les utilisateurs qui sont à la fois des développeurs et
--dont le salaire est supérieur à 2500€
--SELECT *
--FROM [Users]
--WHERE job IN ('Developer') AND salary > 2500 ;



--  OFFSET ET LIMIT
--1. Sélectionnez les cinq utilisateurs les plus âgés de la table "Users",
--triés par ordre décroissant d'âge.
--SELECT TOP 5 *
--FROM [Users]
--ORDER BY age DESC

 
--2. Affichez les enregistrements 6 à 10 triés par ordre alphabétique du
--prénom.
--SELECT tab.*
--FROM 
--	(SELECT * FROM [Users] 
--	ORDER BY id 
--	OFFSET 5 ROWS
--	FETCH NEXT 5 ROWS ONLY ) AS tab
--ORDER BY first_name



--3. Sélectionnez les trois utilisateurs ayant les salaires les plus élevés
--de la table "Users", triés par ordre décroissant de salaire
--SELECT *
--FROM [Users]
--ORDER BY salary DESC
--OFFSET 0 ROWS
--FETCH NEXT 3 ROWS ONLY



-- AGREGATION
--1. Quel est le salaire minimum parmi tous les utilisateurs ?
--SELECT MIN(salary)
--FROM [Users]

----2. Quel est l'âge maximum parmi les utilisateurs ayant le métier "Engineer" ?
--SELECT MIN(age)
--FROM [Users]
--WHERE job = 'Engineer'


----3. Trouvez le salaire moyen des utilisateurs dont le métier est "Teacher".
--SELECT AVG(salary)
--FROM [Users]
--WHERE job = 'Teacher'

----4. Trouvez le montant total des salaires de tous les utilisateurs
--SELECT SUM(salary)
--FROM [Users]






-- Exercices Fin J1
----1. Affichez toutes les colonnes de la table "Users" pour tous les utilisateurs.
--SELECT *
--FROM [Users]


----2. Sélectionnez les noms et prénoms des utilisateurs nés à New York ou à Paris.
--SELECT *
--FROM [Users]
--WHERE birth_location IN ('Paris' , 'New York')

----3. Affichez les utilisateurs dont le travail est "Developer" ou "Designer".
--SELECT *
--FROM [Users]
--WHERE job IN ('Developer','Designer')

----4. Sélectionnez les utilisateurs dont l'âge est supérieur à 30 ans.
--SELECT *
--FROM [Users]
--WHERE age > 30

----5. Affichez les utilisateurs dont le salaire est compris entre 2500 et 3000.
--SELECT *
--FROM [Users]
--WHERE salary BETWEEN 2500 AND 3000

----6. Sélectionnez les utilisateurs dont le travail n'est ni "Developer" ni "Designer".
--SELECT *
--FROM [Users]
--WHERE NOT job IN ('Developer' , 'Designer')

----7. Affichez les utilisateurs triés par ordre alphabétique du nom de famille, puis du prénom.
--SELECT *
--FROM [Users]
--ORDER BY last_name, first_name

----8. Sélectionnez les utilisateurs nés avant l'année 1990.
--SELECT *
--FROM [Users]
--WHERE birth_date < '1990-01-01'

----9. Affichez les utilisateurs dont le lieu de naissance est "London" ou "Berlin" et dont le travail est "Designer".
--SELECT *
--FROM [Users]
--WHERE birth_location IN ('London', 'Berlin')
--	AND job = 'designer'

----10. Sélectionnez les 10 utilisateurs avec les salaires les plus élevés.
--SELECT TOP 10 *
--FROM [Users]
--ORDER BY salary DESC

----11. Affichez les noms, prénoms et âges des utilisateurs nés entre 1980 et 1990.
--SELECT last_name, first_name, age , birth_date
--FROM [Users]
--WHERE birth_date BETWEEN '1980-12-31' AND  '1990-01-01' 

----12. Sélectionnez les utilisateurs par ordre décroissant d'âge.
--SELECT *
--FROM [Users]
--ORDER BY age DESC

----13. Sélectionnez les utilisateurs dont le travail est "Doctor" et dont le salaire est supérieur à 3000.
--SELECT *
--FROM [Users]
--WHERE job = 'Doctor' AND salary > 2000

----14. Affichez les utilisateurs triés par lieu de naissance, puis par salaire.
--SELECT *
--FROM [Users]
--ORDER BY birth_location , salary


----15. Sélectionnez les utilisateurs nés à Paris et dont le travail est "Lawyer".
--SELECT *
--FROM [Users]
--WHERE birth_location = 'Paris' AND job='Lawyer' ;


----16. Affichez le salaire le plus bas de tout les utilisateurs en utilisant un alias.
--SELECT TOP 1 first_name, last_name, salary AS salaireMinimum
--FROM [Users]
--ORDER BY salary 


----17. Sélectionnez les utilisateurs nés après l'année 1985 et dont le travail est "Engineer".
--SELECT *
--FROM [Users]
--WHERE job = 'Engineer' AND birth_date > '1985-12-31'


----18. Affichez les utilisateurs dont le prénom est "John" et le nom de famille est "Doe".
--SELECT *
--FROM [Users]
--WHERE last_name = 'Doe' AND first_name = 'John'


----19. Sélectionnez les 6 utilisateurs dont le salaire est le plus bas en omettant les trois premiers résultats.
--SELECT *
--FROM [Users]
--ORDER BY salary
--	OFFSET 3 ROWS
--	FETCH NEXT 6 ROWS ONLY ;


----20. Affichez les utilisateurs par ordre croissant d'âge, limités aux 5 premiers.
SELECT *
FROM [Users]
ORDER BY age
	OFFSET 0 ROWS
	FETCH NEXT 5 ROWS ONLY ;