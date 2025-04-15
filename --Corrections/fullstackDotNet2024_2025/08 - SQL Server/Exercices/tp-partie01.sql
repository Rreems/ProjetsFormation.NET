-- Niveau 1

-- Q1
SELECT
	[name],
	[breed],
	[weight]
FROM
	Dogs;

-- Q2
SELECT
	first_name,
	last_name
FROM
	people;

-- Q3
SELECT
	[name]
FROM
	Dogs
WHERE
	owner_id IS NULL;

-- Q4
SELECT
	[name],
	breed
FROM
	Dogs
WHERE
	breed = 'Labrador';

-- Niveau 2

-- Q5
SELECT
	d.[name],
	p.[first_name],
	p.[last_name]
FROM
	Dogs d
INNER JOIN
	People p ON p.id = d.owner_id;

-- Q6
SELECT
	p.first_name,
	p.last_name,
	d.[weight]
FROM
	People p
INNER JOIN
	Dogs d ON p.id = d.owner_id
WHERE
	d.weight > 20;

-- Niveau 3

-- Q7
SELECT
	p.first_name,
	p.last_name,
	d.[name]
FROM
	People p
LEFT JOIN
	Dogs d ON p.id = d.owner_id;

-- Q8
SELECT
	d.[name],
	COALESCE(p.first_name, 'No owner') AS first_name,
	COALESCE(p.last_name, 'No owner') AS last_name
FROM
	Dogs d
LEFT JOIN
	People p ON p.id = d.owner_id;

-- Niveau 4

-- Q9
SELECT
	d.[name],
	p.first_name,
	p.last_name
FROM
	Dogs d
FULL OUTER JOIN
	People p ON p.id = d.owner_id;

-- Niveau 5

-- Q10
SELECT
	[name],
	[weight]
FROM
	Dogs
WHERE
	[weight] BETWEEN 10 AND 30;

-- Q11
SELECT
	d.[name],
	p.[first_name],
	p.[address]
FROM
	Dogs d
INNER JOIN
	People p ON p.id = d.owner_id
WHERE
	p.[address] = '123 Main St';

-- Niveau 6

-- Q12
SELECT
	CONCAT_WS(' ', p.first_name, p.last_name) AS Maitre,
	COUNT(d.[name]) AS NombreChien
FROM
	Dogs d
INNER JOIN
	People p ON p.id = d.owner_id
GROUP BY
	p.first_name, p.last_name
ORDER BY
	NombreChien DESC;

-- Q13
SELECT
	CONCAT_WS(' ', p.first_name, p.last_name) AS Maitre,
	SUM(d.weight) AS PoidsTotal
FROM
	Dogs d
INNER JOIN
	People p ON p.id = d.owner_id
GROUP BY
	p.first_name, p.last_name
ORDER BY
	PoidsTotal DESC;

-- Niveau 7

-- Q14
SELECT
	p.first_name,
	p.last_name
FROM
	People p
INNER JOIN
	Dogs d ON d.owner_id = p.id
WHERE
	d.[weight] = (SELECT MAX([weight]) FROM Dogs);

-- Q15
SELECT
	[name]
FROM
	Dogs
WHERE
	owner_id IN (SELECT id FROM people WHERE age > 40);

-- Niveau 8

-- Q16
SELECT
	first_name,
	last_name
FROM
	People
WHERE
	id NOT IN (SELECT owner_id FROM Dogs WHERE owner_id IS NOT NULL);

-- Q17
SELECT
	TOP 1 breed,
	COUNT(*) AS breed_count
FROM
	Dogs
GROUP BY
	breed
ORDER BY
	breed_count DESC, breed;

-- Q18
SELECT
	first_name,
	last_name,
	COUNT(Dogs.name) AS NombreChien
FROM
	People
INNER JOIN
	Dogs ON Dogs.owner_id = People.id
GROUP BY
	first_name, last_name
HAVING
	(COUNT(Dogs.name) >= 2);

-- Niveau 9

-- Q19
SELECT
	d.[name],
	p.first_name,
	p.last_name
FROM
	Dogs d
FULL OUTER JOIN
	People p ON p.id = d.owner_id
WHERE
	d.owner_id IS NULL OR p.id IS NULL;

-- Q20
SELECT
	p.first_name,
	p.last_name,
	(p.age + SUM(COALESCE(d.age, 0))) AS SommeAge
FROM
	People p
LEFT JOIN
	Dogs d ON p.id = d.owner_id
GROUP BY
	p.first_name,
	p.last_name,
	p.age
ORDER BY
	SommeAge DESC;