char[] alphabet = new char[26];

for (int i = 0; i < 26; i++)
{
    alphabet[i] = (char)(i + 65);
}

string espace = "";

for (int i = 0; i < 26; i++)
{
    Console.WriteLine($"{espace}{alphabet[i]}");
    espace += " ";
}