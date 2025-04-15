using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02RelationsRepository.Models
{
    internal class Post
    {
        public int Id { get; set; }
        public string Titre { get; set; } = null!;
        public string Contenu { get; set; } = null!;
        public DateTime DatePublication { get; set; } = DateTime.Now; // attention au niveau du data seed => nouvelle date à chaque migration

        //[ForeignKey(nameof(Blog))] //Utilisation de l'annotation ForeignKey lorsque l'on respecte pas la convention
        // La propriété <entité>Id va être interprété comme une foreign key par EFCore
        // Le fait de créér cette propriété n'est pas obligatoire, mais elle sera pratique pour la sérialisation de l'objet
        public int BlogId { get; set; } 
        // si int? > nullable > pas de contrainte d'apartenance obligatoire et pas de "ON DELETE CASCADE"


        // Ma propriété blog est lié à ma propriété BlogId
        public Blog Blog { get; set; } = null!;
    }
}
