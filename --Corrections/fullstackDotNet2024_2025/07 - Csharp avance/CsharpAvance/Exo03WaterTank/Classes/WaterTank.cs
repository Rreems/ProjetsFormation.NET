using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice03WaterTank.Classes
{
    internal class WaterTank
    {
        private int _fillLevel;
        private int _maxCapacity;
        private int weightEmpty;

        private static int _totalFillLevels = 0;

        public int FillLevel 
        { 
            get => _fillLevel;
            private set
            {
                _totalFillLevels -= _fillLevel;
                _fillLevel = value;
                _totalFillLevels += _fillLevel;
            }
        }
        public int MaxCapacity { get => _maxCapacity; private set => _maxCapacity = value; }
        public int WeightEmpty { get => weightEmpty; private set => weightEmpty = value; }
        public int TotalWeight => WeightEmpty + FillLevel; // équivalent : public int TotalWeight { get => WeightEmpty + FillLevel; }
        public static int TotalFillLevels => _totalFillLevels;// équivalent : public static int TotalFillLevels { get => _totalFillLevels;}

        public WaterTank(int fillLevel, int maxCapacity, int weightEmpty)
        {
            FillLevel = fillLevel;
            MaxCapacity = maxCapacity;
            WeightEmpty = weightEmpty;
        }

        public int Fill(int amount)
        {
            if (amount <= 0)
                return 0;

            if (_fillLevel + amount > _maxCapacity)                     // est-ce que le montant dépasse la capacité maximum de la citerne
            {
                int excessWater = _fillLevel + amount - _maxCapacity;   // je calcule le montant d'eau en surplus
                FillLevel = _maxCapacity;                               // elle est maintenant pleine
                return excessWater;                                     // on "rends" le surplus d'eau
            }
            else                                                        // dans le cas ou on dépasse pas le maximum
            {
                FillLevel += amount;
                return 0;                                               // on retourne aucun surplus d'eau
            }
        }

        public int Empty(int amount)
        {
            if (amount <= 0)
                return 0;
            if (_fillLevel - amount < 0)                                // est-ce que le montant dépasse la capacité minimum de la citerne
            {
                int waterTaken = _fillLevel;                            // on récupère le contenu de la citerne
                FillLevel = 0;                                          // la citerne est donc vide
                return waterTaken;                                      // on retourne la quantité qu'on a récupérée
            }
            else                                                        // dans le cas ou on dépasse pas le minimum
            {
                FillLevel -= amount;
                return amount;                                          // on retourne la quantité demandée d'eau
            }
        }

        public void AffichageCiterne()
        {
            string[,] citerneAscii = {
                {"┌──────O─────┐",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "└────────────┘"},
                {"┌──────O─────┐",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│~~~~~~~~~~~~│",
                "└────────────┘"},
                {"┌──────O─────┐",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│~~~~~~~~~~~~│",
                "│            │",
                "└────────────┘"},
                {"┌──────O─────┐",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│~~~~~~~~~~~~│",
                "│            │",
                "│            │",
                "└────────────┘"},
                {"┌──────O─────┐",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│~~~~~~~~~~~~│",
                "│            │",
                "│            │",
                "│            │",
                "└────────────┘"},
                {"┌──────O─────┐",
                "│            │",
                "│            │",
                "│            │",
                "│~~~~~~~~~~~~│",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "└────────────┘"},
                {"┌──────O─────┐",
                "│            │",
                "│            │",
                "│~~~~~~~~~~~~│",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "└────────────┘"},
                {"┌──────O─────┐",
                "│            │",
                "│~~~~~~~~~~~~│",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "└────────────┘"},
                {"┌──────O─────┐",
                "│~~~~~~~~~~~~│",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "│            │",
                "└────────────┘"},
            };
            int niveauCiterne = FillLevel == 1 ? 1 : (FillLevel * 8 / MaxCapacity);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(citerneAscii[niveauCiterne, i]);
            }
        }
    }
}
