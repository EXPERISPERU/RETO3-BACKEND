using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace backend.services.Controllers.Comercial
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReferidoController : ControllerBase
    {
        public readonly IReferidoBL service;

        public ReferidoController(IReferidoBL _service)
        {
            service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<ReferidoDTO>>>> getListReferido(int nIdUsuario, int nIdCompania)
        {
            ApiResponse<List<ReferidoDTO>> response = new ApiResponse<List<ReferidoDTO>>();

            try
            {
                var result = await service.getListReferido(nIdUsuario, nIdCompania);

                response.success = true;
                response.data = (List<ReferidoDTO>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<ReferidoDTO>>>> getListReferidoByCliente(int nIdCliente)
        {
            ApiResponse<List<ReferidoDTO>> response = new ApiResponse<List<ReferidoDTO>>();

            try
            {
                var result = await service.getListReferidoByCliente(nIdCliente);

                response.success = true;
                response.data = (List<ReferidoDTO>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<int>>> getValidAgregarReferido(int nIdUsuario, int nIdCompania)
        {
            ApiResponse<int> response = new ApiResponse<int>();

            try
            {
                var result = await service.getValidAgregarReferido(nIdUsuario, nIdCompania);

                response.success = (int) result == 1;
                response.data = (int) result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsReferido([FromBody] InsReferidoDTO insReferido)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsReferido(insReferido.nIdCliente, insReferido.nIdUsuario);

                response.success = result.nCod == 0 ? false : true;
                response.data = result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<PersonaDTO>>> findPersona(string? sDNI, string? sCE)
        {
            ApiResponse<PersonaDTO> response = new ApiResponse<PersonaDTO>();

            try
            {
                var result = await service.findPersona(sDNI, sCE);

                response.success = (result == null ? false : true);
                response.data = (PersonaDTO)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getListGeneros()
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getListGeneros();

                response.success = true;
                response.data = (List<SelectDTO>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getListEstadoCivil()
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getListEstadoCivil();

                response.success = true;
                response.data = (List<SelectDTO>)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<PersonaSunatDTO>>> findClienteSunatByDoc(string sDNI)
        {
            ApiResponse<PersonaSunatDTO> response = new ApiResponse<PersonaSunatDTO>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var jsonRQ = new SunatRQPersonaDTO() { tipDocu = 1, numDocu = sDNI, tipPers = "natural" };
                    var payload = JsonSerializer.Serialize(jsonRQ);
                    var content = new StringContent(payload, Encoding.UTF8, "application/json");
                    try
                    {
                        HttpResponseMessage res = await client.PostAsync("https://ww1.sunat.gob.pe/ol-ti-itatencionf5030/registro/solicitante", content);
                        res.EnsureSuccessStatusCode();
                        string responseBody = await res.Content.ReadAsStringAsync();
                        response.data = JsonSerializer.Deserialize<PersonaSunatDTO>(responseBody);
                        response.success = true;
                    }
                    catch (HttpRequestException e)
                    {
                        response.success = false;
                        response.errMsj = e.Message;
                    }
                }
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<int>>> getCantReferenciaActivaByPersona(int nIdPersona)
        {
            ApiResponse<int> response = new ApiResponse<int>();

            try
            {
                var result = await service.getCantReferenciaActivaByPersona(nIdPersona);

                response.success = true;
                response.data = (int)result;
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsj = ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsReferidoByPersona([FromBody] PersonaDTO persona)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsReferidoByPersona(persona);

                response.success = result.nCod == 0 ? false : true;
                response.data = result;
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
