--### Niveau 1 : Questions basiques
--1. Sélectionnez tous les chiens avec leur nom, leur race et leur poids.
--SELECT name, breed, weight
--FROM Chien

--2. Listez tous les propriétaires (prénom et nom).
--SELECT first_name, last_name
--FROM Personne

--3. Récupérez les chiens qui n'ont pas de maître.
--SELECT *
--FROM Chien
--WHERE id_maitre IS NULL

--4. Sélectionnez tous les chiens de race "Labrador".
--SELECT *
--FROM Chien
--WHERE breed = 'Labrador'



--### Niveau 2 : Jointures simples (INNER JOIN)
--5. Affichez le nom des chiens avec le prénom et le nom de leur maître.
--SELECT Chien.name AS ChienName, Personne.first_name, Personne.last_name
--FROM Chien
--	INNER JOIN Personne ON Chien.id_maitre = Personne.id

--6. Récupérez les maîtres qui possèdent un chien pesant plus de 20 kg.
--SELECT DISTINCT Personne.first_name, Personne.last_name--, Chien.weight
--FROM Chien
--	INNER JOIN Personne ON Chien.id_maitre = Personne.id
--WHERE Chien.weight > 20


--### Niveau 3 : LEFT JOIN
--7. Affichez tous les propriétaires et les chiens qu'ils possèdent, y compris les propriétaires sans chien.
--SELECT Personne.* , Chien.*
--FROM Personne
--	INNER JOIN Chien
--	ON Chien.id_maitre = Personne.id


--8. Listez tous les chiens, avec leurs maîtres s'ils en ont, sinon affichez "No Owner".
--SELECT Chien.* , 
--	CASE  WHEN Personne.first_name IS NULL THEN 'No Owner' ELSE Personne.first_name END AS OwnerName,
--	Personne.last_name
--FROM Chien
--	LEFT JOIN Personne
--	ON Chien.id_maitre = Personne.id

--SELECT Chien.* , 
--	COALESCE(Personne.first_name, 'No owner') AS OwnerName,  -- Verif si NULL -> remplace si oui
--	Personne.last_name
--FROM Chien
--	LEFT JOIN Personne
--	ON Chien.id_maitre = Personne.id



--### Niveau 4 : FULL OUTER JOIN
--9. Récupérez tous les chiens et tous les maîtres, même ceux sans correspondance.
--SELECT Chien.* , Personne.*
--FROM Chien 
--	FULL JOIN Personne
--	ON Chien.id_maitre = Personne.id



--### Niveau 5 : Filtrage avancé
--10. Affichez les chiens dont le poids est supérieur à 10 kg mais inférieur à 30 kg.
--SELECT *
--FROM Chien
--WHERE Chien.weight BETWEEN 10 AND 30

--11. Récupérez les chiens de maîtres habitant dans la ville "123 Main St".
--SELECT Chien.*
--FROM Chien
--	INNER JOIN Personne
--	ON Chien.id_maitre = Personne.id
--WHERE Personne.address = '123 Main St'
----WHERE Personne.address = '123 Rue du Temple'



--### Niveau 6 : Agrégats et GROUP BY
--12. Affichez le nombre de chiens pour chaque maître.
--SELECT Personne.first_name, Personne.last_name, COUNT(Chien.id) AS NombreDeChien
--FROM Chien
--	INNER JOIN Personne
--	ON Chien.id_maitre = Personne.id
--GROUP BY Personne.first_name, Personne.last_name

--13. Calculez le poids total des chiens appartenant à chaque maître.
--SELECT Personne.first_name, Personne.last_name, SUM(Chien.weight) AS PoidsTotalDeChiens
--FROM Chien
--	INNER JOIN Personne
--	ON Chien.id_maitre = Personne.id
--GROUP BY Personne.first_name, Personne.last_name



--### Niveau 7 : Sous-requêtes
--14. Récupérez les maîtres qui possèdent le chien le plus lourd.
--SELECT * 
--FROM Personne
--WHERE Personne.id = 
--	(SELECT TOP 1 Chien.id_maitre
--	FROM Chien
--	ORDER BY Chien.weight
--	)


--SELECT Personne.* , ChienLourd.weight
--FROM Personne
--	RIGHT JOIN 
--	(SELECT TOP 1 *
--	FROM Chien
--	ORDER BY Chien.weight DESC
--	) AS ChienLourd
--	ON Personne.id = ChienLourd.id_maitre


--15. Affichez les chiens qui ont un maître dont l'âge est supérieur à 40 ans.
--SELECT Chien.*  
--FROM Chien
--WHERE Chien.id_maitre IN
--	( SELECT Personne.id
--		FROM Personne
--		WHERE Personne.age > 40)



--### Niveau 8 : Cas complexes
--16. Listez les maîtres n'ayant pas de chien.
--SELECT Personne.*
--FROM Personne
--WHERE Personne.id NOT IN
--	(SELECT Chien.id_maitre
--	 FROM Chien
--	 WHERE NOT id_maitre IS NULL)

--17. Affichez la race la plus courante parmi les chiens.
--SELECT TOP 1 breed, COUNT(*) AS NombreChiens
--FROM Chien
--GROUP BY breed
--ORDER BY COUNT(*) DESC


--18. Listez tous les maîtres qui possèdent au moins deux chiens.
--SELECT *
--FROM Personne
--WHERE Personne.id IN 
--	(SELECT Chien.id_maitre
--	 FROM Chien 
--	 GROUP BY Chien.id_maitre
--	 HAVING COUNT(Chien.id_maitre) >= 2
--	 )



--### Niveau 9 : FULL OUTER JOIN combiné
--19. Récupérez une liste combinée de chiens sans maîtres et de maîtres sans chiens.
--SELECT *
--FROM CHIEN
--	FULL OUTER JOIN PERSONNE
--	ON ID_MAITRE = PERSONNE.ID 
--	WHERE id_maitre IS NULL 
--	OR personne.id IS NULL
		
		


--20. Affichez le maître et ses chien associés avec somme de leur tailles respectives 
--(taille du maître et des chiens).
SELECT Personne.id , 
	   Personne.first_name , 
	   SUM(COALESCE(Chien.weight, 0) + Personne.age) AS SommePoidsAge
FROM personne
	LEFT JOIN chien ON personne.id = chien.id_maitre
GROUP BY Personne.id , Personne.first_name
ORDER BY  SommePoidsAge




