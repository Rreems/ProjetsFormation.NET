Console.Write("Veuillez saisir une lettre :  ");
string lettre = Console.ReadLine().ToUpper();

if (lettre == "A" || 
    lettre == "E" || 
    lettre == "I" || 
    lettre == "O" || 
    lettre == "U" || 
    lettre == "Y")
{
    Console.WriteLine("Cette lettre est une voyelle");
} else
{
    Console.WriteLine("Cette lettre n'est pas une voyelle");
}