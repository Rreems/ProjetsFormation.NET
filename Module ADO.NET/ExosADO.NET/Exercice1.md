# Exercice 1 - ADO.NET

- Realisez une application C# qui demande e l'utilisateur de saisir:
    - Nom
    - Prenom
    - Numero de classe
    - Date de dipleme

L'application ajoutera les donnees dans une table etudiant

- On souhaite modifier notre application pour ajouter des fonctionnalites :
    - Afficher la totalite des etudiants
    - Afficher les etudiants d'une classe
    - Supprimer un etudiant
    - (optionnel) Mettre e jour un etudiant e partir d'un objet etudiant 

- Une fois fini, modifier l'application en ajoutant ces methodes e la classe Etudiant 
    - `bool Save()`
    - `bool Delete()`
    - `static Etudiant GetById(int id)`
    - `static List<Etudiant>GetEtudiants(int? numeroClasse = null)`
    - (optionnel) `static EtudiantEditEtudiant(int id, Etudiant)`