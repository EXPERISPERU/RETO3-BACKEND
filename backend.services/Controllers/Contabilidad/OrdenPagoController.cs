using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Contabilidad
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdenPagoController : ControllerBase
    {

    }
}
