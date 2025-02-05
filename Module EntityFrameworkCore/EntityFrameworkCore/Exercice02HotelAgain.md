# Exercice 02 Hetel

## Objectifs
- Maetriser les concepts de EFCore
- Apprendre e manipulation des relations ONE-TO-MANY, ONE-TO-ONE, MANY-TO-MANY
- S'entraener avec linQ
- Utilisation du Repository Pattern

## Sujet
1. Creer une classe Client possedant : un identifiant, un nom, un prenom et un numero de telephone
2. Creer une classe Chambre ayant : un numero, un statut (libre/occupe/en nettoyage de type enum), un nombre de lits et un tarif.
3. Creer une classe Reservation possedant : un identifiant, un statut (prevu/en cours/fini/annule), une liste de chambres et un client
4. Creer une classe Hotel comportant : une liste de clients, une liste de chambres et une liste de reservations
5. Creer une IHM pour tester l'application