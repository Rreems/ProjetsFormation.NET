
using Correction01Personnage.Data;
using Correction01Personnage.Models;

namespace Correction01Personnage.UI
{
    internal static class UIActions
    {
        // méthode d'extension, en général on les mets dans des classe à part
        // résultats => <list/dbset>.PrintTable();  ou   UIActions.PrintTable(<list/dbset>);
        private static void PrintTable(this IEnumerable<Character> characters)
        {
            Console.WriteLine($"|" +
                              $"{nameof(Character.Id),-5}|" +
                              $"{nameof(Character.Pseudo),-5}|" +
                              $"{nameof(Character.HeathPoints),-5}|" +
                              $"{nameof(Character.MaxHeathPoints),-5}|" +
                              $"{nameof(Character.Armor),-5}|" +
                              $"{nameof(Character.Damages),-5}|" +
                              $"{nameof(Character.CreationDate),-5}|" +
                              $"{nameof(Character.Kills),-5}|");
            characters.ToList().ForEach(c => Console.WriteLine($"|" +
                $"{c.Id,-5}|" +
                $"{c.Pseudo,-5}|" +
                $"{c.HeathPoints,-5}|" +
                $"{c.MaxHeathPoints,-5}|" +
                $"{c.Armor,-5}|" +
                $"{c.Damages,-5}|" +
                $"{c.CreationDate,-5}|" +
                $"{c.Kills,-5}|"));
        }


        internal static void DisplayChars()
        {
            using var db = new AppDbContext();
            db.Characters.PrintTable();
        }

        internal static void CreateChar()
        {
            Console.WriteLine("\nCréation de Personnage\n\n");
            Console.Write("Pseudo : ");
            string pseudo = Console.ReadLine()!;

            Console.Write("Point de vie : ");
            int healPoint;
            while (!int.TryParse(Console.ReadLine(), out healPoint) || healPoint < 0)
                Console.Write("Veuillez entrer un nombre entier : ");

            Console.Write("Point de vie max : ");
            int maxHealPoint;
            while (!int.TryParse(Console.ReadLine(), out maxHealPoint) || maxHealPoint < 0)
                Console.Write("Veuillez entrer un nombre entier : ");

            Console.Write("Point d'armure : ");
            int armorPoint;
            while (!int.TryParse(Console.ReadLine(), out armorPoint) || armorPoint < 0)
                Console.Write("Veuillez entrer un nombre entier : ");

            Console.Write("Point de dégat : ");
            int damagePoint;
            while (!int.TryParse(Console.ReadLine(), out damagePoint) || damagePoint < 0)
                Console.Write("Veuillez entrer un nombre entier : ");

            var newCharacter = new Character
            {
                Pseudo = pseudo,
                HeathPoints = healPoint,
                MaxHeathPoints = maxHealPoint,
                Armor = armorPoint,
                Damages = damagePoint,
            };
            using var db = new AppDbContext();
            db.Characters.Add(newCharacter);
            db.SaveChanges();

            Console.WriteLine("\nPersonnage enregistré.");
        }

        internal static void UpdateChar()
        {
            using var db = new AppDbContext();
            Console.WriteLine("\nMise à jour d'un Personnage\n\n");

            db.Characters.PrintTable();

            Console.Write("Veuillez saisir l'Id du personnage : ");
            int id;
            Character? character = null;
            while (character is null)
            {
                while (!int.TryParse(Console.ReadLine(), out id) || id < 0)
                    Console.Write("Erreur ! Veuillez entrer un nombre entier positif : ");

                character = db.Characters.FirstOrDefault(c => c.Id == id);
                if (character is null)
                    Console.Write("Personnage non trouvé, Réessayez :");
            }

            Console.WriteLine("Personnage trouvé");
            //Console.WriteLine(character);

            Console.WriteLine("Si vous ne voulez pas changer les valeurs, appuyez sur 'Entrée'");
            Console.Write("Saisissez le nouveau pseudo : ");
            string newPseudo = Console.ReadLine()!;

            // Attention, dès que l'on passe par le setter, la mise à jour sera effectuée, même si la valeur reste la même
            //character.Pseudo = string.IsNullOrEmpty(newPseudo) || newPseudo.Length > 20 ? character.Pseudo : newPseudo;

            if (!string.IsNullOrEmpty(newPseudo)) // ici on ne modifie que si nouvelle valeur
                character.Pseudo = newPseudo;
            // possible d'améliorer avec des contrôles de saisie ex  || newPseudo.Length < 20

            Console.Write("Saisissez le nouveau point de vie : ");
            string newHealPointStr = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(newHealPointStr))
                character.HeathPoints = int.Parse(newHealPointStr);

