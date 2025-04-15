using Correction02Commande.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correction02Commande.Classes
{
    internal class IHM
    {
        public void AfficherTitre()
        {
            string title = @"
   ____                                          _           
  / ___|___  _ __ ___  _ __ ___   __ _ _ __   __| | ___  ___ 
 | |   / _ \| '_ ` _ \| '_ ` _ \ / _` | '_ \ / _` |/ _ \/ __|
 | |__| (_) | | | | | | | | | | | (_| | | | | (_| |  __/\__ \
  \____\___/|_| |_| |_|_| |_| |_|\__,_|_| |_|\__,_|\___||___/
";

            Console.WriteLine(title);
        }

        public void Menu()
        {
            Console.WriteLine("\n1. Lister les clients");
            Console.WriteLine("2. Créer un client");
            Console.WriteLine("3. Modifier un client");
            Console.WriteLine("4. Supprimer un client");
            Console.WriteLine("5. Afficher les détails d'un client");
            Console.WriteLine("6. Ajouter une commande");
            Console.WriteLine("0. Quitter");
        }

        public void AfficherClients()
        {
            ClientDAO clientDAO = new ClientDAO();
            clientDAO.GetAll().ForEach(c => Console.WriteLine(c));
        }

        public void CreerClient()
        {
            Client client = SaisirClient();

            ClientDAO clientDAO = new ClientDAO();

            try
            {
                clientDAO.Save(client);
                Console.WriteLine($"{client.Prenom} enregistré.e");
            }
            catch (Exception)
            {
                Console.WriteLine("Une erreur s'est produite lors de l'enregistrement");
            }

        }

        public Client SaisirClient()
        {
            Console.Write("Saisir un prénom: ");
            string prenom = Console.ReadLine() ?? "";

            Console.Write("Saisir un nom: ");
            string nom = Console.ReadLine() ?? "";

            Console.Write("Saisir une adresse: ");
            string adresse = Console.ReadLine() ?? "";

            Console.Write("Saisir un code postal: ");
            string codePostal = Console.ReadLine() ?? "";

            Console.Write("Saisir une ville: ");
            string ville = Console.ReadLine() ?? "";

            Console.Write("Saisir une téléphone: ");
            string telephone = Console.ReadLine() ?? "";

            return new Client(prenom, nom, adresse, codePostal, ville, telephone);
        }

        public void ModifierClient()
        {
            Console.Write("Saisir l'ID du client: ");
            int.TryParse(Console.ReadLine(), out int id);

            ClientDAO clientDAO = new ClientDAO();

            if (clientDAO.GetOneById(id) is null)
            {
                Console.WriteLine($"Aucun client trouvé avec l'id {id}");
                return;
            }

            Client client = SaisirClient();
            client.Id = id;

            try
            {
                clientDAO.Update(client);
                Console.WriteLine($"Client mis à jour");
            }
            catch (Exception)
            {
                Console.WriteLine("Une erreur s'est produite lors de l'enregistrement");
            }
        }

        public void SupprimerClient()
        {
            Console.Write("Saisir l'ID du client: ");
            int.TryParse(Console.ReadLine(), out int id);

            ClientDAO clientDAO = new ClientDAO();

            Client? client = clientDAO.GetOneById(id);

            if (client is null)
            {
                Console.WriteLine($"Aucun client trouvé avec l'id {id}");
                return;
            }

            try
            {
                clientDAO.Delete(client);
                Console.WriteLine($"Client supprimé");
            }
            catch (Exception)
            {
                Console.WriteLine("Une erreur s'est produite lors de l'enregistrement");
            }
        }

        public void AfficherDetailClient()
        {
            Console.Write("Saisir l'ID du client: ");
            int.TryParse(Console.ReadLine(), out int id);

            ClientDAO clientDAO = new ClientDAO();

            Client? client = clientDAO.GetOneById(id);

            if (client is null)
            {
                Console.WriteLine($"Aucun client trouvé avec l'id {id}");
                return;
            }

            Console.WriteLine(client.ToString());
            client.Commandes.ForEach(c => Console.WriteLine($"\t{c}"));
        }

        public void AjouterCommande()
        {
            Console.Write("Saisir l'ID du client: ");
            int.TryParse(Console.ReadLine(), out int id);

            ClientDAO clientDAO = new ClientDAO();

            Client? client = clientDAO.GetOneById(id);

            if (client is null)
            {
                Console.WriteLine($"Aucun client trouvé avec l'id {id}");
                return;
            }

            Console.Write("Saisir la date de la commande: ");
            DateTime dateCommande = DateTime.Parse(Console.ReadLine() ?? "");

            Console.Write("Saisir le total de la commande: ");
            decimal total = decimal.Parse(Console.ReadLine() ?? "");

            Commande commande = new Commande(total, dateCommande, client.Id);

            CommandeDAO commandeDAO = new CommandeDAO();

            try
            {
                commandeDAO.Save(commande);
            }
            catch (Exception)
            {
                Console.WriteLine("Erreur lors de l'enregistrement de la commande");
            }

        }

        public void Start()
        {
            AfficherTitre();

            while (true)
            {
                Menu();
                Console.Write("\nChoix: ");
                string choix = Console.ReadLine() ?? "";

                switch (choix)
                {
                    case "1":
                        Console.WriteLine("\n=== LISTE DES CLIENTS ===");
                        AfficherClients();
                        break;
                    case "2":
                        Console.WriteLine("\n=== CREATION CLIENT ===");
                        CreerClient();
                        break;
                    case "3":
                        Console.WriteLine("\n=== MODIFICATION CLIENT ===");
                        ModifierClient();
                        break;
                    case "4":
                        Console.WriteLine("\n=== SUPPRESSION CLIENT ===");
                        SupprimerClient();
                        break;
                    case "5":
                        Console.WriteLine("\n=== DETAIL CLIENT ===");
                        AfficherDetailClient();
                        break;
                    case "6":
                        Console.WriteLine("\n=== CREATION COMMANDE ===");
                        AjouterCommande();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Choix introuvable");
                        break;
                }
            }
        }
    }
}
