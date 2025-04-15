# Exercice d'Application des Notions de Bases de React

## Sujet
Développer une application front-end avec React qui permet à un utilisateur de gérer des tâches, notamment leur validation et suppression de la liste.

## Composants et Fonctionnalités

### 1. Composant Parent
- Centralise les données des tâches.
- Réceptionne de nouveaux ajouts de tâches et les intègre à la liste.
- Gère les modifications de statut et les demandes de suppression des tâches.
- Utilise `useState()` pour la gestion des tâches.

### 2. Composant de Formulaire
- Permet la création d'une nouvelle tâche.
- Utilise `useRef()` pour optimiser les performances.

### 3. Composants d'Affichage des Tâches
- Affiche les détails des tâches.
- Intègre des boutons pour modifier le statut d'une tâche (finie ou non) et pour sa suppression.

## Détails des Tâches
- Chaque tâche doit posséder un nom, un descriptif, une date, et un statut de complétion (fini ou non).

## Interactions et Gestion de l'État
- Gérer les interactions entre les composants pour une application fluide et réactive.
- Utiliser les hooks React de manière appropriée pour la gestion de l'état et des références.
