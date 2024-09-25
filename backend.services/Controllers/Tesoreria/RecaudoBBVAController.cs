using backend.businesslogic.Interfaces.Comercial;
using backend.businesslogic.Interfaces.Contabilidad;
using backend.businesslogic.Interfaces.Contratos;
using backend.domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace backend.services.Controllers.Tesoreria
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecaudoBBVAController : ControllerBase
    {
        IOrdenPagoBL ordenPagoService;
        IClienteBL clienteService;
        ICronogramaBL cronogramaService;

        public RecaudoBBVAController(IOrdenPagoBL _ordenPagoService, IClienteBL _clienteService, ICronogramaBL _cronogramaService)
        {
            ordenPagoService = _ordenPagoService;
            clienteService = _clienteService;
            cronogramaService = _cronogramaService;
        }

        private string limpiarJson(object obj)
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return JsonSerializer.Serialize(obj, options);
        }

        private int ConvenioProyecto(int nConvenio)
        {
            switch (nConvenio) {
                case 18613:
                    return 1;
                case 18614:
                    return 2;
                case 18612:
                    return 3;
            }
            return 0;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<bbvaConsultarDeudaRs>> consultarDeuda([FromBody] bbvaConsultarDeudaRq request)
        {
            bbvaConsultarDeudaRs response = new bbvaConsultarDeudaRs()
            {
                ConsultarDeudaResponse = new bbvaResponse()
                {
                    recaudosRs = new bbvaRecaudo()
                    {
                        cabecera = request.ConsultarDeuda.recaudosRq.cabecera
                        ,detalle = new bbvaDetalle()
                    }
                }
            };

            try
            {
                var sDocumento = request.ConsultarDeuda.recaudosRq.detalle.transaccion.numeroReferenciaDeuda;
                var nCodigoProyecto = ConvenioProyecto(request.ConsultarDeuda.recaudosRq.cabecera.operacion.codigoConvenio);

                var client = await clienteService.findClienteByDoc(1, sDocumento, sDocumento, null);

                if (client == null)
                {
                    response.ConsultarDeudaResponse.recaudosRs.detalle.respuesta = new bbvaRespuesta()
                    {
                        codigo = "0101",
                        descripcion = "NUMERO DE REFERENCIA NO EXISTE"
                    };
                }
                else {
                    var listDocumentos = await ordenPagoService.getListOrdenPagoRecaudoBBVAbyDocumento(sDocumento, nCodigoProyecto);

                    if (listDocumentos.Count == 0)
                    {
                        listDocumentos = await cronogramaService.getListCronogramasRecaudoBBVAbyDocumento(sDocumento, nCodigoProyecto);

                        if (listDocumentos.Count == 0)
                        {
                            response.ConsultarDeudaResponse.recaudosRs.detalle.respuesta = new bbvaRespuesta()
                            {
                                codigo = "3009",
                                descripcion = "NO TIENE DEUDAS PENDIENTES"
                            };
                        }
                    }

                    if (listDocumentos.Count > 0)
                    {
                        response.ConsultarDeudaResponse.recaudosRs.detalle.respuesta = new bbvaRespuesta()
                        {
                            codigo = "0001",
                            descripcion = "TRANSACCION REALIZADA CON EXITO"
                        };

                        response.ConsultarDeudaResponse.recaudosRs.detalle.transaccion = new bbvaTransaccion()
                        {
                            numeroReferenciaDeuda = sDocumento,
                            nombreCliente = client.sNombreCompleto,
                            numeroOperacionEmpresa = client.nIdCliente.ToString(),
                            indMasDeuda = listDocumentos.Count > 1 ? 1 : 0,
                            cantidadDocsDeuda = listDocumentos.Count,
                            datosEmpresa = "",
                            listaDocumentos = new bbvaListaDocumento() { 
                                documento = listDocumentos.ToArray()
                            }
                        };
                    }
                }

                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles     
                    ,DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                return StatusCode(200, limpiarJson(response));
            }
            catch (Exception ex)
            {
                response.ConsultarDeudaResponse.recaudosRs.detalle.respuesta = new bbvaRespuesta()
                {
                    codigo = "3002",
                    descripcion = "NO SE PUDO REALIZAR LA TRANSACCION"
                };

                return StatusCode(200, limpiarJson(response));
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<bbvaNotificarPagoRs>> notificarPago([FromBody] bbvaNotificarPagoRq request)
        {
            bbvaNotificarPagoRs response = new bbvaNotificarPagoRs()
            {
                NotificarPagoResponse = new bbvaResponse()
                {
                    recaudosRs = new bbvaRecaudo()
                    {
                        cabecera = request.NotificarPago.recaudosRq.cabecera
                        ,
                        detalle = new bbvaDetalle()
                    }
                }
            };

            try
            {
                var sNumero = request.NotificarPago.recaudosRq.detalle.transaccion.numeroDocumento;
                var sTipo = sNumero.Split('-')[0];
                var nCodigo = int.Parse(sNumero.Split('-')[1]);

                switch (sTipo)
                {
                    case "OP2":
                        break;
                    case "CRO2":
                        break;
                }

                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                    ,DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                return StatusCode(200, limpiarJson(response));
            }
            catch (Exception ex)
            {
                response.NotificarPagoResponse.recaudosRs.detalle.respuesta = new bbvaRespuesta()
                {
                    codigo = "3002",
                    descripcion = "NO SE PUDO REALIZAR LA TRANSACCION"
                };

                return StatusCode(200, limpiarJson(response));
            }
        }
    }
}
