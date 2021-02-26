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
    public class MantenimientoController : ControllerBase
    {
        private readonly IMantenimientoServicio _mantenimientoServicio;
        public MantenimientoController(IMantenimientoServicio mantenimientoServicio)
        {
            _mantenimientoServicio = mantenimientoServicio;
        }

        [HttpGet("[action]")]
        public async Task<IList<Mantenimiento>> MantenimientoTodo()
        {
            IList<Mantenimiento> LstMantenimiento = new List<Mantenimiento>();
            LstMantenimiento = await _mantenimientoServicio.consultarTodo();
            return LstMantenimiento;
        }

    }
}
