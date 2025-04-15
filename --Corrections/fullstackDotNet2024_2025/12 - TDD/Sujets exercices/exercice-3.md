## Exercice 3 TDD

Implémenter une fonctionnalité de recherche de ville. La fonction prend une chaîne (texte de recherche) en entrée et renvoie les villes trouvées qui correspondent au texte de recherche.
Exemple de villes : Paris, Budapest, Skopje, Rotterdam, Valence, Vancouver, Amsterdam, Vienne, Sydney, New York, Londres, Bangkok, Hong Kong, Dubaï, Rome, Istanbul

Etapes du projet:
1. Si le texte de la recherche contient moins de 2 caractères, ***Une exception est levée de type NotFoundException***.
2. Si le texte de recherche est égal ou supérieur à 2 caractères, il doit renvoyer tous les noms de ville commençant par le texte de recherche exact.
   Par exemple, pour le texte de recherche "Va", la fonction doit renvoyer Valence et Vancouver 
3. La fonctionnalité de recherche doit être insensible à la casse
4. La fonctionnalité de recherche devrait également fonctionner lorsque le texte de recherche n'est qu'une partie d'un nom de ville
   Par exemple "ape" devrait renvoyer la ville "Budapest"
5. Si le texte de recherche est un « * » (astérisque), il doit renvoyer tous les noms de ville.

Vous devrez développer en appliquant les principes du TDD et étape par étape. 
Pour ce faire vous utiliserez Git et vous ferez un commit **AVANT CHAQUE TEST** et **AVANT CHAQUE MODIFICATION** de la fonction Rechercher.

```
public class RechercheVille {
   private List<String> _villes;
   
   public List<String> Rechercher(String mot)  {
      throw new NotImplementedException();
   }
}
```


### Conventionnal commits et GitMojis en TDD
 https://www.conventionalcommits.org/en/v1.0.0/
https://gitmoji.dev/
 
Initial :
feat: création des projets et classes
🎉 création des projets et classes

RED : 
test: ma fonctionnalité
🧪 ma fonctionnalité
 
GREEN : 
feat: ma fonctionnalité
✅ ma fonctionnalité
 
REFACTOR : 
refactor: ma fonctionnalité
♻️ ma fonctionnalité
 