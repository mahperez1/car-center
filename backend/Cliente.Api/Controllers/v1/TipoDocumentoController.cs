using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Interface;
using Entidades.Parametrica; 

namespace Cliente.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocumentoServicio _tipoDocumentoServicio;
        public TipoDocumentoController(ITipoDocumentoServicio tipoDocumentoServicio)
        {
            _tipoDocumentoServicio = tipoDocumentoServicio;
        }


        [HttpGet("[action]")]
        public async Task<IList<TipoDocumento>> TipoDocumentoTodo()
        {
            IList<TipoDocumento> LstTipoDocumento = new List<TipoDocumento>();
            LstTipoDocumento = await _tipoDocumentoServicio.consultartodo();
            return LstTipoDocumento;
        }
    }
}
