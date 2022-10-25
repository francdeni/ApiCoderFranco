using ApiCoderFranco.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoderFranco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        ProductoRepository _productoRepository;
        public ProductoController()
        {
            _productoRepository = new ProductoRepository();
        }
        [HttpGet("GetProductos")]
        public IActionResult GetProductos([FromQuery] int idUser)
        {
            var resultado = _productoRepository.GetProductos(idUser);
            return Ok(resultado);
        }
    }
    }
    

