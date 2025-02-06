using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo02EFCore.Models
{
    public class ReservationChambre
    {
        //public (int,int) Id = 


        [Column("chambre_id")]
        public int ChambreId { get; set; }

        public Chambre Chambre { get; set; }


        [Column("reservation_id")]
        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }
    }
}
