using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult HelloWorld() 
        {
            return Ok("Hello World !");
        }
        //[HttpGet("test")]
        //[HttpGet("/test")]
        //[HttpGet("[action]")]
        //public IActionResult HelloWorld2() 
        //{
        //    return Ok("Hello World !");
        //}

        //[HttpGet("bonjour")] // api/Hello/bonjour?nom=guillaume
        //[HttpGet("/bonjour")] // /bonjour?nom=guillaume
        //[HttpGet("[action]")] // api/Hello/DitBonjour?nom=guillaume
        //public string DitBonjour([FromQuery]string? nom = null)
        [HttpGet("[action]/{nom?}")] // api/Values/DitBonjour/guillaume
        public string DitBonjour(/*[FromRoute]*/ string? nom = null)
        {
            if (nom == null)
                return "Pas de nom !";

            return "Bonjour " + nom + " !";
        }
    }
}
