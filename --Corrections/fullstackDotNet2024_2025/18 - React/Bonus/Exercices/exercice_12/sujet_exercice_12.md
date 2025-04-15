# Exercice sur les Opérations CRUD avec JSON Server

## Sujet
Développer une application React qui interagit avec un backend JSON Server pour effectuer des opérations CRUD (Create, Read, Update, Delete) sur des todolist.

## Objectifs de l'Exercice

### 1. Configuration de JSON Server
- installer json-server => npm i -g json-server
- lancer le server => json-server [chemin vers le fichier.json] ou json-server --watch bdd.json --port 7777
- Mettre en place un JSON Server qui servira de backend pour stocker les données de todolist.
- Structurer les données de manière à ce que chaque élément de la todolist contienne au minimum un identifiant unique et un titre.

### 2. Création de l'Interface Utilisateur
- Développer une interface utilisateur permettant d'afficher, d'ajouter, de modifier et de supprimer des tâches.

### 3. Fonctionnalités CRUD
- Implémenter les fonctionnalités CRUD dans l'application React :
  - **Create**: Ajouter de nouvelles tâches via un formulaire.
  - **Read**: Afficher la liste des tâches existantes.
  - **Update**: Modifier les détails d'une tâche existante, comme son titre ou son statut.
  - **Delete**: Supprimer une tâche de la liste.

### 4. Interaction avec le JSON Server
- Utiliser des requêtes HTTP pour communiquer avec le JSON Server et effectuer les opérations CRUD.
- Gérer les réponses du serveur et mettre à jour l'interface utilisateur en conséquence.
