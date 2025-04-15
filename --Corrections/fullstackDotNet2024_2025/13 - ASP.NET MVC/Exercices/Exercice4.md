### Exercice 4 Asp.NET Core
**Objectifs:** Comprendre l'utilisation de l'injection de dépendances

Recréer un projet ASP de zéro qui sera centré sur le CRUD d'une entité, dans le sujet il s'agit d'un Marmoset mais l'entité est au choix.

- Créer une FakeDb pour des Marmosets
- Créer un MarmosetController et utiliser l'injection de dépendance pour afficher 2 Views et leur données:
    - la liste de Marmosets (**/Marmoset**)
    - un Marmoset avec son id (**/Marmoset/Details/{id}**)
- Une fois fini, ajouter une action **/Marmoset/CreateRandom** pour créer un Marmoset avec des données aléatoires  
  Elle redirigera sur la liste de Marmosets après création (**/Marmoset**)
- En utilisant la route précédente, ajouter un bouton pour créer un Marmoset aléatoire en dessous de la liste
- Ajouter un bouton pour supprimer un Marmoset depuis la liste (des ajouts seront nécessaires dans le controller)

##### Aide :
Création de string aléatoire :
```cs
public static string RandomString(string chars, int length)
{
    Random random = new Random();
    return new string(Enumerable.Repeat(chars, length)
        .Select(s => s[random.Next(s.Length)]).ToArray());
}

string chaine = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", longueur);
```
