using ApiCoderFranco.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoderFranco.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]
    public class QueryParameters
    { 
    public int Id { get; set; } 
    }


    public class UsuarioController : ControllerBase
    {
        UsuarioRepository _usuarioRepository;
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        [HttpGet("GetUsuarios/{id}")]
        public IActionResult Get([FromQuery] QueryParameters parameters)
        => Ok(new[] { parameters.Id,});



        public ActionResult GetUsuarios()
        {
            var resultado = _usuarioRepository.GetUsuarios();
            return Ok(resultado);
        }
    }
}
