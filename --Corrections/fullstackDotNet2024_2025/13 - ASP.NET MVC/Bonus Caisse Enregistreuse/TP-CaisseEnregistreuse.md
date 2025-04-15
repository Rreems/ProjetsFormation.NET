### TP Caisse Enregistreuse


Le but de ce TP est de créer la structure d'une application web pour une caisse enregistreuse (similaire à un site de e-commerce).

Les models principaux de l'application seront :
- **Produit** : Id, Nom, Description, Prix, Quantité en stock, Catégorie, Image du produit
- **Categorie** : Id, Nom, Liste de Produits

L'application web proposera les pages suivantes :

- Une page pour afficher **la liste des produits**.
- une page pour **afficher un produit** (détails).
- Une page pour **ajouter/modifier un produit**.
- Une page pour afficher **la liste des catégories**.
- Une page pour **ajouter/modifier une catégorie**.
- Une page pour afficher **une catégorie et ses produits associés** (détails).
- Une page pour afficher notre **panier de vente**.

Les pages qui listent les entités proposeront pour chaque entité des boutons **supprimer**, **modifier** et **détails**

L'application aura une **barre de navigation** avec toutes les pages utiles. Aucune page ne sera accessible uniquement avec son url/sa route.

L'application sauvegardera les produits et catégories dans une BDD à l'aide D'**EFCore**

Chaque Produit aura une **image** que l'on pourra ajouter à la création


Un utilisateur pourra **ajouter un produit à son panier** depuis les détails du produit.
Les produits dans le **panier** seront sauvegardés dans la **session du client** sous format json (liste de produits).
La page panier affichera le prix de chaque article, le total, un bouton "Vider le panier" et un bouton "Passer commande" (ne faisant rien).

<br>
<br>

***Ce TP sera effectué en plusieurs parties, les fonctionnalités image et panier seront ignorées dans un premier temps.***