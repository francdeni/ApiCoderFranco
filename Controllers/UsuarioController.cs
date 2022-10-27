using ApiCoderFranco.Models;
using ApiCoderFranco.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoderFranco.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]
    


    public class UsuarioController : ControllerBase
    {
        UsuarioRepository _usuarioRepository;
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        [HttpGet("GetUsuarios")]
        public IActionResult GetUsuarios([FromQuery] int id)
        {
            var resultado = _usuarioRepository.GetUsuarios(id);
            return Ok(resultado);
        }

        //[HttpDelete("DeleteUsuarios")] no es parte de la entrega

        //public void DeleteUsuario([FromBody] int id)
        //{
        //    UsuarioRepository.DeleteUsuario(id);
        //}

        [HttpPut("UpdateUsuarios")]

        public void UpdateUsuario([FromBody] Usuario user)
        {
            UsuarioRepository.UpdateUsuario(user);
        }



    }
 }
