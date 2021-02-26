using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Interface;
using Entidades.Negocio;

namespace Cliente.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaServicio _facturaServicio;
        public FacturaController(IFacturaServicio facturaServicio)
        {
            _facturaServicio = facturaServicio;
        }

        [HttpGet("[action]")]
        public async Task<IList<Factura>> FacturaTodo()
        {
            IList<Factura> LstFactura = new List<Factura>();
            LstFactura = await _facturaServicio.consultarTodo();
            return LstFactura;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Factura(Factura model)
        {
            bool respuesta = await _facturaServicio.crear(model);
            if (respuesta)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
