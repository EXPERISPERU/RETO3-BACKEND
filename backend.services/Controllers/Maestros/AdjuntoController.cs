using backend.services.Utils;
using iText.Html2pdf.Resolver.Font;
using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Mvc;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout;
using backend.domain;
using iText.Kernel.Events;
using iText.Kernel.Pdf.Canvas;

namespace backend.services.Controllers.Maestros
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdjuntoController : ControllerBase
    {

        [HttpPost("[action]")]
        public async Task<ActionResult<ApiResponse<string>>> UploadFile([FromBody] imbFile file)
        {
            FtpClient ftpClient = new FtpClient();
            var rsp = ftpClient.UploadFile(file);

            return StatusCode(StatusCodes.Status200OK, rsp);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> DownloadFile(string sRutaFile)
        {
            try
            {
                FtpClient client = new FtpClient();
                byte[] file = client.DownloadFile(sRutaFile);
                var extension = sRutaFile.Split('/')
                                            .Last()
                                            .Split('.')
                                            .Last()
                                            .ToLower();
                return File(file, client.sContentType(extension), sRutaFile.Split('/').Last());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetFormato()
        {
            try
            {
                var sCuerpo = "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>FICHA INSCRIPCION</title>\r\n\r\n    <style>\r\n        body {\r\n            font-size: 12px;\r\n        }\r\n\r\n        .casilla {\r\n            border-style: solid;\r\n            border-width: 1px;\r\n            border-color: black;\r\n            padding: 5px;\r\n        }\r\n\r\n        .casilla-2 {\r\n            border-style: solid;\r\n            border-width: 2px;\r\n            border-color: black;\r\n            padding: 5px;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <h4 style=\"text-align: center; font-size: 12px;\">FICHA DE INSCRIPCION COMO BENEFICIARIO DEL \"CENTRO URBANO #sProyecto#\"</h4>\r\n    <table style=\"width: 100%; border-collapse: collapse;\">\r\n        <tr>\r\n            <td style=\"width: 50%;\"><strong>1.- DATOS DEL SOLICITANTE</strong></td>\r\n            <td style=\"text-align: right; padding-right: 10px;\"><strong>FECHA</strong></td>\r\n            <td style=\"width: 35px; text-align: center;\" class=\"casilla\">#sFechaFirmaDia#</td>\r\n            <td style=\"width: 35px; text-align: center;\" class=\"casilla\">#sFechaFirmaMes#</td>\r\n            <td style=\"width: 35px; text-align: center;\" class=\"casilla\">#sFechaFirmaAnio#</td>\r\n        </tr>\r\n    </table>\r\n    <table style=\"width: 100%; margin-top: 5px; border-spacing: 0px 10px;\">\r\n        <tr>\r\n            <td style=\"width: 15%;\">Apellido Paterno:</td>\r\n            <td class=\"casilla\">#sApellidoPaterno#</td>\r\n            <td style=\"padding-left: 10px;\">Apellido Materno:</td>\r\n            <td class=\"casilla\">#sApellidoMaterno#</td>\r\n            <td style=\"padding-left: 10px;\">Nombres:</td>\r\n            <td class=\"casilla\">#sApellidoNombre#</td>\r\n        </tr>\r\n        <tr>\r\n            <td style=\"width: 15%;\">Nacionalidad:</td>\r\n            <td class=\"casilla\">#sNacionalidad#</td>\r\n            <td style=\"padding-left: 10px;\">DNI:</td>\r\n            <td class=\"casilla\">#sDNI#</td>\r\n            <td style=\"padding-left: 10px;\">CE:</td>\r\n            <td class=\"casilla\">#sCE#</td>\r\n        </tr>\r\n    </table>\r\n    <table style=\"width: 100%; border-spacing: 0px 10px;\">\r\n        <tr  style=\"height: 25px;\">\r\n            <td style=\"width: 15%;\">Estado Civil:</td>\r\n            <td style=\"width: 15%; padding-right: 10px; text-align: right;\">Soltero(a)</td>\r\n            <td style=\"width: 6.25%;\" class=\"casilla\"></td>\r\n            <td style=\"width: 15%; padding-right: 10px; text-align: right;\">Casado(a)</td>\r\n            <td style=\"width: 6.25%;\" class=\"casilla\"></td>\r\n            <td style=\"width: 15%; padding-right: 10px; text-align: right;\">Conviviente</td>\r\n            <td style=\"width: 6.25%;\" class=\"casilla\"></td>\r\n            <td style=\"width: 15%; padding-right: 10px; text-align: right;\">Viudo(a)</td>\r\n            <td style=\"width: 6.25%;\" class=\"casilla\"></td>\r\n        </tr>\r\n    </table>\r\n    <table style=\"width: 100%; border-spacing: 0px 10px;\">\r\n        <tr style=\"height: 25px;\">\r\n            <td colspan=\"6\">Esposo(a) o Conviviente:</td>\r\n        </tr>\r\n        <tr style=\"height: 25px;\">\r\n            <td style=\"width: 15%;\">Apellido Paterno:</td>\r\n            <td style=\"width: 17%;\" class=\"casilla\"></td>\r\n            <td style=\"width: 17%; padding-right: 10px; text-align: right;\">Apellido Materno:</td>\r\n            <td style=\"width: 17%;\" class=\"casilla\"></td>\r\n            <td style=\"width: 17%; padding-right: 10px; text-align: right;\">Nombres:</td>\r\n            <td style=\"width: 17%;\" class=\"casilla\"></td>\r\n        </tr>\r\n    </table>\r\n    <table style=\"width: 100%; border-spacing: 0px 10px;\">\r\n        <tr style=\"height: 25px;\">\r\n            <td style=\"width: 15%;\">Direccion:</td>\r\n            <td style=\"width: 15%; padding-right: 10px; text-align: right;\">Avenida</td>\r\n            <td style=\"width: 6.25%;\" class=\"casilla\"></td>\r\n            <td style=\"width: 15%; padding-right: 10px; text-align: right;\">Jirón</td>\r\n            <td style=\"width: 6.25%;\" class=\"casilla\"></td>\r\n            <td style=\"width: 15%; padding-right: 10px; text-align: right;\">Calle</td>\r\n            <td style=\"width: 6.25%;\" class=\"casilla\"></td>\r\n            <td style=\"width: 15%; padding-right: 10px; text-align: right;\">Pasaje</td>\r\n            <td style=\"width: 6.25%;\" class=\"casilla\"></td>\r\n        </tr>\r\n        <tr style=\"height: 25px;\">\r\n            <td style=\"width: 15%;\" colspan=\"1\">Nombre de via:</td>\r\n            <td colspan=\"8\" class=\"casilla\"></td>\r\n        </tr>\r\n    </table>\r\n    <table style=\"width: 100%; border-spacing: 0px 10px;\">\r\n        <tr style=\"height: 25px;\">\r\n            <td style=\"width: 15%;\">Nº Inmueble</td>\r\n            <td class=\"casilla\"></td>\r\n            <td style=\"padding-right: 10px; text-align: right;\">Piso</td>\r\n            <td class=\"casilla\"></td>\r\n            <td style=\"padding-right: 10px; text-align: right;\">Dpto.</td>\r\n            <td class=\"casilla\"></td>\r\n            <td style=\"padding-right: 10px; text-align: right;\">Block</td>\r\n            <td class=\"casilla\"></td>\r\n            <td style=\"padding-right: 10px; text-align: right;\">Mz.</td>\r\n            <td class=\"casilla\"></td>\r\n            <td style=\"padding-right: 10px; text-align: right;\">Lote</td>\r\n            <td class=\"casilla\"></td>\r\n            <td style=\"padding-right: 10px; text-align: right;\">Sector</td>\r\n            <td class=\"casilla\"></td>\r\n            <td style=\"padding-right: 10px; text-align: right;\">Km.</td>\r\n            <td class=\"casilla\"></td>\r\n        </tr>\r\n        <tr style=\"height: 25px;\">\r\n            <td style=\"width: 15%\" >Referencia:</td>\r\n            <td colspan=\"16\" class=\"casilla\"></td>\r\n        </tr>\r\n    </table>\r\n    <table style=\"width: 100%; border-spacing: 0px 10px;\">\r\n        <tr style=\"height: 25px;\">\r\n            <td style=\"width: 15%\" >Departamento</td>\r\n            <td style=\"width: 17%\" class=\"casilla\"></td>\r\n            <td style=\"width: 17%; padding-right: 10px; text-align: right;\">Provincia</td>\r\n            <td style=\"width: 17%\" class=\"casilla\"></td>\r\n            <td style=\"width: 17%; padding-right: 10px; text-align: right;\">Distrito</td>\r\n            <td style=\"width: 17%\" class=\"casilla\"></td>\r\n        </tr>\r\n    </table>\r\n    <table style=\"width: 100%; border-spacing: 0px 10px;\">\r\n        <tr style=\"height: 25px;\">\r\n            <td style=\"width: 15%\">Ocupación</td>\r\n            <td style=\"width: 12%\">Dependiente: </td>\r\n            <td style=\"width: 12%\" class=\"casilla\"></td>\r\n            <td style=\"width: 12%; padding-right: 10px; text-align: right;\">Independiente</td>\r\n            <td style=\"width: 12%\" class=\"casilla\"></td>\r\n            <td style=\"width: 15%; padding-right: 10px; text-align: right;\">Ingreso Mensual S/.</td>\r\n            <td style=\"width: 12%\" class=\"casilla\"></td>\r\n        </tr>\r\n        <tr style=\"height: 25px;\">\r\n            <td style=\"width: 15%\">Telefonos:</td>\r\n            <td style=\"width: 12%\">Cel. 1</td>\r\n            <td style=\"width: 12%\" class=\"casilla\"></td>\r\n            <td style=\"width: 12%; padding-right: 10px; text-align: right;\">Cel. 2</td>\r\n            <td style=\"width: 12%\" class=\"casilla\"></td>\r\n            <td style=\"width: 15%; padding-right: 10px; text-align: right;\">Fijo</td>\r\n            <td style=\"width: 12%\" class=\"casilla\"></td>\r\n        </tr>\r\n    </table>\r\n    <table style=\"width: 100%; border-spacing: 0px 10px;\">\r\n        <tr style=\"height: 25px;\">\r\n            <td style=\"width: 15%\">Correo Electrónico:</td>\r\n            <td style=\"width: 85%\" class=\"casilla\"></td>\r\n        </tr>\r\n    </table>\r\n    <table style=\"width: 100%; border-spacing: 0px 10px;\">\r\n        <tr style=\"height: 100px;\">\r\n            <td style=\"width: 15%; vertical-align: top;\"><strong>2.- SOLICITA: </strong></td>\r\n            <td style=\"width: 85%\" class=\"casilla-2\">\r\n                <div style=\"width: 100%; height: 75px;\"></div>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n    <table style=\"width: 100%; border-spacing: 0px 10px;\">\r\n        <tr style=\"height: 25px;\">\r\n            <td colspan=\"3\" style=\"vertical-align: top; font-size: 14px;\"><strong>3.- DOCUMENTOS QUE ADJUNTA: </strong></td>\r\n        </tr>\r\n    </table>\r\n    <table style=\"width: 100%; border-collapse: collapse;\">\r\n        <tr>\r\n            <td class=\"casilla\" style=\"text-align: center; font-size: 14px;\"><strong>Nº</strong></td>\r\n            <td class=\"casilla\" style=\"text-align: center; font-size: 14px;\"><strong>Documento</strong></td>\r\n            <td class=\"casilla\" ></td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"casilla\">1</td>\r\n            <td class=\"casilla\">Recibo de Servicio (Agua y/o Luz)</td>\r\n            <td class=\"casilla\"></td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"casilla\">2</td>\r\n            <td class=\"casilla\">Copia de DNI del Solicitante</td>\r\n            <td class=\"casilla\"></td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"casilla\">3</td>\r\n            <td class=\"casilla\">Carnet de Empadronamiento</td>\r\n            <td class=\"casilla\"></td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"casilla\">4</td>\r\n            <td class=\"casilla\">Contrato de Transferencia Posesión/Servicio</td>\r\n            <td class=\"casilla\"></td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"casilla\">5</td>\r\n            <td class=\"casilla\">Constancia de Entrega de Habilitacion Fisica</td>\r\n            <td class=\"casilla\"></td>\r\n        </tr>\r\n    </table>\r\n    <table style=\"width: 100%; border-spacing: 0px 10px;\">\r\n        <tr>\r\n            <td style=\"font-size: 14px;\"><strong>Declaro</strong> que los datos presentados en el presente formulario los realizo con caracter de <strong>DECLARACIÓN JURADA</strong></td>\r\n        </tr>\r\n    </table>\r\n    <table style=\"width:100%;\">\r\n        <tr style=\"text-align:center; vertical-align: bottom\">\r\n            <td style=\"width: 50%\">\r\n                <strong>\r\n                    Firma del Usuario<br>\r\n                    DNI:<br>\r\n                </strong>\r\n            </td>\r\n            <td style=\"width: 50%\">\r\n                <div class=\"casilla\" style=\"width: 60px; height: 75px; margin: 0 auto;\"></div>\r\n                <strong>Huella</strong>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n    <div style=\"float: right; margin-top: 10px;\">#sCodigoContrato#</div>\r\n</body>\r\n</html>";

                var html = "<style>.page-break { page-break-after: always; } </style>";

                html += "<div class=\"page-break\">";
                html += sCuerpo
                        .Replace("logo_inmobitec.png", dataLogoCompania.logoInmobitec2023);
                html += "</div>";

                string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid() + ".pdf");
                ConverterProperties properties = new ConverterProperties();
                properties.SetFontProvider(new DefaultFontProvider(true, true, true));
                PdfDocument pdfDocument = new PdfDocument(new PdfWriter(path));
                pdfDocument.SetDefaultPageSize(new PageSize(PageSize.A4));

                HtmlConverter.ConvertToPdf(html, pdfDocument, properties);

                byte[] file = System.IO.File.ReadAllBytes(path);
                return File(file, "application/pdf");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetFormatoPageNumber()
        {
            try
            {
                var sCuerpo = "<!DOCTYPE html>\r\n<html lang=\"es\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"ie=edge\">\r\n    <title>Cronopago</title>\r\n    <style>\r\n        * {\r\n            font-family: Arial, Helvetica, sans-serif;\r\n        }\r\n\r\n        table {\r\n            width: 100%;\r\n        }\r\n\r\n        table,\r\n        th,\r\n        td {\r\n            border-collapse: collapse;\r\n            font-size: 14px;\r\n        }\r\n\r\n        h1 {\r\n            font-size: 1rem;\r\n        }\r\n\r\n        p {\r\n            font-size: 14px;\r\n            line-height: 4px;\r\n        }\r\n\r\n        img {\r\n            width: 100%;\r\n        }\r\n\r\n        hr {\r\n            border: none;\r\n            height: 1.5px;\r\n            background-color: rgb(46, 46, 46)\r\n        }\r\n\r\n        .font-bold {\r\n            font-weight: bold;\r\n        }\r\n\r\n        .right {\r\n            float: right;\r\n        }\r\n\r\n        .text-center {\r\n            text-align: center;\r\n        }\r\n        .label{\r\n            font-size: 10px;\r\n            font-weight: bold;\r\n            text-align: left;\r\n        }\r\n        .txt{\r\n            font-size: 10px;\r\n            text-align: left;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <p style=\"text-align: right; font-weight: bold;\">Cod. Contrato: #sCodigoContrato#</p>\r\n    <hr>\r\n    <table style=\"padding: 0px 0px 10px 0px\">\r\n        <tbody>\r\n            <tr>\r\n                <td style=\"width: 33%\">\r\n                    <img src=\"logo_inmobitec.png\" style=\"width: 120px\" alt=\"Logo de Inmobitec\">\r\n                </td>\r\n                <td style=\"width: 33%\">\r\n                    <h1>CRONOGRAMA DE PAGO</h1>\r\n                </td>\r\n                <td style=\"width: 33%;vertical-align: top;\">\r\n                    <p style=\"float: right\">Fecha: #sHOY#</p>\r\n                </td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n    <table>\r\n        <tbody>\r\n            <tr>\r\n                <td style=\"width: 50%\">\r\n                    <p>Calle Chinchon 910 San Isidro</p>\r\n                </td>\r\n                <td style=\"width: 50%; padding-left:80px;\">\r\n                    <p class=\"\"><span class=\"font-bold\">Proyecto:</span><br><br><br>\r\n                        #sProyectoDescripcion# - #sProyecto#\r\n                    </p>\r\n                </td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n    <hr>\r\n    <div style=\"width: 100%; display: table;\">\r\n        <h5 style=\"width:30%; display: table-cell; vertical-align: top; padding-left: 10px;\">DATOS DEL BENEFICIARIO</h5>\r\n        <h5 style=\"width:70%; display: table-cell; vertical-align: top; padding-left: 20px;\">DATOS DEL CONTRATO</h5>\r\n    </div>\r\n    <div style=\"width: 100%; display: table; border: 2px solid black; padding: 5px 10px; border-radius: 10px; text-align: center;\">\r\n        <div style=\"width:30%; display: table-cell; vertical-align: top;\">\r\n            <table style=\"width: 100%;\">\r\n                <tr>\r\n                    <td class=\"label\">Nombre:</td>\r\n                    <td class=\"txt\">#sNombreCliente#</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"label\">#sTipoDocumento#:</td>\r\n                    <td class=\"txt\">#sDocumento#</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"label\">Direccion:</td>\r\n                    <td class=\"txt\">#sDireccion#</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"label\">Referencia:</td>\r\n                    <td class=\"txt\">-</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"label\">Telefono:</td>\r\n                    <td class=\"txt\">#sTelefono#</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"label\">Correo:</td>\r\n                    <td class=\"txt\">#sCorreo#</td>\r\n                </tr>\r\n            </table>\r\n        </div>\r\n        <div style=\"display: table-cell; vertical-align: top; width: 1px; padding: 0px 0px 0px 10px; border-left: 2px solid black;\">\r\n        </div>\r\n        <div style=\"width:70%; display: table-cell; vertical-align: top;\">\r\n            <table style=\"width: 100%;\">\r\n                <tr>\r\n                    <td class=\"label\" style=\"width: 25%;\">F. Firma Contrato:</td>\r\n                    <td class=\"txt\" style=\"width: 25%;\">#sFechaFirma#</td>\r\n                    <td style=\"width: 50%;\">&nbsp;</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"label\">Predio:</td>\r\n                    <td class=\"txt\">Habilitacion Fisica</td>\r\n                    <td class=\"txt\"><span class=\"label\">Sect.:</span><span class=\"txt\">#sSector#</span> <span class=\"label\">Mz:</span><span class=\"txt\">#sMANZANA#</span> <span class=\"label\">Lt:</span><span class=\"txt\">#sLOTE#</span></td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"label\">Area:</td>\r\n                    <td class=\"txt\">#nMetraje# m<sup>2</sup></td>\r\n                    <td class=\"txt\">#sGrupo#</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"label\">Ubicacion:</td>\r\n                    <td class=\"txt\">#sUbicacion#</td>\r\n                    <td class=\"txt\">&nbsp;</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"label\">F: Pago:</td>\r\n                    <td class=\"txt\">#sFormaPago#</td>\r\n                    <td class=\"txt\">&nbsp;</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"label\">V. Comercial:</td>\r\n                    <td class=\"txt\">#sSimbolo# #nMontoFinal#</td>\r\n                    <td class=\"txt\"><span class=\"label\">Inicial: </span><span class=\"txt\"> #sSimbolo# #nMontoInicial#</span></td>\r\n                </tr>\r\n                \r\n                <tr>\r\n                    <td class=\"label\">Financiado:</td>\r\n                    <td class=\"txt\">#sSimbolo# #nMontoFinanciado#</td>\r\n                    <td class=\"txt\"><span class=\"label\">Nro. Cuotas: </span><span class=\"txt\"> #sSimbolo# #nValorCuota#</span></td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"label\">Asesor:</td>\r\n                    <td class=\"txt\" colspan=\"2\">#sPromotor#</td>\r\n                </tr>\r\n            </table>\r\n        </div>\r\n    </div>\r\n    <h5 style=\"margin-top: 10px\">INICIAL</h5>\r\n    <div style=\"width: 100%; margin-top:-20px\">\r\n        <table style=\"border: 1px solid black; width: 100%\">\r\n            <thead>\r\n                <tr>\r\n                    <th style=\"padding: 8px; font-size: 12px\">Concepto</th>\r\n                    <th style=\"padding: 8px; font-size: 12px\">Fecha Pago</th>\r\n                    <th style=\"padding: 8px; font-size: 12px\">Monto</th>\r\n                    <th style=\"padding: 8px; font-size: 12px\">Estado</th>\r\n                    <th style=\"padding: 8px; font-size: 12px\">Comprobante</th>\r\n                    <th style=\"padding: 8px; font-size: 12px\">F. Pago</th>\r\n                    <th style=\"padding: 8px; font-size: 12px\">OP</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n                #iniPagosInicial#\r\n                <tr class=\"text-center\" style=\"border: 1px solid black\">\r\n                    <td style=\"padding: 5px; font-size: 11px\">#sConceptoPago#</td>\r\n                    <td style=\"padding: 5px; font-size: 11px\">#sFecPago#</td>\r\n                    <td style=\"padding: 5px; font-size: 11px\">#sSimboloPago# #nMontoPago#</td>\r\n                    <td style=\"padding: 5px; font-size: 11px\">#sEstado#</td>\r\n                    <td style=\"padding: 5px; font-size: 11px\">#sComprobantePago#</td>\r\n                    <td style=\"padding: 5px; font-size: 11px\">#sFormaPago#</td>\r\n                    <td style=\"padding: 5px; font-size: 11px\">#sOPPago#</td>\r\n                </tr>\r\n                #iniPagosInicial#\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n    <h5>CRONOGRAMA DE CUOTAS</h5>\r\n    <div style=\"width: 100%; margin-top: -20px\">\r\n        <table style=\"border: 1px solid black; width: 100%\">\r\n            <thead>\r\n                <tr>\r\n                    <th style=\"padding: 8px; font-size: 11px\">Nro de cuota</th>\r\n                    <th style=\"padding: 8px; font-size: 11px\">Fecha Venc.</th>\r\n                    <th style=\"padding: 8px; font-size: 11px\">M. Cuota</th>\r\n                    <th style=\"padding: 8px; font-size: 11px\">Mora</th>\r\n                    <th style=\"padding: 8px; font-size: 11px\">Estado</th>\r\n                    <th style=\"padding: 8px; font-size: 11px\">Comprobante</th>\r\n                    <th style=\"padding: 8px; font-size: 11px\">F. Pago</th>\r\n                    <th style=\"padding: 8px; font-size: 11px\">OP</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n                #iniCuotas#\r\n                <tr class=\"text-center\" style=\"border: 1px solid black\">\r\n                    <td style=\"padding: 5px; font-size: 9px\">#sNroCuota#</td>\r\n                    <td style=\"padding: 5px; font-size: 9px\">#sFecVenCuota#</td>\r\n                    <td style=\"padding: 5px; font-size: 9px\">#sSimboloCuota# #sMontoCuota#</td>\r\n                    <td style=\"padding: 5px; font-size: 9px\">#sSimboloCuota# #sMoraCuota#</td>\r\n                    <td style=\"padding: 5px; font-size: 9px\">#sEstadoCuotaCuota#</td>\r\n                    <td style=\"padding: 5px; font-size: 9px\">#sComprobanteCuota#</td>\r\n                    <td style=\"padding: 5px; font-size: 9px\">#sFormaPagoCuota#</td>\r\n                    <td style=\"padding: 5px; font-size: 9px\">#sOPCuota</td>\r\n                </tr>\r\n                #finCuotas#\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</body>\r\n</html>";

                var html = "";

                html += sCuerpo
                        .Replace("logo_inmobitec.png", dataLogoCompania.logoInmobitec2023);

                string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid() + ".pdf");
                ConverterProperties properties = new ConverterProperties();
                properties.SetFontProvider(new DefaultFontProvider(true, true, true));
                PdfDocument pdfDocument = new PdfDocument(new PdfWriter(path));
                pdfDocument.SetDefaultPageSize(new PageSize(PageSize.A4));

                //Byte[] imageBytes = Convert.FromBase64String(dataLogoCompania.fondoConformidadContrato.Replace("data:image/png;base64,", ""));
                //Image image = new Image(ImageDataFactory.Create(imageBytes));
                //image.SetWidth(pdfDocument.GetDefaultPageSize().GetWidth());
                //image.SetHeight(pdfDocument.GetDefaultPageSize().GetHeight());
                //image.SetFixedPosition(0, 0);
                //image.SetOpacity(1f);
                //pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new BackgroundImageHandler(image));

                HtmlConverter.ConvertToPdf(html, pdfDocument, properties);

                string path2 = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid() + ".pdf");
                PdfDocument pdfDoc = new PdfDocument(new PdfReader(path), new PdfWriter(path2));
                Document doc = new Document(pdfDoc);

                int numberOfPages = pdfDoc.GetNumberOfPages();
                for (int i = 1; i <= numberOfPages; i++)
                {
                    doc.ShowTextAligned(new Paragraph(i + "/" + numberOfPages).SetFontSize(10), (pdfDocument.GetDefaultPageSize().GetWidth() / 2), 20, i, TextAlignment.RIGHT, VerticalAlignment.BOTTOM, 0);
                }

                doc.Close();

                byte[] file = System.IO.File.ReadAllBytes(path2);
                return File(file, "application/pdf");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public class BackgroundImageHandler : IEventHandler 
    {
        protected Image img;
        public BackgroundImageHandler(Image _img)
        {
            this.img = _img;
        }

        public void HandleEvent(Event @event) {
            PdfDocumentEvent docEvent = (PdfDocumentEvent) @event;
            PdfDocument pdfDoc = docEvent.GetDocument();
            PdfPage page = docEvent.GetPage();
            PdfCanvas canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
            Rectangle area = page.GetPageSize();
            new Canvas(canvas, area).Add(img);
        }
    }
}
