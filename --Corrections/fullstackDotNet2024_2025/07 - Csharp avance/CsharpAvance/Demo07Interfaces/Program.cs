using Demo07Interfaces.Classes.Mammiferes;
using Demo07Interfaces.Classes.Oiseaux;
using Demo07Interfaces.Classes;
using Demo07Interfaces.Classes.Poissons;
using Demo07Interfaces.Interfaces;

Animal[] zooDeLille = new Animal[] {
 new Baleine(),
 new Baleine(),
 new Perche(),
 new Exocet(),
 new ChauveSouris(),
 new Exocet(),
 new Pigeon(),
 new Pigeon(),
};

foreach (Animal animal in zooDeLille)
{
    Console.WriteLine(animal);
    if (animal is Poisson)
    {
        Console.WriteLine("C'est un poisson!");
    }
    if (animal is IVolant volant)
    {
        volant.SEnvoler();
        volant.Atterrir();
    }
    if (animal is INageant nageant)
    {
        nageant.Nager();
    }
}

var nageants = new INageant[] {
 new Baleine(),
 new Baleine(),
 new Perche(),
 new Exocet(),
 //new ChauveSouris(),
 new Exocet(),
 //new Pigeon(),
 //new Pigeon(),
 //new object(),
};

var volants = new IVolant[] {
 //new Baleine(),
 //new Baleine(),
 //new Perche(),
 new Exocet(),
 new ChauveSouris(),
 new Exocet(),
 new Pigeon(),
 new Pigeon(),
 //new object(),
};



var objetc = new object[] {
 new Baleine(),
 new Baleine(),
 new Perche(),
 new Exocet(),
 new ChauveSouris(),
 new Exocet(),
 new Pigeon(),
 new Pigeon(),
 new object(),
};





Console.WriteLine("-------------------");


foreach (Animal animal in zooDeLille)
{
    if (animal is INageant nageur)
    {
        Console.WriteLine(animal.GetType().Name + " => Cet Animal peut nager !");
        nageur.Nager();
    }
    else
    {
        Console.WriteLine(animal.GetType().Name + " => Cet Animal ne peut pas nager !");
    }

    if (animal is IVolant volant)
    {
        Console.WriteLine(animal.GetType().Name + " => Cet Animal peut voler !");
        volant.SEnvoler();
        volant.Atterrir();
    }
    else
    {
        Console.WriteLine(animal.GetType().Name + " => Cet Animal ne peut pas voler !");
    }
    Console.WriteLine("-------------------");
}