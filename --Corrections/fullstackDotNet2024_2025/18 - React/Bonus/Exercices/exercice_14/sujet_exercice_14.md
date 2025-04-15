# Utilisation de l'API Open Library

## Description :

Vous allez créer une application web simple permettant d'afficher des livres depuis l'API Open Library et d'afficher les détails du livre sélectionné.

## Objectif :

- Effectuer des appels à une API pour récupérer des données sur les livres.
- Permettre à l'utilisateur de cliquer sur la couverture d'un livre pour afficher ses détails sur une nouvelle page en utilisant le routing.

## Instructions :

### Les composants :

- BookList : Ce composant affichera une liste de livres disponibles. Chaque livre de la liste doit être cliquable et rediriger vers la page de détails du livre.
- BookDetails : Ce composant affichera les détails d'un livre spécifique, tels que le titre, l'auteur, la date de publication, la description et l'image de couverture.

### Utilisation de l'API Open Library :

- Utilisez l'API Open Library (Documentation : https://openlibrary.org/dev/docs/api/books) pour récupérer les données sur les livres.
- Utilisez l'endpoint /subjects/{subject}.json pour obtenir une liste de livres sur un sujet spécifique. Vous pouvez choisir un sujet de votre choix, par exemple, "science_fiction" (https://openlibrary.org/subjects/science_fiction.json?limit=100).
- Utilisez l'endpoint /works/{olid}.json pour obtenir les détails d'un livre spécifique en fournissant son OLID (Open Library ID) (exemple : https://openlibrary.org/works/${olid}.json).

### Routing :

- Implémentez le routing pour permettre la navigation entre la liste des livres et les détails d'un livre.

### Affichage des données :

- Dans le composant BookList, affichez une liste de livres avec leur image de couverture et leur titre.
- Lorsque l'utilisateur clique sur un livre dans la liste, le composant BookDetails doit être chargé avec les détails de ce livre.
- Dans le composant BookDetails, affichez les détails du livre sélectionné, y compris son titre, son auteur, sa date de publication, sa description et son image de couverture.