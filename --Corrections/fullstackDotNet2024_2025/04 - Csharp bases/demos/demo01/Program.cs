/*
*Commentaire
* sur
* plusieurs lignes
* Pour commenter/décommenter rapidement une ligne de code : 'ctrl + :'
* Pour commenter plusieurs lignes : 'ctrl + maj + :'
*/

/*
    Les conventions de nommages :
    screaming snake case : SCREAMING_SNAKE_CASE
    camel case : camelCase
    snake case : snake_case
    kebab case : kebab-case
 */

//Console.WriteLine("Bonjour, je m'appelle Christophe");
//Console.WriteLine('\'');
//Console.WriteLine("C:\\Users\\Administrateur\\Desktop\\01 - Csharp bases");
//Console.WriteLine(@"C:\Users\Administrateur\Desktop\01 - Csharp bases");

//// Déclaration et initialisation des variables :
//int entier = 42; // valeur par défaut : 0
//double reel = 3.14; // valeur par défaut : 0
//decimal precis = 3.333333M; // Le decimal est plus précis dans les calculs, par défaut : 0M
//char caractere = 'A'; // valeur par défaut : \0
//string texte = "Bonjour"; // valeur par défaut : ""
//bool vraiOuFaux = true; // valeur par défaut : false

//// Impossible de changer la valeur de pi si la variable est déclarée en const
const double pi = 3.14;

//Console.WriteLine("Entier : " + entier);
//Console.WriteLine($"Réel : {reel}");

//Console.Write("Veuillez saisir votre prénom : ");
//string prenom = Console.ReadLine();

//Console.WriteLine($"Votre prénom : {prenom}");


//Console.Write("Veuillez saisir un nombre : ");
//int nb = Convert.ToInt32(Console.ReadLine());

//int c = 0;

//Console.WriteLine(c++);
//Console.WriteLine(c);

//c = c + 10;

//c += 10;

//Console.WriteLine(Math.Round(pi));

// Les structures conditionnelles

//int compte = -300;

//if (compte > 0)
//    Console.WriteLine("Votre compte est créditeur");
//else if (compte == 0)
//    Console.WriteLine("Votre solde est nul");
//else
//    Console.WriteLine("Votre compte est débiteur");

//string chaineAge = "20";
//int age;

//if (int.TryParse(chaineAge, out age))
//    Console.WriteLine($"La conversion est possible valeur de age : {age}");
//else
//    Console.WriteLine("Impossible de convertir");


// Switch ... Case

//string civilite = "test";

//switch (civilite)
//{
//    case "M.":
//        Console.WriteLine("Bonjour monsieur");
//        break;
//    case "Mme":
//        Console.WriteLine("Bonjour madame");
//        break;
//    case "Mlle":
//        Console.WriteLine("Bonjour mademoiselle");
//        break;
//    default:
//        Console.WriteLine("Bonjour !");
//        break;
//}

//int age = 21;

//switch (age)
//{
//    case < 0 or > 150:
//        Console.WriteLine("age invalide");
//        break;
//    case < 18:
//        Console.WriteLine("Vous êtes mineur");
//        break;
//    case 21:
//        Console.WriteLine("Vous êtes majeur aux USA");
//        break;
//    default:
//        Console.WriteLine("Vous êtes majeur");
//        break;
//}

// Les boucles :

//int compteur = 1;

// tant que ... faire

//while (compteur <= 50)
//{
//    Console.WriteLine($"Le compteur est à : {compteur}");
//    compteur++;
//}

// Faire .... tant que

//do
//{
//    Console.WriteLine($"Le compteur est à : {compteur}");
//    compteur++;
//} while (compteur <= 50);

//for (int compteur = 1; compteur <= 50; compteur++)
//{
//    if (compteur == 10)
//    {
//        // break => coupe complétement la boucle
//        continue; // continue => 'Saute' un tour de boucle et passe à l'itération suivante.
//    }
//    Console.WriteLine($"Le compteur est à : {compteur}");
//}

// Les tableaux

//int[] nombres = new int[10];
//int[] nombres = {1, 2, 3, 4, 5, 6};

//Console.WriteLine(nombres.Length);

//int[] t1 = { 2, 3, 4 };
//int[] t2 = t1;

//Console.WriteLine(t1[0]);
//Console.WriteLine(t2[0]);

//t1[0] = 100;

//Console.WriteLine(t1[0]);
//Console.WriteLine(t2[0]);
//int[] t2;
//t2 = (int[])t1.Clone();

//Console.WriteLine(t1[0]);
//Console.WriteLine(t2[0]);

//t1[0] = 100;

//Console.WriteLine(t1[0]);
//Console.WriteLine(t2[0]);

//List<int> maListe = new List<int>();

//maListe.Add(2);

//Console.WriteLine(maListe[0]);
//maListe.Add(3);

//Console.WriteLine(maListe[1]);

//foreach(int item in maListe)
//{
//    Console.WriteLine(item);
//}

//for (int i = 0; i < t1.Length; i++)
//{
//    t1[i] += 1;
//}

//foreach (int nb in t1)
//{
//    Console.WriteLine(nb);
//}

//Console.WriteLine(t1);

// Les fonctions

// Le type void signifie le vide, lorsque l'on retourne rien à la fin de la fonction.
void HelloWorld()
{
    Console.WriteLine("Hello World !");
}

//HelloWorld();

//string prenom = "test"; // Variable global

//void BonjourQui(string nom, string prenom = "Toto") // Variable local
//{
//    Console.WriteLine($"Bonjour {prenom} {nom}");
//}

//BonjourQui("Christophe", "Ringot");
//BonjourQui("Toto", "Tata");

double Addition(double nbA, double nbB)
{
    double resultat = nbA + nbB;
    return resultat;
}

var resultat = Addition(1, 2);

Console.WriteLine(resultat);
Console.WriteLine(Addition(5, 10));
Console.WriteLine($"Le résultat est : {Addition(25, 25)}");

//BonjourQui("Toto", "Tata");

(string, string) BonjourQui(string nom, string prenom = "Toto") // Variable local
{
    Console.WriteLine($"Bonjour {prenom} {nom}");
    return (nom, prenom);
}

(string nom, string prenom) = BonjourQui("toto", "toto");

Console.WriteLine(nom + " " + prenom);