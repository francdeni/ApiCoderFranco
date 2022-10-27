using ApiCoderFranco.Models;
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

        [HttpPost("NewProductos")]
        public void NewProducto([FromBody] Producto newprod)
        {
            ProductoRepository.NewProducto(newprod);
        }
        [HttpPut("UpdateProductos")]
        public void UpdateProd([FromBody] Producto prod)
        {
            ProductoRepository.UpdateProd(prod);
        }

        [HttpDelete("UpdateProductos")]
        public void DeleteProd([FromBody] int id)
        {
            ProductoRepository.DeleteProd(id);
        }


    }
}
    

