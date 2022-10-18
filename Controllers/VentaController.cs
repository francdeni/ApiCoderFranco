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
        public ActionResult GetVentas()
        {
            var resultado = _ventaRepository.GetVentas();
            return Ok(resultado);
        }
    }
}
