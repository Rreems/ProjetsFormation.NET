# Exercice 1 - ADO.NET

- Réalisez une application C# qui demande à l'utilisateur de saisir:
    - Nom
    - Prénom
    - Numéro de classe
    - Date de diplôme

L'application ajoutera les données dans une table étudiant

- On souhaite modifier notre application pour ajouter des fonctionnalités :
    - Afficher la totalité des étudiants
    - Afficher les étudiants d'une classe
    - Supprimer un étudiant
    - (optionnel) Mettre à jour un étudiant à partir d'un objet étudiant 

- Une fois fini, modifier l'application en ajoutant ces méthodes à la classe Etudiant 
    - `bool Save()`
    - `bool Delete()`
    - `static Etudiant GetById(int id)`
    - `static List<Etudiant>GetEtudiants(int? numeroClasse = null)`
    - (optionnel) `static EtudiantEditEtudiant(int id, Etudiant)`