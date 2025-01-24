-- lister les bases
SELECT name, database_id, create_date
FROM sys.databases;

-- USE ma_db;

SELECT name 
FROM sys.tables;


-- Tout slectionner dans la table Users
SELECT * FROM [Users];
SELECT * FROM Users;

--SELECT * FROM [basededonne].[Table];

SELECT first_name FROM Users;
SELECT first_name, last_name FROM Users;


SELECT first_name, last_name, job FROM Users;


SELECT * 
FROM Users
WHERE age > 40;


SELECT first_name, last_name, age
FROM Users
WHERE age < 30;


SELECT first_name, last_name, age 
FROM Users
WHERE first_name = 'Daniel'; -- pas de guillemets doubles


--1. Dans une première requête, récupérez tous les utilisateurs dont le métier n'est pas développeur
SELECT * 
FROM Users
WHERE job != 'Developer';

--2. Dans une seconde requête, récupérez tous les utilisateurs dont le prénom est John.
SELECT * 
FROM Users
WHERE first_name = 'John';

--3. Dans une dernière requête, récupérez tous les utilisateurs dont le salaire est supérieur ou égal à 3000.
SELECT * 
FROM Users
WHERE salary >= 3000;


SELECT first_name, last_name, job
FROM Users
WHERE first_name = 'David' AND job = 'Doctor';


SELECT first_name, last_name, job
FROM Users
WHERE first_name = 'David' OR job = 'Doctor';


-- 1. Dans un première requête, récupérez tous les utilisateurs dont l'âge est inférieur à 30ans ou supérieur et égal à 35ans.
SELECT *
FROM [Users]
WHERE age < 30 OR age >= 35;


-- 2. Récupérez ensuite tous les utilisateurs dont le métier est professeur et le salaire est supérieur à 2600.
SELECT *
FROM [Users]
WHERE job = 'teacher' AND salary > 2600;


SELECT first_name, last_name, birth_location
FROM Users
WHERE NOT birth_location = 'New York';


SELECT first_name, last_name, birth_location, job
FROM Users
WHERE birth_location = 'New York' AND (job = 'Teacher' OR job = 'Developer');

SELECT
 *
FROM
 Users
WHERE
 birth_location = 'New York'
 AND (salary >= 3000 AND salary <= 3500)
 AND NOT (job = 'Doctor' OR job = 'Lawyer');
 --AND job != 'Doctor' AND job != 'Lawyer';


SELECT DISTINCT job
FROM Users
WHERE birth_location = 'New York';

SELECT DISTINCT job
FROM Users;

SELECT DISTINCT job, first_name
FROM Users;


SELECT first_name, last_name, birth_location
FROM Users
WHERE birth_location IN ('Paris', 'London');
--WHERE birth_location = 'Paris' OR birth_location = 'London';

SELECT first_name, last_name, birth_location
FROM Users
WHERE birth_location NOT IN ('Paris', 'London');


SELECT first_name, last_name, age
FROM Users
WHERE age BETWEEN 30 AND 35;


SELECT first_name, last_name, age
FROM Users
WHERE age NOT BETWEEN 30 AND 35;


--1. Sélectionnez tous les enregistrements où le métier est "Engineer"
SELECT *
FROM Users
WHERE job = 'Engineer';

--2. Sélectionnez les prénoms et les noms de famille des utilisateurs nés à Londres, Paris ou Berlin
SELECT first_name, last_name
FROM Users
WHERE birth_location IN ('London','Paris','Berlin');

--3. Sélectionnez les utilisateurs dont l'âge est compris entre 25 et 35 ans
SELECT *
FROM Users
WHERE age BETWEEN 25 AND 35;

--4. Sélectionnez les utilisateurs qui sont à la fois des développeurs et dont le salaire est supérieur à 2500€
SELECT *
FROM Users
WHERE job = 'Developer' AND salary > 2500;


SELECT first_name, age
FROM users
ORDER BY age;

SELECT first_name, age
FROM users
WHERE age < 50
ORDER BY age;


SELECT first_name, age
FROM users
ORDER BY age ASC; -- ASC est innutile (indicatif)

SELECT first_name, age
FROM users
ORDER BY age DESC;

SELECT *
FROM users
ORDER BY last_name DESC, age ASC;


