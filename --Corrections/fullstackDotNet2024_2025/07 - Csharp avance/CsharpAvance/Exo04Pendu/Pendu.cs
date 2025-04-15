using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice04Pendu
{
    internal class Pendu
    {
        private string _motAtrouver;
        private string _masque;
        private int _nbEssaisTotal = 10;
        private int _nbEssaisRestants;
        private string _letresTestees = "";

        public string Masque { get => _masque;} //possible d'ajouter GenererMasque(); dans le bloc get pour le générer à chque fois
        public int NbEssaisTotal { get => _nbEssaisTotal; }
        public int NbEssaisRestants { get => _nbEssaisRestants; }

        public Pendu()
        {
            _nbEssaisRestants = _nbEssaisTotal;
            _motAtrouver = GenerateurDeMots.GenererMot();
            // 1ere génération du masque
            GenererMasque();
            // Alternatives pour la première génération:
            //_masque = new string('*', _motAtrouver.Length);
            //_masque = string.Concat(Enumerable.Repeat("*", _motAtrouver.Length));
        }

        public Pendu(int nbEssais) : this()
        {
            _nbEssaisTotal = nbEssais;
            _nbEssaisRestants = nbEssais;
        }

        public string TestChar(char lettre)
        {
            if (_letresTestees.Contains(lettre))
                return "Lettre déjà testée !!!";

            _letresTestees += lettre;
            if (_motAtrouver.Contains(lettre))
                return "La lettre est dans le mot !";

            _nbEssaisRestants--;
            return "La lettre n'est pas dans le mot...";
        }

        public bool TestWin()
        {
            //if (_masque.Contains('*'))
            //    return false;
            //return true;

            return !_masque.Contains('*');
        } 

        public void GenererMasque()
        {
            _masque = "";
            foreach (char lettre in _motAtrouver)
            {
                if (_letresTestees.Contains(lettre))
                    _masque += lettre;
                else
                    _masque += '*';
            }
        }

        //Propriété Masque sans attribut masque => généré à chaque fois qu'on get
        public string Masque2 
        { 
            get
            {
                string masque = "";
                foreach (char lettre in _motAtrouver)
                {
                    if (_letresTestees.Contains(lettre))
                        masque += lettre;
                    else
                        masque += '*';
                }
                return masque;
            }
        } 

    }
}
