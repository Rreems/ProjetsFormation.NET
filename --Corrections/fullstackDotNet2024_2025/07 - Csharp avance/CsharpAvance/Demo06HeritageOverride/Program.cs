using Demo06HeritageOverride;

//Animal animal = new Animal("an1", true);
//Mammifere mammifere = new Mammifere("mam1", true, "femelle"); // plus possible dès lors que l'on a les mots clés abstract

////Console.WriteLine("-------------------");
////animal.Crier();

////Console.WriteLine("-------------------");
////mammifere.Crier();


//Animal mammifereAnimal = mammifere;

//List<Animal> list = new List<Animal>()
//{
//    animal,
//    mammifere,
//    mammifereAnimal
//};

//foreach (Animal an in list)
//{
//    Console.WriteLine(an.Nom);
//    an.Crier();
//    Console.WriteLine("-------------------");
//}


//List<object> listObject = new List<object>()
//{
//    new object(),
//    animal,
//    mammifere,
//    mammifereAnimal
//};

//foreach (object o in listObject)
//{
//    Console.WriteLine(o);
//    //Console.WriteLine(o.ToString());
//    Console.WriteLine("-------------------");
//}


Chien chien = new("Pepette", true, "femelle", "Rottweiler");
Console.WriteLine(chien.Nom);
chien.SeDeplacer();
chien.Respirer();
chien.Crier();
chien.Allaiter();

var chat = new Chat("Mistigri", true, "femelle");
Console.WriteLine(chat.Nom);
chat.SeDeplacer();
chat.Respirer();
chat.Crier();
chat.Crier("le cri du chat");
chat.Allaiter();

Console.WriteLine("-------------");

List<object> list = new()
{
    1,
    "bonjour",
    chat,
    chat,
    chien
};

foreach (object item in list)
{
    //item.Crier();

    //Chat chat1 = (Chat)item; // erreur pour int, string, Chien
    //chat1.Crier();

    if(item.GetType() == typeof(Chat))
    {
        Console.WriteLine("C'est un chat !");
        Chat chat1 = (Chat)item;
        chat1.Crier();
    }
}

Console.WriteLine("-------------");

// Opérateur is

foreach (object item in list)
{

    //if (item is Chat)
    if (item is Chat chat1)
    {
        //Chat chat1 = (Chat)item;
        Console.WriteLine("C'est un chat !");
        chat1.Crier();
    }
}


Console.WriteLine("-------------");

// Opérateur is

foreach (object item in list)
{

    if (item is Animal mon_animal) // on teste si c'est un animal et on l'envoie si c'est le cas dans la variable mon_animal
    {
        Console.WriteLine("C'est un animal !");
        if (item is Chat mon_chat)
        {
            Console.WriteLine("C'est un chat !");
            mon_chat.Allaiter();
        }
        if (mon_animal is Chien)
        {
            Console.WriteLine("C'est un chien !");
        }
        mon_animal.Crier();
    }
    else
        Console.WriteLine("Ce n'est pas un animal !" + item);

    Console.WriteLine("-----------------------------------------");
}

// operateur as
foreach (object mon_objet in list)
{
    Chat? mon_chat = mon_objet as Chat; // null si pas un chat
    Console.WriteLine("Contenu de la variable mon_chat (vide si null) : " + mon_chat);
}



Console.WriteLine("-----------------------------------------");

// récupérer le type avec .GetType()

int t = 5;
Console.WriteLine(t.GetType());
Console.WriteLine(t.GetType().Name);
Console.WriteLine(t.GetType().FullName);
Console.WriteLine(t.GetType().Namespace);


foreach (object mon_objet in list)
{
    Console.WriteLine(mon_objet.GetType());
    Console.WriteLine(mon_objet.GetType().Name);
    Console.WriteLine(mon_objet.GetType().FullName);
    Console.WriteLine(mon_objet.GetType().Namespace);
}