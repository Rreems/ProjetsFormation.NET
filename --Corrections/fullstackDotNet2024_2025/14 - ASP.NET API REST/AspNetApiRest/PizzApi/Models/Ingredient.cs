using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzApi.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string? Name { get; set; }
        public int PizzaId { get; set; }
        public Pizza? Pizza { get; set; }
    }
}
