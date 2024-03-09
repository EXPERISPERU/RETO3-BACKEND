using backend.businesslogic.Interfaces.Cobranzas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Portales
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FormularioContactoController : Controller
    {
        //private readonly IFormularioContactoBL service;
        //public FormularioContactoController(IAsignacionClienteBL _service)
        //{
        //    this.service = _service;
        //}

    }
}
