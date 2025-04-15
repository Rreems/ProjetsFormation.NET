//int a = 1;
//int b = 0;
//if (b == 0)
//{
//    //throw new ArithmeticException("Division par zéro");
//    //throw new DivideByZeroException("Division par zéro");
//    throw new DivideByZeroException();
//}
//Console.WriteLine(a / b);



//int Calcul(int a, int b)
//{
//    return a / b; // en cas d'exception, provoquera un System.Exit(<code d'erreur>) terminant l'application
//}

//Console.Write("Donnez a: ");
//int a = int.Parse(Console.ReadLine()!);

//Console.Write("Donnez b: ");
//int b = int.Parse(Console.ReadLine()!);

//int resultat = Calcul(a, b);
//Console.WriteLine("Résultat = " + resultat);



//int Calcul(int a, int b)
//{
//    int c = a / b;
//    return c;
//}
//Console.Write("Donnez a: ");
//int a = int.Parse(Console.ReadLine()!);
//Console.Write("Donnez b: ");
//int b = int.Parse(Console.ReadLine()!);
//int resultat = 0;
//try
//{
//    // on essaye le bloc suivant
//    resultat = Calcul(a, b);
//}
//catch (DivideByZeroException e)
//{
//    // si l'exception DivideByZeroException est levée
//    //Console.WriteLine("Division par zero"); 

//    //Console.WriteLine("Exception levé, voici son message : " + e.Message);

//    //Console.ForegroundColor = ConsoleColor.Red;
//    //Console.WriteLine(e.ToString()); //.toString()
//    //Console.ResetColor();

//    //Console.WriteLine(e.StackTrace);
//}
//Console.WriteLine("Résultat = " + resultat);
//Console.WriteLine("Fin du programme !");



//using Demo11Exceptions;

//Compte compte = new Compte();

//Console.Write("Montant à verser:");
//float mt1 = float.Parse(Console.ReadLine()!);

//compte.Verser(mt1);

//Console.WriteLine("Solde actuel: " + compte.Solde);
//Console.Write("Montant à retirer:");

//float mt2 = float.Parse(Console.ReadLine()!);

////compte.Retirer(mt2);
//// Le compilateur ou l'IDE signalent l’Exception
//// Il nous oblige à nous en occuper

//try
//{
//    compte.Retirer(mt2);
//}
//catch (Exception e)
//{
//    Console.WriteLine(e);
//    //Console.WriteLine(e.Message);
//}


//using Demo11Exceptions;

//try
//{

//    Compte compte = new Compte();

//    Console.Write("Montant à verser:");
//    float mt1 = float.Parse(Console.ReadLine()!); // FormatException

//    compte.Verser(mt1);

//    Console.WriteLine("Solde actuel: " + compte.Solde);
//    Console.Write("Montant à retirer:");

//    float mt2 = float.Parse(Console.ReadLine()!); // FormatException

//    //compte.Retirer(mt2);
//    // Le compilateur ou l'IDE signalent l’Exception
//    // Il nous oblige à nous en occuper

//    compte.Retirer(mt2); // SoldeInsuffisantException
//}
//// catch (Exception e) // attraperait toutes les exceptions, rendant innutiles les autres blocs catch
//catch (SoldeInsuffisantException e)
//{
//    Console.WriteLine("Une exception de solde insiffisant à été levée");
//    //Console.WriteLine(e);
//}
//catch (FormatException e)
//{
//    Console.WriteLine("Une exception de format de saisie à été levée");
//    //Console.WriteLine(e);
//}
//catch (Exception e)
//{
//    Console.WriteLine("Ce message ne s'affichera JAMAIS !");
//    //Console.WriteLine(e);
//    //Console.WriteLine(e.Message);
//}



using Demo11Exceptions;

try
{
    Console.WriteLine("Traitement Normal");
    int.Parse(Console.ReadLine()!);
}
catch (FormatException e)
{
    Console.WriteLine("Premier cas Exceptionnel");
}
catch (Exception e)
{
    Console.WriteLine("Deuxième cas Exceptionnel");
}
finally
{
    Console.WriteLine("Traitement par défaut!");
    // exemple : fermer des connexions, nettoyer des ressources
}
Console.WriteLine("Suite du programme!");
