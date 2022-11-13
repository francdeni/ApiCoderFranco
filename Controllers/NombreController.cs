using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiCoderFranco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ApiCoderFranco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NombreController : ControllerBase
    {
        /*Este apartado no se suele hacer en los trabajos,
        pero es la forma de que puedan ponerle su nombre a su App sin tocar el Front End*/
        [HttpGet]
        public string Get()
        {
            return "Proyecto Coder Franco D.N.";
        }
    }
}
