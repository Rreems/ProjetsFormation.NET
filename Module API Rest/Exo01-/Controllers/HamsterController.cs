using Exo01_.Entities;
using Exo01_.Repository;
using Exo01_.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exo01_.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HamsterController : ControllerBase
{

    private readonly IHamsterService _service;
    public HamsterController(IHamsterService service)
    {
        _service = service;
    }



    // GET: api/<ValuesController>
    [HttpGet]
    [ProducesResponseType(typeof(List<Hamster>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public IActionResult Get()
    {
        var _hamsters = _service.GetAll();
        return Ok(_hamsters); // statuscode 200
    }


    // GET api/<ValuesController>/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Hamster), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] int id)
    {
        var hamster = _service.GetById(id);

        if (hamster == null)
            return NotFound(new
            {
                Message = "Hamster non trouvé !"
            });
        return Ok(new
        {
            Message = "Hamster trouvé !",
            Hamster = hamster
        });
    }


    /// <summary>
    /// Gets the price for a ticker symbol
    /// </summary>
    /// <param name="tickerSymbol"></param>
    /// <returns>A SharePriceResponse which contains the price of the share</returns>
    /// <response code="200">Returns 200 and the share price</response>
    /// <response code="400">Returns 400 if the query is invalid</response>
    [HttpGet("name/{lastName}")]
    [ProducesResponseType(typeof(Hamster), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public IActionResult GetByLastName(string lastName)
    {
        Hamster hamster = _service.GetAll(lastName).First();

        if (hamster == null)
            return NotFound(new
            {
                Message = "Hamster non trouvé !"
            });
        return Ok(new
        {
            Message = "Hamster trouvé !",
            Hamster = hamster
        });
    }

    // POST api/<ValuesController>
    [HttpPost]
    public IActionResult Post([FromBody] Hamster hamster)
    {
        _service.Add(hamster);

        //return Created($"api/Hamster/{hamster.Id}", "hamster ajouté");
        return CreatedAtAction(nameof(GetById), new { id = hamster.Id }, "Hamster Ajouté");// meilleure version à utiliser de préférence
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, Hamster hamster)
    {

        Hamster hamsterFound = _service.Update(id, hamster);

        if (hamsterFound != null)
        {

            return Ok(new
            {
                Message = "Hamster modifié",
                Hamster = hamsterFound
            });
        }
        else
        {
            return NotFound(new
            {
                Message = "Update en base ratée !"
            });
        }
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var hamster = _service.GetById(id);

        if (_service.Delete(hamster))
        {
        return Ok(new
        {
            Message = "Hamster supprimé..."
        });

        }else
        {
            return NotFound(new
            {
                Message = "Hamster non trouvé !"
            });

        }
    }
}
