﻿using backend.businesslogic.Interfaces.Comercial;
using backend.businesslogic.Interfaces.Contabilidad;
using backend.businesslogic.Interfaces.Contratos;
using backend.businesslogic.Interfaces.Tesoreria;
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
        IOperacionBancariaBL operacionBancariaService;

        public RecaudoBBVAController(IOrdenPagoBL _ordenPagoService, IClienteBL _clienteService, ICronogramaBL _cronogramaService, IOperacionBancariaBL _operacionBancariaService)
        {
            ordenPagoService = _ordenPagoService;
            clienteService = _clienteService;
            cronogramaService = _cronogramaService;
            operacionBancariaService = _operacionBancariaService;
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
                var nConvenio = request.ConsultarDeuda.recaudosRq.cabecera.operacion.codigoConvenio;

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
                    var listDocumentos = await ordenPagoService.getListOrdenPagoRecaudoBBVAbyDocumento(sDocumento, nConvenio);

                    if (listDocumentos.Count == 0)
                    {
                        listDocumentos = await cronogramaService.getListCronogramasRecaudoBBVAbyDocumento(sDocumento, nConvenio);

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

                var sDocumento = request.NotificarPago.recaudosRq.detalle.transaccion.numeroReferenciaDeuda;
                var nConvenio = request.NotificarPago.recaudosRq.cabecera.operacion.codigoConvenio;

                switch (sTipo)
                {
                    case "OPV2":
                        var ordenPago = await ordenPagoService.getOrdenPagoRecaudoBBVAbyDocumentoAndID(sDocumento, nConvenio, nCodigo);
                        if (ordenPago == null)
                        {
                            response.NotificarPagoResponse.recaudosRs.detalle.respuesta = new bbvaRespuesta()
                            {
                                codigo = "3002",
                                descripcion = "NO SE PUDO REALIZAR LA TRANSACCION"
                            };
                        }
                        else
                        {
                            if (request.NotificarPago.recaudosRq.detalle.transaccion.importeDeudaPagada != Decimal.Parse(ordenPago.importeDeuda))
                            {
                                response.NotificarPagoResponse.recaudosRs.detalle.respuesta = new bbvaRespuesta()
                                {
                                    codigo = "3002",
                                    descripcion = "NO SE PUDO REALIZAR LA TRANSACCION"
                                };
                            }
                            else
                            {
                                var fechaOP = DateTime.ParseExact(request.NotificarPago.recaudosRq.cabecera.operacion.fechaOperacion, "yyyyMMdd", null);

                                var operacionBancaria = new InsOperacionBancariaRecaudoBBVA() {
                                    nConvenio = nConvenio
                                    ,sReferencia = request.NotificarPago.recaudosRq.detalle.transaccion.numeroDocumento
                                    ,nMovimiento = request.NotificarPago.recaudosRq.detalle.transaccion.numeroOperacionRecaudos.Value
                                    ,dFechaOperacion = fechaOP
                                    ,nImporte = request.NotificarPago.recaudosRq.detalle.transaccion.importeDeudaPagada.Value
                                };
                                var resInsOB = await operacionBancariaService.InsOperacionBancariaRecaudoBBVA(operacionBancaria);

                                if (resInsOB.nCod > 0)
                                {
                                    response.NotificarPagoResponse.recaudosRs.detalle.respuesta = new bbvaRespuesta()
                                    {
                                        codigo = "0001",
                                        descripcion = "TRANSACCION REALIZADA CON EXITO"
                                    };

                                    response.NotificarPagoResponse.recaudosRs.detalle.transaccion = request.NotificarPago.recaudosRq.detalle.transaccion;
                                }
                                else
                                {
                                    response.NotificarPagoResponse.recaudosRs.detalle.respuesta = new bbvaRespuesta()
                                    {
                                        codigo = "3002",
                                        descripcion = "NO SE PUDO REALIZAR LA TRANSACCION"
                                    };
                                }
                            }
                        }
                        break;
                    case "CRO2":
                        var cronograma = await cronogramaService.getCronogramaRecaudoBBVAbyDocumentoAndID(sDocumento, nConvenio, nCodigo);
                        if (cronograma == null)
                        {
                            response.NotificarPagoResponse.recaudosRs.detalle.respuesta = new bbvaRespuesta()
                            {
                                codigo = "3002",
                                descripcion = "NO SE PUDO REALIZAR LA TRANSACCION"
                            };
                        }
                        else
                        {
                            if (request.NotificarPago.recaudosRq.detalle.transaccion.importeDeudaPagada != Decimal.Parse(cronograma.importeDeuda))
                            {
                                response.NotificarPagoResponse.recaudosRs.detalle.respuesta = new bbvaRespuesta()
                                {
                                    codigo = "3002",
                                    descripcion = "NO SE PUDO REALIZAR LA TRANSACCION"
                                };
                            }
                        }
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
