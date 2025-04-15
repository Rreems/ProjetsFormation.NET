using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotel.Classes
{
    public class Reservation
    {
        private static int _compteur = 0;
        private int _numeroReservation;
        private List<Chambre> _chambres;
        private Client _client;
        private StatutReservation _statut;

        public List<Chambre> Chambres { get => _chambres; set => _chambres = value; }
        public Client Client { get => _client; set => _client = value; }
        public StatutReservation Statut { get => _statut; set => _statut = value; }
        public int NumeroReservation { get => _numeroReservation; set => _numeroReservation = value; }

        public Reservation(Client client)
        {
            _numeroReservation = ++_compteur;
            Client = client;
            Statut = StatutReservation.Prevu;
            Chambres = new List<Chambre>();
        }

    }

    public enum StatutReservation
    {
        Prevu,
        EnCours,
        Fini,
        Annule
    }
}
