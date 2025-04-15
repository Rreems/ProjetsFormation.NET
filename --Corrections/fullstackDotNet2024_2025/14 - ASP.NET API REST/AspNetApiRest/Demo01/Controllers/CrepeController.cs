using Demo01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrepeController : ControllerBase
    {
        private readonly CrepeFakeDb _crepeFakeDb;

        public CrepeController(CrepeFakeDb crepeFakeDb)
        {
            _crepeFakeDb = crepeFakeDb;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Crepe>), StatusCodes.Status200OK)] // ajoute ce que peux retourner l'endpoint dans la doc openapi/swagger
        //[ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var crepes = _crepeFakeDb.Crepes;

            //if (crepes.Any()) // la liste est-elle non vide
                return Ok(crepes); // statuscode 200

            //return NotFound();  // 404 => implique que le fait de ne pas trouver de crêpes soit une erreur
            //return NoContent(); // 204 => implique que le fait de ne pas trouver de crêpes soit une réussite
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var crepe = _crepeFakeDb.Crepes.FirstOrDefault(c => c.Id == id);

            if (crepe == null)
                return NotFound(new 
                {
                    Message = "Crêpe non trouvée !"
                });
            return Ok(new
            {
                Message = "Crêpe trouvée !",
                Crepe = crepe
            });
        }

        //[HttpGet("{id}")]
        //public ActionResult<Crepe> Get(int id) // Possible mais moins recommandé
        //{
        //    var crepe = _crepeFakeDb.Crepes.FirstOrDefault(c => c.Id == id);

        //    if (crepe == null)
        //        return NotFound();
        //    return Ok(crepe);
        //}

        [HttpPost]
        public IActionResult Post(Crepe crepe)
        {
            _crepeFakeDb.Crepes.Add(crepe);

            //return Ok("Crêpe Ajoutée"); // a éviter
            //return Created($"api/Crepe/{crepe.Id}", "Crêpe ajoutée");
            return CreatedAtAction(nameof(GetById), new { id = crepe.Id }, "Crêpe Ajoutée");// meilleure version à utiliser de préférence

            // dans le cas ou l'ajout aura échoué, il convient de retourner un BadRequest() => 400
        }

    }
}
