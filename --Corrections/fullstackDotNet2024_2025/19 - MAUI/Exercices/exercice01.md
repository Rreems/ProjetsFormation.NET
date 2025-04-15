# Exercice MAUI #1 - ColorMaker

## Objectifs

Réaliser une application mobile permettant de: 

- Permettre la sélection d'une couleur manuellement via modification de ses valeurs RGB
- Permettre la génération d'une couleur aléatoire lors de l'appui sur un bouton

Votre interface devra donc comporter trois inputs (un par couleur) ainsi qu'un bouton. Le changement de la couleur devra se répercuter sur la couleur de fond de la page ainsi que dans un carré présent dans celle-ci. A proximité du carré devra se trouver, via un label, la valeur de la couleur en Hexadécimal. 

## Indices

Pour créer une couleurs, il est possible de le faire via la méthode de `Color`: 

```c#
var maCouleur = Color.FromArgb(alpha, red, green, blue)
```

Pour obtenir la valeur hexadécimale d'une couleurs, il est possible de l'extraire via: 
```c#
var valeurHexadecimale = maCouleur.ToHex();
```