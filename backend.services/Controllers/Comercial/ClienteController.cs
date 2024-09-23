using backend.businesslogic.Interfaces.Comercial;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace backend.services.Controllers.Comercial
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteBL service;

        public ClienteController(IClienteBL _service)
        {
            this.service = _service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ApiResponse<List<ClienteDTO>>>> getListCliente(int nIdUsuario, int nIdCompania, int pagina, int cantpagina, string? sFiltro)
        {
            ApiResponse<List<ClienteDTO>> response = new ApiResponse<List<ClienteDTO>>();

            try
            {
                var result = await service.getListCliente(nIdUsuario, nIdCompania, pagina, cantpagina, sFiltro);

                response.success = true;
                response.data = (List<ClienteDTO>) result;
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
        public async Task<ActionResult<ApiResponse<ClienteDTO>>> getClienteByID(int nIdCompania, int nIdCliente)
        {
            ApiResponse<ClienteDTO> response = new ApiResponse<ClienteDTO>();

            try
            {
                var result = await service.getClienteByID(nIdCompania, nIdCliente);

                response.success = true;
                response.data = (ClienteDTO) result;
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
        public async Task<ActionResult<ApiResponse<ClienteDTO>>> findClienteByDoc(int nIdUsuario, string? sDNI, string? sCE, string? sRUC)
        {
            ApiResponse<ClienteDTO> response = new ApiResponse<ClienteDTO>();

            try
            {
                var result = await service.findClienteByDoc(nIdUsuario, sDNI, sCE, sRUC);

                response.success = (result == null ? false : true);
                response.data = (ClienteDTO) result;
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
        public async Task<ActionResult<ApiResponse<List<SelectDTO>>>> getListTiposPersona()
        {

            ApiResponse<List<SelectDTO>> response = new ApiResponse<List<SelectDTO>>();

            try
            {
                var result = await service.getListTiposPersona();

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

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postInsCliente([FromBody] ClienteDTO cliente)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.InsCliente(cliente);

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

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<SqlRspDTO>>> postUpdCliente([FromBody] ClienteDTO cliente)
        {
            ApiResponse<SqlRspDTO> response = new ApiResponse<SqlRspDTO>();

            try
            {
                var result = await service.UpdCliente(cliente);

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
        public async Task<ActionResult<ApiResponse<ClienteDTO>>> findClienteGCByDoc(int nIdUsuario, int nIdCompania, string? sDNI, string? sCE)
        {
            ApiResponse<ClienteDTO> response = new ApiResponse<ClienteDTO>();

            try
            {
                response = await service.findClienteGCByDoc(nIdUsuario, nIdCompania, sDNI, sCE);

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


        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<List<ClienteTrazabilidadDTO>>>> postListClienteTrazabilidad(ClienteTrazabilidadFilterDTO clienteTrazabilidadFilter)
        {
            ApiResponse<List<ClienteTrazabilidadDTO>> response = new ApiResponse<List<ClienteTrazabilidadDTO>>();
            try
            {
                var result = await service.postListClienteTrazabilidad(clienteTrazabilidadFilter);
                response.success = true;
                response.data = (List<ClienteTrazabilidadDTO>)result;
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
