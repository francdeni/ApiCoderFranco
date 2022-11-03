using ApiCoderFranco.Models;
using ApiCoderFranco.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoderFranco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        VentaRepository _ventaRepository;
        public VentaController()
        {
            _ventaRepository = new VentaRepository();
        }
        [HttpGet("GetVentas")]
        public IActionResult GetVentas([FromQuery] int idUser)
        {
            var resultado = _ventaRepository.GetVentas(idUser);
            return Ok(resultado);
        }

        [HttpPost("NewVenta")]
        public void NewVenta([FromQuery] List<ProductoVenta> productList,int idUser,string comentario)
        {
            VentaRepository.NewVenta(productList,idUser,comentario);
            
        }
    }
}
