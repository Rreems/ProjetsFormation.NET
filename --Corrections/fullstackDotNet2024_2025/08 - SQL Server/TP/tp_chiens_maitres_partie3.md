
## Partie DDL : Manipulation des structures (CREATE, ALTER, DROP)

### Script SQL : Ajout de nouvelles tables

1. **Table `Chat` (pour les chats)**
   - Créez une table nommée `Chat` avec les colonnes suivantes :
     - `id` : Identifiant unique (clé primaire, type `INT` avec auto-incrémentation).
     - `name` : Nom du chat (`NVARCHAR(50)`).
     - `age` : Âge du chat (`INT`).
     - `color` : Couleur du chat (`NVARCHAR(50)`).
     - `id_maitre` : Identifiant du maître (`INT`), clé étrangère vers `Personne`.

2. **Table `RelationChatChien` (relations entre chats et chiens)**
   - Créez une table nommée `RelationChatChien` pour gérer les relations entre les chats et les chiens, avec les colonnes suivantes :
     - `id_chat` : Identifiant du chat (clé étrangère vers `Chat`).
     - `id_chien` : Identifiant du chien (clé étrangère vers `Chien`).
     - `relation_type` : Type de relation (`NVARCHAR(50)`), valeurs possibles : `loves`, `hates`, `neutral`.

---

### Questions

#### Niveau 1 : CREATE
1. Créez la table `Chat` avec les spécifications ci-dessus.
2. Créez la table `RelationChatChien` pour gérer les relations entre chats et chiens.

#### Niveau 2 : INSERT et relations
3. Ajoutez deux chats nommés "Garfield" (âge : 5 ans, couleur : orange, maître : Gandalf) et "Salem" (âge : 7 ans, couleur : noir, maître : Frodo Baggins).
4. Ajoutez des relations dans `RelationChatChien` :
   - "Garfield" aime "Milou".
   - "Salem" déteste "Idefix".
   - "Garfield" est neutre avec "Hercules".

#### Niveau 3 : ALTER
5. Ajoutez une colonne `gender` (type `NVARCHAR(10)`) à la table `Personne` pour indiquer le genre du maître (valeurs possibles : `Male`, `Female`, `Other`).
6. Modifiez la colonne `size` dans la table `Chien` pour qu'elle soit de type `DECIMAL(6,2)`.

#### Niveau 4 : DROP
7. Supprimez la table `RelationChatChien`.
8. Supprimez la colonne `weight` de la table `Chien`.

---

### Questions bonus (DDL + DML)
1. Listez tous les chats et leurs maîtres respectifs.
2. Affichez toutes les relations entre les chats et les chiens, y compris leurs types de relations.
3. Modifiez la relation entre "Garfield" et "Hercules" pour qu'elle devienne `loves`.
