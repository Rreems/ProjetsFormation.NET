//using System.Data;
//using Microsoft.Data.SqlClient;

//string connectionString = "Data Source=(localdb)\\ContactDB;Integrated Security=True";

//using var conn = new SqlConnection(connectionString);
//conn.Open();


////(optionnel) Mettre à jour un étudiant à partir d'un objet étudiant



///*Réalisez une application C# qui demande à l'utilisateur de saisir:
//                - Nom
//                - Prénom
//                - Numéro de classe
//                - Date de diplome

//L'application ajoutera les données dans une table étudiant          */

//// Champs de la BDD :
//// id
//// prenom
//// nom
//// numero_classe
//// date_diplome

//// L'application ajoutera les données dans une table étudiant
//Console.WriteLine("votre nom?");
//string nom = Console.ReadLine()!;
//Console.WriteLine("votre prénom?");
//string prenom = Console.ReadLine()!;
//Console.WriteLine("votre n° de classe:");
//int classe = int.Parse(Console.ReadLine()!);//penser au contrôle de saisie
//Console.WriteLine("date du diplome:");
//DateTime dateDiplome = DateTime.Parse(Console.ReadLine()!);//penser au contrôle de saisie

//string request = "INSERT INTO etudiant ( nom,prenom, numero_classe, date_diplome) VALUES ( @nom,@prenom, @numero_classe, @date_diplome)";

//using (var command = new SqlCommand(request, conn))
//{
//    command.Parameters.AddWithValue("@nom", nom);
//    command.Parameters.AddWithValue("@prenom", prenom);
//    command.Parameters.AddWithValue("@numero_classe", classe);
//    command.Parameters.AddWithValue("@date_diplome", dateDiplome);

//    command.ExecuteNonQuery();
//}


////Afficher la totalité des étudiants
//request = "SELECT id, prenom, nom, numero_classe, date_diplome FROM etudiant;";

//using (var sqlCommand = new SqlCommand(request, conn))
//{
//    using SqlDataReader reader = sqlCommand.ExecuteReader();

//    while (reader.Read())
//    {
//        Console.WriteLine($"Id: {reader.GetInt32(0)} Prenom: {reader.GetString(1)} Nom: {reader.GetString(2)}, Classe: {reader.GetInt32(3)}, Date du diplome:{reader.GetDateTime(4).ToString("dd/MM/yy")}");
//    }
//}


////Afficher les étudiants d'une classe

//Console.WriteLine("Quelle classe voulez vous afficher?");
//int classedemand = Convert.ToInt32(Console.ReadLine());//penser au contrôle de saisie
//request = "SELECT *  FROM etudiant WHERE numero_classe = @classedemand;";

//using (SqlCommand sqlCommand = new SqlCommand(request, conn))
//{
//    sqlCommand.Parameters.AddWithValue("@classedemand", classedemand);
//    using SqlDataReader reader = sqlCommand.ExecuteReader();

//    while (reader.Read())
//    {
//        Console.WriteLine($"id: {reader.GetInt32(0)} prenom: {reader.GetString(1)} nom: {reader.GetString(2)}, classe: {reader.GetInt32(3)}, Date du diplome:{reader.GetDateTime(4)}");
//    }
//}


////Supprimer un étudiant

//Console.WriteLine("quelle étudiant voulez-vous supprimer, mettez l'id?");
//int deleteId = Convert.ToInt32(Console.ReadLine());
//request = "DELETE etudiant WHERE id = @deleteId;";

//using (SqlCommand sqlCommand = new SqlCommand(request, conn))
//{
//    sqlCommand.Parameters.AddWithValue("@deleteId", deleteId);
//    int nbLignes = sqlCommand.ExecuteNonQuery();
//    Console.WriteLine(nbLignes == 1 ? "Etudiant.e supprimée" : "Un problème est survenu lors de la suppression de l'étudiant.e ...");
//}



////modifier


//Console.WriteLine("quelle étudiant voulez-vous modifier, mettez l'id?");
//int updateId = Convert.ToInt32(Console.ReadLine());
//// possible d'afficher l'utilisateur et mettre un message de confirmation (cf. Select par Id)

//Console.WriteLine("Saisir les nouvelles valeurs :");
//Console.WriteLine("votre nom?");
//nom = Console.ReadLine()!;
//Console.WriteLine("votre prénom?");
//prenom = Console.ReadLine()!;
//Console.WriteLine("votre n° de classe:");
//classe = int.Parse(Console.ReadLine()!);//penser au contrôle de saisie
//Console.WriteLine("date du diplome:");
//dateDiplome = DateTime.Parse(Console.ReadLine()!);//penser au contrôle de saisie

//request = "UPDATE etudiant " +
//          "SET " +
//              "prenom = @prenom" +
//              "nom = @nom" +
//              "numero_classe = @numero_classe" +
//              "date_diplome = @date_diplome" +
//          "WHERE id = @updateId;";

//using (SqlCommand sqlCommand = new SqlCommand(request, conn))
//{
//    sqlCommand.Parameters.AddWithValue("@updateId", updateId);
//    sqlCommand.Parameters.AddWithValue("@nom", nom);
//    sqlCommand.Parameters.AddWithValue("@prenom", prenom);
//    sqlCommand.Parameters.AddWithValue("@numero_classe", classe);
//    sqlCommand.Parameters.AddWithValue("@date_diplome", dateDiplome);

//    int nbLignes = sqlCommand.ExecuteNonQuery();
//    Console.WriteLine(nbLignes == 1 ? "Etudiant.e mis.e à jour" : "Un problème est survenu lors de la mise à jour de l'étudiant.e ...");
//}


IHM.Start();