using ApiCoderFranco.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoderFranco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVentaController : ControllerBase
    {
        ProductoVentaRepository _productoVentaRepository;
        public ProductoVentaController()
        {
            _productoVentaRepository = new ProductoVentaRepository();
        }
        [HttpGet("GetProdVentas")]
        public  IActionResult GetProdVentas([FromQuery] int idUser)
        {
            var resultado = ProductoVentaRepository.GetProdVentas(idUser);
            return Ok(resultado);
        }
    }
}
