using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo07Pile;

internal class Pile<T>
{
    //1. Créer une classe Pile<T> contenant un attribut T[] elements
    private List<T> _elements = new List<T>();

    //2. Ajouter une méthode permettant d'empiler un nouvel élément
    public void Empiler(T element)
    {
        _elements.Add(element);
    }

    //3. Ajouter une méthode permettant de dépiler le dernier élément empilé
    public T? Depiler()
    {
        if(_elements.Count == 0)
            return default; // si la liste est vide, on retourne le type par défaut
        // on pourrait aussi lever une exception
            //throw new Exception("La pile est vide!"); // utiliser InvalidOperationException

        //T dernierElement = _elements[_elements.Count - 1];
        T dernierElement = _elements[^1];
        _elements.RemoveAt(_elements.Count - 1);
        return dernierElement;
    }

    //4. Ajouter une méthode permettant de récupérer un élément par son index et ainsi de le retirer de la pile
    public T? Recuperer(int index)
    {
        //if(0 > index || index >= _elements.Count)
        if(!(0 <= index && index < _elements.Count))
                return default; // si la liste est vide, on retourne le type par défaut

        T element = _elements[index];
        _elements.RemoveAt(index);
        return element;
    }

    public override string ToString()
    {
        return "Pile : " + string.Join(", ", _elements);
    }
}



internal class Pile2<T>
{
    private T[] _elements = Array.Empty<T>(); // tableau vide, préférable à "new T[0]"

    public void Empiler(T element)
    {
        Array.Resize(ref _elements, _elements.Length + 1);
        _elements[_elements.Length - 1] = element;
    }

    public T Depiler()
    {
        if (_elements.Length == 0)
        {
            throw new InvalidOperationException("La pile est vide. Impossible de dépiler.");
            // ou return default(T); -> envoie la valeur par défaut selon le type de T, par exemple string = null, int = 0, etc.
        }

        T dernierElement = _elements[^1]; // ^ => à partir de la fin
        Array.Resize(ref _elements, _elements.Length - 1);
        return dernierElement;
    }

    public T Recuperer(int i)
    {
        if (i < 0 || i >= _elements.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(i), $"L'index {i} est en dehors des limites de la pile.");
        }

        // Récupérer l'élément à l'index donné
        T elementRemoved = _elements[i];

        #region Array.Copy
        // Créer un nouveau _elements de taille réduite
        T[] newArray = new T[_elements.Length - 1];

        // Copier tous les éléments avant l'index i
        Array.Copy(_elements, 0, newArray, 0, i);

        // Copier tous les éléments après l'index i
        Array.Copy(_elements, i + 1, newArray, i, _elements.Length - i - 1);

        // Mettre à jour le _elements privé avec le _elements modifié
        _elements = newArray;
        #endregion


        #region Syntaxe ..
        // Découper le tableau en deux parties
        T[] debutTab = _elements[..i];        // Partie avant l'index i
        T[] finTab = _elements[(i + 1)..];    // Partie après l'index i

        // Concaténer les deux parties et mettre à jour _elements
        _elements = debutTab.Concat(finTab).ToArray();
        #endregion

        // En une ligne
        // _elements = _elements[..i].Concat(_elements[(i + 1)..]).ToArray();

        return elementRemoved;
    }

    public override string ToString()
    {
        return "Pile : " + string.Join(", ", _elements);
    }
}

