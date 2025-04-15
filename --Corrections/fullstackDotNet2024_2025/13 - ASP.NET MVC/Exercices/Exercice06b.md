### Exercice 06 - ASP.NET Core

**Objectif:** Mettre en place les différentes notions d'ASP.NET Core (Controller, View, Model, EF Core, ...)

**Sujet:**
Réaliser une liste de films permettant aux utilisateurs d’avoir accès à une manipulation et un stockage de films pour prévoir leur soirées ciné :

**Structure:**
- Ces films auront un statut particulier : Visionné / A voir, modifiable en un clic (pas de formulaire)
- Ces films pourront être visualisés, supprimées, édités, créés, avec visionnage des informations et / ou confirmation avant les changements
- On stockera ces films dans une base de données avec EFCore (utiliser le Repository Pattern)
- L'application n'aura qu'un seul controller "MovieController.cs" et 2 Views "List.cshtml" et "Form.cshtml"
- Il devra être possible de réaliser l'ensemble de la manipulation des films à partir de ces deux vues uniquement

**Bonus:**
- Il sera possible de stocker sur le serveur des images (les affiches des films) de sorte à améliorer un peu la page de listing
- Il sera possible de mettre en favoris jusqu'à 5 films, de sorte à les afficher avant le reste dans le listing (dans un affichage idéalement séparé)
- Les films en favoris seront sauvegardés via le mécanisme des cookies de sorte à les conserver entre les utilisations du site

Pour cela, il faudra implémenter plusieurs routes: 

- **/movies :** Retournera le listing des films
- **/movies/create :** Permettra la création d'un film au moyen d'un formulaire
- **/movies/details/{movieId} :** Page permettant de visualiser les détails du film
- **/movies/edit/{movieId} :** Page proposant un formulaire d'édition d'un film
- **/movies/delete/{movieId} :** Page de confirmation de suppression d'un film