Console.Write("Veuillez saisir votre prénom : ");
string firstname = Console.ReadLine();
Console.Write("Veuillez saisir votre nom : ");
string lastname = Console.ReadLine();
Console.Write("Veuillez saisir votre âge : ");
int age = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"Bonjour {firstname} {lastname}, vous avez {age} ans");
