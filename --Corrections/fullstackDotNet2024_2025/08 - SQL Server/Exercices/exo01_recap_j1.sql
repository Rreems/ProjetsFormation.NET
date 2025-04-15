-- 1. Affichez toutes les colonnes de la table "Users" pour tous les utilisateurs.
SELECT * FROM Users;

-- 2. Sélectionnez les noms et prénoms des utilisateurs nés à New York ou à Paris.
SELECT first_name, last_name 
FROM Users 
WHERE birth_location IN ('New York', 'Paris');

-- 3. Affichez les utilisateurs dont le travail est "Developer" ou "Designer".
SELECT * 
FROM Users 
WHERE job IN ('Developer', 'Designer');
--WHERE job = 'Developer' OR job = 'Designer';

-- 4. Sélectionnez les utilisateurs dont l'âge est supérieur à 30 ans.
SELECT * 
FROM Users 
WHERE age > 30;

-- 5. Affichez les utilisateurs dont le salaire est compris entre 2500 et 3000.
SELECT * 
FROM Users 
WHERE salary BETWEEN 2500 AND 3000;
--WHERE salary >= 2500 AND salary <= 3000;

-- 6. Sélectionnez les utilisateurs dont le travail n'est ni "Developer" ni "Designer".
SELECT * 
FROM Users 
WHERE job NOT IN ('Developer', 'Designer');

-- 7. Affichez les utilisateurs triés par ordre alphabétique du nom de famille, puis du prénom.
SELECT * 
FROM Users 
ORDER BY last_name, first_name;

-- 8. Sélectionnez les utilisateurs nés avant l'année 1990.
SELECT * 
FROM Users 
--WHERE YEAR(birth_date) < 1990;
WHERE birth_date < '1990-01-01';

-- 9. Affichez les utilisateurs dont le lieu de naissance est "London" ou "Berlin" et dont le travail est "Designer".
SELECT * 
FROM Users 
--WHERE (birth_location = 'London' OR birth_location = 'Berlin') 
WHERE birth_location IN ('London', 'Berlin') 
  AND job = 'Designer';

-- 10. Sélectionnez les 10 utilisateurs avec les salaires les plus élevés.
SELECT TOP 10 * 
FROM Users 
ORDER BY salary DESC;

-- 11. Affichez les noms, prénoms et âges des utilisateurs nés entre 1980 et 1990.
SELECT first_name, last_name, age, birth_date
FROM Users 
--WHERE YEAR(birth_date) BETWEEN 1980 AND 1990;
WHERE birth_date BETWEEN '1980-01-01' AND '1990-01-01';

-- 12. Sélectionnez les utilisateurs par ordre décroissant d'âge.
SELECT * 
FROM Users 
ORDER BY age DESC;

-- 13. Sélectionnez les utilisateurs dont le travail est "Doctor" et dont le salaire est supérieur à 3000.
SELECT * 
FROM Users 
WHERE job = 'Doctor' 
  AND salary > 3000;

-- 14. Affichez les utilisateurs triés par lieu de naissance, puis par salaire.
SELECT * 
FROM Users 
ORDER BY birth_location, salary;

-- 15. Sélectionnez les utilisateurs nés à Paris et dont le travail est "Lawyer".
SELECT * 
FROM Users 
WHERE birth_location = 'Paris' 
  AND job = 'Lawyer';

-- 16. Affichez le salaire le plus bas de tous les utilisateurs en utilisant un alias.
SELECT MIN(salary) AS lowest_salary 
FROM Users;

-- 17. Sélectionnez les utilisateurs nés après l'année 1985 et dont le travail est "Engineer".
SELECT * 
FROM Users 
--WHERE YEAR(birth_date) > 1985 
WHERE birth_date > '1985-01-01'
  AND job = 'Engineer';

-- 18. Affichez les utilisateurs dont le prénom est "John" et le nom de famille est "Doe".
SELECT * 
FROM Users 
WHERE first_name = 'John' 
  AND last_name = 'Doe';

-- 19. Sélectionnez les 6 utilisateurs dont le salaire est le plus bas en omettant les trois premiers résultats.
SELECT * 
FROM Users 
ORDER BY salary ASC 
OFFSET 3 ROWS FETCH NEXT 6 ROWS ONLY;

-- 20. Affichez les utilisateurs par ordre croissant d'âge, limités aux 5 premiers.
SELECT TOP 5 * 
FROM Users 
ORDER BY age ASC;
