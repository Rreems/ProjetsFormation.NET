using Demo08Generiques.Classes;
using Demo08Generiques.Tourneviss.Visses;
using Demo08Generiques.Tourneviss;

//Boite<int> boiteEntier = new Boite<int>();
//boiteEntier.Valeur = 123;
//int valeurEntier = boiteEntier.Valeur;
//Console.WriteLine(valeurEntier); // Affiche 123


//Boite<string> boiteString = new Boite<string>();
//boiteString.Valeur = "Bonjour";
//string valeurString = boiteString.Valeur;
//Console.WriteLine(valeurString); // Affiche Bonjour

//int[] tableauEntiers = { 1, 2, 3, 4, 5 };
//string[] tableauStrings = { "un", "deux", "trois" };
//Util.ImprimerTableau(tableauEntiers); // Affiche 1 2 3 4 5
//Util.ImprimerTableau(tableauStrings); // Affiche un deux trois
//Util.ImprimerTableau<string>(tableauStrings); // autre notation (déduit en fonction du type de l'argument)



VisCruciforme visCruciforme = new VisCruciforme("M4");
TournevisAEmbout<VisCruciforme> tournevisCruciforme = new TournevisAEmbout<VisCruciforme>();
tournevisCruciforme.Utiliser(visCruciforme);

VisPlate visPlate = new VisPlate("M5");
//TournevisAEmbout<VisPlate> tournevisPlat = new TournevisPlat();
TournevisPlat tournevisPlat = new TournevisPlat();
tournevisPlat.Utiliser(visPlate);


TournevisUniversel.Utiliser(new VisCruciforme("M4"));
TournevisUniversel.Utiliser<VisCruciforme>(new VisCruciforme("M4"));
TournevisUniversel.Utiliser(new VisPlate("M5"));


