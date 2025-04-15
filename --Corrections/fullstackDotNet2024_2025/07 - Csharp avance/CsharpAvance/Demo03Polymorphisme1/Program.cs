using Demo03Polymorphisme1;

Enclos enclos1 = new Enclos("Le pré des vélociraptors", 500, 5);

Dinosaur denver = new Dinosaur("Denver", 10, "Corythosaurus", false);
var dino1 = new Dinosaur();
var dino2 = new Dinosaur(dino1); // constructeur de recopie (3e)

// 1ere forme
enclos1.AjouterDino(denver);
enclos1.AjouterDino(dino1);
enclos1.AjouterDino(new Dinosaur());

// 2e forme
enclos1.AjouterDino();

// 3e forme
enclos1.AjouterDino("Petit-Pied", 12, "Apatosaurus", true);


// pas d'ajout car l'enclos est plein => la fonction retourne false
bool res = enclos1.AjouterDino("Petit-Pied2", 12, "Apatosaurus", true);
Console.WriteLine(res ? "Le dino a été ajouté" : "le dino n'est pas ajouté");

Console.WriteLine(enclos1);


// précisions pour le mot clé "var"

int a = 1;
long b = 2;

float x = (float) 1.0;
float x2 = 1f;
double y = 1.0;
decimal y2 = 1.0M;

var c = 3L;

var obj = new object();
object obj2 = new object();


var dino3 = new Dinosaur();
Dinosaur dino4 = new ();
Dinosaur dino5 = new Dinosaur();

// var dino5 = new(); // pas possible car pas de type

