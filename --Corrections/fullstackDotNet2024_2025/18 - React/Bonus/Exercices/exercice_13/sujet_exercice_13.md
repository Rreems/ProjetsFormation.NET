# Exercice : Création d'une liste de pays

## Objectif :

Le but de cet exercice est de créer une application React qui utilise l'API REST Countries pour afficher une liste de pays.

## Tâches :

### Configuration du projet :
  - Initialisez un projet React.
  - Installez Axios pour effectuer des requêtes HTTP vers l'API REST Countries.
  - Créez un composant CountryList pour afficher la liste des pays.

### Récupération des données :
  - Utilisez Axios pour effectuer une requête vers l'URL de l'API REST Countries (https://restcountries.com/v3.1/all).


### Affichage des données :
  - Une fois les données chargées, parcourez le tableau des pays et affichez :
    - Le nom du pay en **français**.
    - La capitale
    - la région
    - le drapeau en png
    - la population (nombre)

### Fonctionnalité :
  - Ajoutez la fonctionnalité de recherche pour permettre aux utilisateurs de rechercher des pays par leur nom.

  npm create vite@latest