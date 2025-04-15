## Partie DML : Manipulation des données (INSERT, UPDATE, DELETE, TRUNCATE)

### Script SQL : Pratique du DML
Ajoutez, modifiez ou supprimez des enregistrements dans les tables existantes pour renforcer la compréhension des manipulations de données.

---

### Questions

#### Niveau 1 : INSERT
1. Ajoutez un nouveau maître nommé "Arya Stark", âgé de 18 ans, habitant à "Winterfell", avec un numéro de téléphone "1231231234".
2. Insérez un nouveau chien nommé "Nymeria" (race : Loup géant, âge : 3 ans, taille : 120 cm, poids : 60 kg) appartenant à Arya Stark.

#### Niveau 2 : UPDATE
3. Modifiez le poids du chien "Milou" pour le mettre à 9 kg.
4. Changez l'adresse de "Daenerys Targaryen" pour "Dragonstone".
5. Mettez à jour tous les chiens sans maître pour les associer à "Sherlock Holmes".

#### Niveau 3 : DELETE
6. Supprimez tous les chiens pesant moins de 5 kg.
7. Supprimez le maître "Waldo Rosenbaum" et tous les chiens qui lui appartiennent.

#### Niveau 4 : TRUNCATE
8. **Attention :** Effectuez un `TRUNCATE` sur la table `Chien` pour supprimer toutes les données de manière rapide, puis réinsérez les données initiales. Vérifiez la structure de la table avant et après.
