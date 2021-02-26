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
    [Route("api/[controller]")]
    [ApiController]
    public class MecanicoController : ControllerBase
    {
        private readonly IMecanicoServicio _mecanicoServicio;
        public MecanicoController(IMecanicoServicio mecanicoServicio)
        {
            _mecanicoServicio = mecanicoServicio;
        }


        [HttpGet("[action]")]
        public async Task<IList<Mecanico>> MecanicoTodo()
        {
            IList<Mecanico> LstMecanico = new List<Mecanico>();
            LstMecanico = await _mecanicoServicio.consultarTodo();
            return LstMecanico;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Mecanico(Mecanico model)
        {
            bool respuesta = await _mecanicoServicio.crear(model);
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
