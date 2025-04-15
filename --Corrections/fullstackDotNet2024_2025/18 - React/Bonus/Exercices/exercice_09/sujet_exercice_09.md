# Exercice React 

## Sujet

Réaliser une application React usant de la centralisation de données au moyen de useContext() pour mettre en commun entre plusieurs composants une "base de données".

## Objectifs

- Vous devrez permettre à des utilisateur de peupler cette base de données au moyen d'une entité de votre choix (contact, animal, single de musique, livres, etc...) qui sera ajoutée à votre contexte par un composant de formulaire.

- Dans un autre composant, vous aurez l'affichage d'un résumé de ces entitées sous la forme de cartes (à la Bootstrap).

- En bas des cartes, vous aurez un bouton Détails qui fera un log en Console de l'élément complet.

## Les composants 

- Formulaire d'Ajout d'Entité : Ce composant doit être réactif aux saisies de l'utilisateur. Par exemple, le bouton de soumission ne doit pas être cliquable tant que le formulaire n'est pas correctement rempli.

- Cartes de Présentation : Ces cartes afficheront un résumé des entités ajoutées à la liste.

- Boutons de Détails : Chaque carte doit être accompagnée d'un bouton "Détails". Ce bouton doit permettre d'afficher en console les détails complets de l'entité correspondante.