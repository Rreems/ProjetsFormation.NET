# Exercice 02 Hôtel

## Objectifs
- Maîtriser les concepts de EFCore
- Apprendre à manipulation des relations ONE-TO-MANY, ONE-TO-ONE, MANY-TO-MANY
- S'entraîner avec linQ
- Utilisation du Repository Pattern

## Sujet
1. Créer une classe Client possédant : un identifiant, un nom, un prénom et un numéro de téléphone
2. Créer une classe Chambre ayant : un numéro, un statut (libre/occupé/en nettoyage de type enum), un nombre de lits et un tarif.
3. Créer une classe Réservation possédant : un identifiant, un statut (prévu/en cours/fini/annulé), une liste de chambres et un client
4. Créer une classe Hotel comportant : une liste de clients, une liste de chambres et une liste de réservations
5. Créer une IHM pour tester l'application