using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo02RelationsRepository.Models;

namespace Demo02RelationsRepository.Repositories
{
    // Le contrat d'un CRUD sur l'entité Blog
    // C'est dans les classes qui vont IMPLEMENTER l'interface qu'on choisira COMMENT
    // Exemples : ADO, EF Core, une List<>, MongoDB, ...
    internal interface IBlogRepository
    {
        // CREATE
        //void Add(Blog blog); // version basique, pourrait lever une Exception en cas de problème
        //bool Add(Blog blog); // information sur le succès
        Blog? Add(Blog blog); // information sur le succès (null si échec) + champs modifiés (Id, ...)

        // READ
        Blog? GetById(int id);
        Blog? Get(Func<Blog,bool> predicate); // Le predicate va nous permetre de créer un filtre spécifique pour notre entité (b => b.Nom == "test")
        IEnumerable<Blog> GetAll(); // Préférer IEnumerable à List (cf. Lazy Loading Linq)
        IEnumerable<Blog> GetAll(Func<Blog, bool> predicate);

        // UPDATE
        //void Update(int id, Blog blog);
        //bool Update(int id, Blog blog);
        Blog? Update(int id, Blog blog);

        // DELETE
        bool Delete(int id);
    }
}
