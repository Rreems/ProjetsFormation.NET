using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PizzApi.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string? Name { get; set; }
        [Precision(5,2)]
        public decimal Price { get; set; }
        [StringLength(200)]
        public string? ImageLink { get; set; }
        public List<Ingredient>? Ingredients { get; set; }
    }
}
