## Script SQL : Création des tables **Personne** et **Chien**

Voici le script SQL pour créer les tables **Personne** et **Chien**, avec une relation `One-to-Many` (un chien peut avoir un maître, mais ce n'est pas obligatoire) :

```sql
-- Table for people
CREATE TABLE People (
   id INT PRIMARY KEY IDENTITY(1,1), -- Unique ID for each person
   first_name NVARCHAR(50) NOT NULL, -- First name of the person
   last_name NVARCHAR(50) NOT NULL, -- Last name of the person
   age INT, -- Age of the person
   phone_number NVARCHAR(20), -- Phone number of the person
   address NVARCHAR(100), -- Address of the person
);

-- Table for dogs
CREATE TABLE Dogs (
   id INT PRIMARY KEY IDENTITY(1,1), -- Unique ID for each dog
   name NVARCHAR(50) NOT NULL, -- Name of the dog
   breed NVARCHAR(50), -- Breed of the dog
   age INT, -- Age of the dog
   size DECIMAL(5,2), -- Size (in cm) of the dog
   weight DECIMAL(5,2), -- Weight (in kg) of the dog
   owner_id INT, -- Foreign key referencing Person
   FOREIGN KEY (owner_id) REFERENCES People(id)
);
```

---

## Données initiales pour les tables **Personne** et **Chien**

Voici un jeu de données réaliste et varié pour démontrer les jointures.

```sql
INSERT INTO People (first_name, last_name, age, phone_number, address)
VALUES 
   ('Tintin', 'Dupont', 30, '1234567890', '123 Rue du Temple'),
   ('Asterix', 'Gaulois', 40, '9876543210', '456 Village Gaulois'),
   ('Sherlock', 'Holmes', 45, '5554443333', '123 Main St'),
   ('Hercule', 'Poirot', 50, '4443332222', '11 Rue du Luxembourg'),
   ('Gandalf', 'Le Gris', 1000, '1112223333', 'Hobbiton'),
   ('Luke', 'Skywalker', 28, '9988776655', 'Tatooine'),
   ('Harry', 'Potter', 35, '5556667777', '4 Privet Drive'),
   ('Daenerys', 'Targaryen', 32, '8887776666', 'Meereen'),
   ('Frodo', 'Baggins', 33, '1237894560', 'Bag End'),
   ('Waldo', 'Rosenbaum', 50, '7778889999', 'Nowhere Street');

INSERT INTO Dogs (name, breed, age, size, weight, owner_id)
VALUES 
   ('Milou', 'Fox Terrier', 5, 30.0, 8.0, 1),
   ('Idefix', 'Dogmatix', 4, 25.0, 6.0, 2), 
   ('Watson', 'Bulldog', 6, 60.0, 30.0, 3), 
   ('Hercules', 'Pitbull', 3, 60.0, 28.0, 4), 
   ('Gandalf', 'Great Dane', 8, 80.0, 50.0, 5),
   ('Chewie', 'Malamute', 7, 70.0, 40.0, 6), 
   ('Buck', 'Saint Bernard', 6, 70.0, 50.0, 7),
   ('Drogo', 'Dobermann', 5, 55.0, 35.0, 8), 
   ('Baggins', 'Shiba Inu', 4, 30.0, 10.0, NULL),
   ('Waldo', 'Chihuahua', 3, 20.0, 2.5, 10), 
   ('Rex', 'Chihuahua', 3, 20.0, 3.0, NULL), 
   ('Pepette', 'Rottweiler', 6, 60.0, 40.0, 5), 
   ('Princesse', 'Dobermann', 4, 50.0, 30.0, 5), 
   ('Rex', 'Dalmatian', 2, 45.0, 25.0, 5), 
   ('Trixie', 'Poodle', 5, 30.0, 12.0, 5), 
   ('Nina', 'Boxer', 4, 50.0, 35.0, NULL), 
   ('Pikachu', 'Corgi', 2, 25.0, 10.0, 8), 
   ('Rolo', 'Dachshund', 3, 28.0, 8.5, NULL), 
   ('Fifi', 'Maltese', 4, 25.0, 6.0, NULL), 
   ('Charlie', 'Beagle', 6, 40.0, 15.0, NULL), 
   ('Max', 'Labrador', 5, 55.0, 30.0, NULL), 
   ('Biscuit', 'Shih Tzu', 2, 25.0, 6.0, 8),
   ('Daisy', 'Pug', 3, 35.0, 10.0, NULL), 
   ('Oscar', 'Terrier', 4, 28.0, 8.0, NULL), 
   ('Nala', 'Pitbull', 4, 50.0, 30.0, NULL); 

```

---

## Questions

### Niveau 1 : Questions basiques
1. Sélectionnez tous les chiens avec leur nom, leur race et leur poids.
2. Listez tous les propriétaires (prénom et nom).
3. Récupérez les chiens qui n'ont pas de maître.
4. Sélectionnez tous les chiens de race "Labrador".

### Niveau 2 : Jointures simples (INNER JOIN)
5. Affichez le nom des chiens avec le prénom et le nom de leur maître.
6. Récupérez les maîtres qui possèdent un chien pesant plus de 20 kg.

### Niveau 3 : LEFT JOIN
7. Affichez tous les propriétaires et les chiens qu'ils possèdent, y compris les propriétaires sans chien.
8. Listez tous les chiens, avec leurs maîtres s'ils en ont, sinon affichez "No Owner".

### Niveau 4 : FULL OUTER JOIN
9. Récupérez tous les chiens et tous les maîtres, même ceux sans correspondance.

### Niveau 5 : Filtrage avancé
10. Affichez les chiens dont le poids est supérieur à 10 kg mais inférieur à 30 kg.
11. Récupérez les chiens de maîtres habitant dans la ville "123 Main St".

### Niveau 6 : Agrégats et GROUP BY
12. Affichez le nombre de chiens pour chaque maître.
13. Calculez le poids total des chiens appartenant à chaque maître.

### Niveau 7 : Sous-requêtes
14. Récupérez les maîtres qui possèdent le chien le plus lourd.
15. Affichez les chiens qui ont un maître dont l'âge est supérieur à 40 ans.

### Niveau 8 : Cas complexes
16. Listez les maîtres n'ayant pas de chien.
17. Affichez la race la plus courante parmi les chiens.
18. Listez tous les maîtres qui possèdent au moins deux chiens.

### Niveau 9 : FULL OUTER JOIN combiné
19. Récupérez une liste combinée de chiens sans maîtres et de maîtres sans chiens.
20. Affichez le maître et ses chien associés avec somme de leur tailles respectives (taille du maître et des chiens).
