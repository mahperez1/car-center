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
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaServicio _personaServicio;
        public PersonaController(IPersonaServicio personaServicio)
        {
            _personaServicio = personaServicio;
        }

        [HttpGet("[action]")]
        public async Task<IList<Persona>> PersonaTodo()
        {
            IList<Persona> LstPersona = new List<Persona>();
            LstPersona = await _personaServicio.consultarTodo();
            return LstPersona;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Persona(Persona model)
        {
            bool respuesta = await _personaServicio.crear(model);
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
