for (int table = 1; table <= 10; table++)
{
    Console.WriteLine($"Table {table} :");
    for (int multi = 1; multi <= 10; multi++)
    {
        Console.WriteLine($"\t- {table}X{multi} = {table * multi}");
    }
}