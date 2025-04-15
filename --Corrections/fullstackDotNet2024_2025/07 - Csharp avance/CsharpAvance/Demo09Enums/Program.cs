using Demo09Enums;

// Un enum est une énumerations de possibilités pour une variable
// elle ne pourra être que l'une des valeurs définies dans l'enum


// exemple ConsolColor donne toutes les couleurs existantes pour une console

Console.ForegroundColor = ConsoleColor.White;


Genre genre = Genre.Masculin;

Console.WriteLine(genre);
Console.WriteLine((byte)genre);
Console.WriteLine((int)genre);


genre = (Genre)0;
genre = 0;
//genre = 255;

Console.WriteLine(genre);

