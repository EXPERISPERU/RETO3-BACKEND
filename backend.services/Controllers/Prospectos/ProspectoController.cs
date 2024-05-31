using backend.businesslogic.Interfaces.Prospectos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Prospectos
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProspectoController : Controller
    {
        private readonly IProspectoBL service;
        public ProspectoController(IProspectoBL _service)
        {
            this.service = _service;
        }






    }
}
