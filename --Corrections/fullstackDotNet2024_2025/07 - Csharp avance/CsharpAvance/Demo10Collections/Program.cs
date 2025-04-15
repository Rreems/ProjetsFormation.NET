////using System.Collection.Generics; // déjà fait mais caché

List<string> mesChaines = new List<string>()
{
    "chaine1",
    "chaine2",
    "chaine2",
    "chaine3",
    "chaine4",
    "chaine5",
};

foreach (string item in mesChaines)
{
    Console.WriteLine(item);
}
Console.WriteLine("----------------------------");

mesChaines.Remove("chaine2");
mesChaines.RemoveAt(0);
mesChaines.Add("chaine6");

foreach (string item in mesChaines)
{
    Console.WriteLine(item);
}

mesChaines.Clear();

Console.WriteLine("----------------------------");



// Sets

HashSet<string> set = new HashSet<string>();
set.Add("Java");
set.Add("Python");
set.Add("Python3");
set.Add("C++");
set.Add("C++");
set.Add("C++");
Console.WriteLine("HashSet : " + string.Join(", ", set));

// Démo pour SortedSet
SortedSet<string> sortedSet = new SortedSet<string>();
sortedSet.Add("Java");
sortedSet.Add("Python");
sortedSet.Add("Python3");
sortedSet.Add("C++");
sortedSet.Add("C++");
sortedSet.Add("C++");
Console.WriteLine("SortedSet : " + string.Join(", ", sortedSet));

// Méthodes pour SortedSet
Console.WriteLine("1. Premier élément : " + sortedSet.First());
Console.WriteLine("2. Dernier élément : " + sortedSet.Last());
SortedSet<string> headset = new SortedSet<string>(sortedSet.GetViewBetween(sortedSet.First(), "Python"));
Console.WriteLine("3. Sous-ensemble avant 'Python' : " + string.Join(", ", headset));


// Dictionaires

Dictionary<string, int> dictionary = new Dictionary<string, int>();
dictionary["Java"] = 20;

if (!dictionary.ContainsKey("Java"))
    // si ne contient pas "Java" je l'ajoute
    dictionary["Java"] = 22;

dictionary["Python"] = 10;
dictionary["C++"] = 30;
Console.WriteLine("\nDictionary : " + string.Join(", ", dictionary));

// Méthodes pour Dictionary
Console.WriteLine("1. Nombre d'entrées du Dictionary : " + dictionary.Count);

Console.WriteLine("2. Valeur associée à 'Java' : " + dictionary["Java"]);

Console.WriteLine("3. Est-ce que 'Test' est présent ? : " + dictionary.ContainsKey("Test"));

Console.WriteLine("4. Suppression de l'entrée avec la clé 'Python' : ");
dictionary.Remove("Python");
Console.WriteLine("Nouveau Dictionary : " + string.Join(", ", dictionary));

foreach (KeyValuePair<string, int> entry in dictionary)
{
    Console.WriteLine(entry);
    Console.WriteLine("Clé :" + entry.Key);
    Console.WriteLine("Valeur :" + entry.Value);
}



//Queue FIFO (First In First Out)

Queue<string> myQ = new Queue<string>();

myQ.Enqueue("Hello");
myQ.Enqueue("World");
myQ.Enqueue("!");

Console.WriteLine(myQ.Count);

Console.WriteLine(myQ.Dequeue());
Console.WriteLine(myQ.Count);
Console.WriteLine(myQ.Dequeue());
Console.WriteLine(myQ.Dequeue());
Console.WriteLine(myQ.Count);
//Console.WriteLine(myQ.Dequeue());



//Queue LIFO/FILO (Last In First Out)

Stack<string> myStk = new Stack<string>();

myStk.Push("Hello");
myStk.Push("World");
myStk.Push("!");

Console.WriteLine(myStk.Count);

Console.WriteLine(myStk.Pop());
Console.WriteLine(myStk.Count);
Console.WriteLine(myStk.Pop());
Console.WriteLine(myStk.Pop());
Console.WriteLine(myStk.Count);
//Console.WriteLine(myQ.Dequeue());


// Bonus : Generateurs

IEnumerable<int> ToutLesEntiers()
{
    for (int i = 0; i < 500; i++) // int.MaxValue => valeur max pour int 2147483647
    {
        yield return i;
        //if (i == 7)
        //    yield break; // termine le générateur
    }
}

//foreach (int item in ToutLesEntiers())
//{
//    Console.WriteLine(item);
//}

var enumerable = ToutLesEntiers();

var list = enumerable.ToList();

Console.WriteLine(list.Count);
Console.WriteLine(list.Capacity);

while (list.Any())
{
    list.RemoveAt(0);
    Console.WriteLine(list.Count);
    Console.WriteLine(list.Capacity); // la capacité ne diminue pas quand on retire des éléments
}

//Console.WriteLine("------------------");

//var list2 = new List<int>();
//for (int i = 0; i < 50; i++)
//{
//    list2.Add(i);
//    Console.WriteLine(list2.Count + " -> " +list2.Capacity); // la capacité ne diminue pas quand on retire des éléments
//}