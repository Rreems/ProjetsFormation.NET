using Demo04Polymorphisme2;


// WriteLine est polymorphique paramétrique
Console.WriteLine("test"); // string?
Console.WriteLine(21); // int ?
Console.WriteLine(true); // bool
//Console.WriteLine(dino1); // object?


Console.WriteLine(Additionneur.Additionner(1, 2));
Console.WriteLine(Additionneur.Additionner(1.5, 2.0));
Console.WriteLine(Additionneur.Additionner("Bonjour ", "camarade"));
