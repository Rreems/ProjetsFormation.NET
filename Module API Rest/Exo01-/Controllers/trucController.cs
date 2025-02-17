using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exo01_.Controllers;

[Route("api/[controller]")]
[ApiController]
public class trucController : ControllerBase
{

    [HttpGet]
    public IActionResult HelloWorld()
    {
        return Ok("Hello :)");
    }


    //[HttpGet("nom")]
    //public IActionResult HelloWorldNom(string? nom = null)


    [HttpGet("[action]/{nom?}/")]
    public string HelloWorldNom(string? nom = null)
    {
        if (nom == null) return "File ton nom, vil coquin";

        return $"Hello mon ptit {nom} :)";
    }

}
