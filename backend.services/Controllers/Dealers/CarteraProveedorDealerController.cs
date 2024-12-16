using backend.businesslogic.Interfaces.Dealers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.repository.Interfaces.Dealers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.domain;

namespace backend.services.Controllers.Dealers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarteraProveedorDealerController : ControllerBase
    {
        public readonly ICarteraProveedorDealerBL service;
        
        public CarteraProveedorDealerController(ICarteraProveedorDealerBL _service)
        {
            service = _service;
        }

        [HttpPost("[action]")]

        public async Task<ActionResult<ApiResponse<List<CarteraProveedorDealerDTO>>>> getListCarteraProveedorDealer([FromBody] FilterCarteraDTO filter)
        {
            ApiResponse<List<CarteraProveedorDealerDTO>> response = new ApiResponse<List<CarteraProveedorDealerDTO>>();

            try
            {
                var result = await service.getListCarteraProveedorDealer(filter);

                response.success = true;
                response.data = (List<CarteraProveedorDealerDTO>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;

                return StatusCode(500, response);
            }

        }
    }
}