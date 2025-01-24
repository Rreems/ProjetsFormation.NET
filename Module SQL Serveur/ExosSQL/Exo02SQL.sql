
--**Instructions :** Utilisez les clauses GROUP BY et HAVING pour répondre aux questions suivantes.

--1. **Affichez le nombre d'utilisateurs par lieu de naissance, mais ne montrez que les lieux avec plus 
--d'un' utilisateur.**
--SELECT birth_location, COUNT(*)
--FROM [Users]
--GROUP BY birth_location
--HAVING COUNT(*) > 1



--2. **Sélectionnez la profession et la moyenne des salaires pour chaque profession, mais ne montrez que
-- celles avec une moyenne de salaire supérieure à 2500.**
--SELECT job, AVG(salary) as MoyenneSalaire
--FROM [Users]
--GROUP BY job
--HAVING AVG(salary) > 2500


--3. **Affichez la somme des salaires pour chaque lieu de naissance, mais ne montrez que les lieux dont la 
-- somme des salaires est supérieure à 5000.**
--SELECT birth_location, SUM(salary) as SommeSalaires
--FROM [Users]
--GROUP BY birth_location
--HAVING SUM(salary) > 5000


--4. **Sélectionnez la date de naissance et le nombre d'utilisateurs nés à chaque date, mais ne montrez que 
-- les dates où il y a plus d'un utilisateur né.**
--SELECT birth_date , COUNT(*)
--FROM [Users]
--GROUP BY birth_date
--HAVING COUNT(*) > 1


--5. **Affichez la profession, le lieu de naissance, et le salaire maximum pour chaque profession et lieu, 
-- mais ne montrez que les résultats où le salaire maximum est supérieur à 3000.**
SELECT job, birth_location, MAX(salary) as max_salary
FROM [Users]
GROUP BY job, birth_location
HAVING MAX(salary) > 3000
