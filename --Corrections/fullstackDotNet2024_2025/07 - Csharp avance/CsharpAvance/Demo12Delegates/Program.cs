
// Déclaration d'un délégué en temps que type
// soit Func<int,int,int>
internal delegate int Operation(int a, int b);



internal class Program
{

    public static int Add(int a, int b) => a + b;

    private static void Main(string[] args)
    {
        //fonctions locales
        int Carre(int a)
        {
            return a * a;
        }
        int Multiplication(int a, int b)
        {
            return a * b;
        }

        Console.WriteLine(Carre); // la fonction en elle même => sa référence => ToString == System.Func`2[System.Int32,System.Int32]
        Console.WriteLine(Carre(2)); // l'appel de la fonction avec l'agrment 2 => affiche le retour == 4

        List<int> l = new();
        Console.WriteLine(l); // type de la liste => System.Collections.Generic.List`1[System.Int32] == List<int>


        Console.WriteLine("-------------------");

        // Types Func et Action (Délégués)

        Func<int, int> carre = Carre;
        Func<int, int> carre2 = (a) => a * a; // une lambda expression aussi appelée fonction annonyme 

        var carre3 = (int a) => a * a; // type de carre3 déduit
        Func<int, int> carre4 = a => a * a; // type de a déduit


        Console.WriteLine(carre);
        Console.WriteLine(carre(2));
        Console.WriteLine(carre2(2));
        Console.WriteLine(carre3(2));

        Console.WriteLine("-------------------");

        Func<int, int, int> mul = Multiplication;
        Func<int, int, int> mul2 = (a, b) => a * b;
        Func<int, int, int> mul3 = (a, b) => a * b; // une seule instruction => lambda possible (return inclu)
                                                    // Func<int, int, double> mulDouble = (int a, int b) => (double) a * b; 


        // une ou plusieurs instructions => delegate (bloc d'instruction {} et types des paramètres obligatoires
        Func<int, int, int> mul4 = delegate (int a, int b)
        {
            Console.WriteLine($"Je multiplie {a} et {b}.");
            return a * b;
        };

        // équivalent sans le delegate et avec un "=>"
        Func<int, int, int> mul5 = (a, b) =>
        {
            Console.WriteLine($"Je multiplie {a} et {b}.");
            return a * b;
        };

        Console.WriteLine(mul);
        Console.WriteLine(mul(2, 5));
        Console.WriteLine(mul2(2, 6));
        Console.WriteLine(mul4(2, 6));

        Console.WriteLine("-------------------");

        //type operation définit en haut du fichier (alias pour Func<int,int,int>)
        Operation operation = Multiplication;
        Operation operation1 = (a, b) => a + b;

        Console.WriteLine("-------------------");

        // Func => retour le dernier type TResult
        Func<int, int, int> add = (int a, int b) => a + b;
        Func<int, int, int> add2 = (a, b) => a + b;

        // Action => pas de retour => void
        Action<string> print = (string msg) => Console.WriteLine(msg);
        Action<string> print2 = msg => Console.WriteLine(msg); // implicite

        Action<string> cw = Console.WriteLine; 

        print("test");
        cw("test");

        // On récupère la référence de la méthode WriteLine de la classe Console

        // Méthode statique
        Action<string> cw2 = Console.WriteLine;
        cw2("Hello, World!");

        // Méthode d'instance d'un objet particulier
        List<int> numbers = new List<int> { 3, 1, 2 };
        Action sortNumbers = numbers.Sort;
        sortNumbers();

        numbers.ForEach(Console.WriteLine); // Affiche : 1 2 3
        numbers.ForEach(nb => Console.WriteLine(nb)); // Affiche : 1 2 3


        // Exemple avec un Constructeur
        Func<List<string>> strLstCtor = () => new List<string>();

        List<string> stringList = strLstCtor();
        stringList.Add("Hello");

        Console.WriteLine("---------------------");

        void AfficheResultat(double a, double b, Func<double, double, double> calcul)
        {
            double resultat = calcul(a, b);
            Console.WriteLine($"Résultat : {resultat}");
        }

        AfficheResultat(4, 2, (a, b) => a * b); // Affiche: Résultat : 8
        AfficheResultat(4, 2, (a, b) => a + b); // Affiche: Résultat : 6
        AfficheResultat(4, 2, (a, b) => (int)Math.Pow(a, b)); // Affiche: Résultat : 16
        AfficheResultat(4, 2, Math.Pow); // Affiche: Résultat : 16

        Console.WriteLine("---------------------");

        // Multicast
        Action<int> actions = (x) => Console.WriteLine(x);
        actions += (x) => Console.WriteLine(x * 2);
        actions += (x) => Console.WriteLine(x * 10);
        actions(5); // Affiche 5 puis 10 puis 50 

        Func<int, int> actions2 = (x) => x;
        actions2 += (x) => x * 2;
        actions2 += (x) => x * 10;
        Console.WriteLine(actions2(5)); // Affiche 50 

        // Predicat
        // fonction qui vérifie une condition => retourne un booléen

        Func<int, double, bool> predicat = (int a, double b) => a < b;
        Predicate<int> predicate = (int a) => a > 18;
    }
}