            Console.Write("Saisissez le nouveau point de vie max : ");
            string newMaxHealPointStr = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(newHealPointStr))
                character.MaxHeathPoints = int.Parse(newMaxHealPointStr);

            Console.Write("Saisissez le nouveau point d'armure : ");
            string newArmorPointStr = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(newArmorPointStr))
                character.Armor = int.Parse(newArmorPointStr);

            Console.Write("Saisissez le nouveau point de dégat : ");
            string newDamagePointStr = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(newDamagePointStr))
                character.Damages = int.Parse(newDamagePointStr);

            Console.Write("Saisissez la nouvelle date de création (dd/mm/yyyy) : ");
            string newCreationDateStr = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(newCreationDateStr))
                character.CreationDate = DateTime.Parse(newCreationDateStr);

            //db.Characters.Update(character); // /!\ à éviter car plus couteux en ressources !

            // Comme l'entité a été récupérée (l. 96), elle est traquée, nos modifications seront appliquée au moment du SaveChanges()
            db.SaveChanges();

            Console.WriteLine("\nModification.S prise.s en compte\n");
        }

        internal static void DisplayHeathOverAvg()
        {
            using var db = new AppDbContext();

            var avg = db.Characters.Average(p => p.HeathPoints + p.Armor);

            db.Characters
              .Where(p => p.HeathPoints + p.Armor > avg)
              .OrderByDescending(p => p.HeathPoints + p.Armor)
              .PrintTable();
        }

        internal static void HitChar()
        {
            using var db = new AppDbContext();

            Console.Write("Veuillez saisir l'Id du personnage assaillant : ");
            int idAttacker = 0;
            Character? attacker = null;
            while (attacker is null)
            {
                while (!int.TryParse(Console.ReadLine(), out idAttacker) || idAttacker < 0)
                    Console.Write("Erreur ! Veuillez entrer un nombre entier positif : ");

                attacker = db.Characters.FirstOrDefault(c => c.Id == idAttacker);
                if (attacker is null)
                    Console.Write("Personnage non trouvé, Réessayez :");
            }

            Console.Write("Veuillez saisir l'Id du personnage défenseur : ");
            int idDefender;
            Character? defender = null;
            while (defender is null)
            {
                while (!int.TryParse(Console.ReadLine(), out idDefender) || idDefender < 0 || idDefender == idAttacker)
                    Console.Write("Erreur ! Veuillez entrer un nombre entier positif (différent de l'attaquant): ");

                defender = db.Characters.FirstOrDefault(c => c.Id == idDefender);
                if (defender is null)
                    Console.Write("Personnage non trouvé, Réessayez :");
            }

            // On regarde si la victime a encore de l'armure
            if (defender.Armor > 0)
            {
                // On regarde si les dégâts du personnage vont péter l'armure de la victime
                if (attacker.Damages > defender.Armor)
                {
                    defender.HeathPoints -= attacker.Damages - defender.Armor;
                    defender.Armor = 0;

                    // Si la victime n'a plus de PV, on la delete sinon on la met à jour
                    if (defender.HeathPoints <= 0)
                    {
                        attacker.Kills++;
                        db.Remove(defender);
                    }
                }
                else
                    defender.Armor -= attacker.Damages;
            }
            else
            {
                defender.HeathPoints -= attacker.Damages;

                if (defender.HeathPoints <= 0)
                {
                    attacker.Kills++;
                    db.Remove(defender);
                }
            }

            db.SaveChanges();
            Console.WriteLine($"{defender.Pseudo} a perdu...");
        }
    }
}