-- TOP (les N premiers

SELECT TOP 5 first_name, last_name, salary
FROM Users;

SELECT TOP 3 first_name, last_name, salary
FROM Users
ORDER BY salary DESC;


-- Paging avec offset
-- Page 1 de 3 entrées
SELECT first_name, last_name, salary
FROM Users
ORDER BY salary DESC
OFFSET (0*3) ROWS
FETCH NEXT 3 ROWS ONLY;

-- Page 2 de 3 entrées
SELECT first_name, last_name, salary
FROM Users
ORDER BY salary DESC
OFFSET (1*3) ROWS
FETCH NEXT 3 ROWS ONLY;

-- Page 3 de 3 entrées
SELECT first_name, last_name, salary
FROM Users
ORDER BY salary DESC
OFFSET (2*3) ROWS
FETCH NEXT 3 ROWS ONLY;


--1. Sélectionnez les cinq utilisateurs les plus âgés de la table "Users", triés par ordre décroissant d'âge.
SELECT TOP 5 *
FROM Users
ORDER BY age DESC;

SELECT *
FROM Users
ORDER BY age DESC
OFFSET 0 ROWS
FETCH NEXT 5 ROWS ONLY;

--2. Affichez les enregistrements 6 à 10 triés par ordre alphabétique du prénom.
SELECT *
FROM Users
ORDER BY first_name ASC
OFFSET 0 ROWS
FETCH NEXT 5 ROWS ONLY;

--3. Sélectionnez les trois utilisateurs ayant les salaires les plus élevés de la table "Users", triés par ordre décroissant de salaire.
SELECT TOP 3 *
FROM Users
ORDER BY salary DESC;


SELECT MIN(age)
FROM users;
SELECT MAX(age)
FROM users;


SELECT MAX(last_name) AS last_name
FROM users;

SELECT first_name AS 'prénoms', last_name AS noms
FROM users;


SELECT COUNT(*) AS total_users
FROM users;


SELECT SUM(salary) AS total_salary_without_devs
FROM users
WHERE job != 'Developer';

SELECT AVG(salary) AS average_salary_devs
FROM users
WHERE job = 'Developer';


--1. Quel est le salaire minimum parmi tous les utilisateurs ?
SELECT MIN(salary) AS min_salary
FROM Users;


--2. Quel est l'âge maximum parmi les utilisateurs ayant le métier "Engineer" ?
SELECT MIN(age) AS max_age
FROM Users
WHERE job = 'Engineer';

--3. Trouvez le salaire moyen des utilisateurs dont le métier est "Teacher".
SELECT AVG(salary) AS avg_salary
FROM Users
WHERE job = 'Teacher';

--4. Trouvez le montant total des salaires de tous les utilisateurs.
SELECT SUM(salary) AS sum_salary
FROM Users;


SELECT birth_location, SUM(salary) AS sum_sal
FROM Users
GROUP BY birth_location;

SELECT birth_location, SUM(salary),MIN(salary),MAX(salary),AVG(salary), AVG(age)
FROM Users
GROUP BY birth_location;


SELECT birth_location, AVG(salary)
FROM Users
GROUP BY birth_location
ORDER BY AVG(salary) DESC;

SELECT birth_location, AVG(salary) AS avg_sal
FROM Users
GROUP BY birth_location
ORDER BY avg_sal DESC;


SELECT last_name, age, SUM(salary) AS avg_sal
FROM Users
GROUP BY last_name, age;


SELECT birth_location, AVG(salary) AS average_salary
FROM Users
GROUP BY birth_location
HAVING AVG(salary) > 2500;


SELECT last_name, age, SUM(salary),MIN(salary),MAX(salary)
FROM Users
GROUP BY last_name, age
HAVING COUNT(*) > 1;


SELECT *
FROM Users
WHERE birth_location LIKE 'P%';

SELECT *
FROM Users
WHERE birth_location LIKE 'Lo%';

SELECT *
FROM Users
WHERE birth_location LIKE '%s';

SELECT *
FROM Users
WHERE birth_location LIKE '%o%';

SELECT *
FROM Users
WHERE birth_location LIKE '_o%';

SELECT *
FROM Users
WHERE birth_location LIKE '______';

SELECT *
FROM Users
WHERE first_name LIKE 'D%';

SELECT *
FROM Users
WHERE last_name LIKE '%son';

SELECT *
FROM Users
WHERE first_name LIKE '_____' ;

SELECT *
FROM Users
WHERE job LIKE '%Doctor%';


SELECT first_name, last_name, salary
FROM Users
WHERE salary > (SELECT AVG(salary) FROM Users);


SELECT first_name, last_name, salary
FROM Users
WHERE salary = (SELECT MAX(salary) FROM Users); -- ORDER BY et TOP seront plus optimisés ici



SELECT prenom --, last_name, salary
FROM (SELECT first_name AS prenom FROM Users) AS users_bis;