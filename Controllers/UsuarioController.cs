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
            var resultado = UsuarioRepository.GetUsuarios(id);
            return Ok(resultado);
        }

        [HttpGet("{nombreUsuario}/{contraseña}")]
        public Usuario GetUsuarioByContraseña(string nombreUsuario, string contraseña)
        {
            var usuario = UsuarioRepository.Getlogin(nombreUsuario, contraseña);

            return usuario == null ? new Usuario() : usuario;
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

        [HttpPost]
        public void CreateUsuario(Usuario usuario)
        {
            UsuarioRepository.CreateUsuario(usuario);
        }

        [HttpGet("{nombreUsuario}")]
        public Usuario GetUsuarioByNombre(string nombreUsuario)
        {
            var usuario = UsuarioRepository.GetUsuarioByNombre(nombreUsuario);

            return usuario == null ? new Usuario() : usuario;
        }

    }
 }
