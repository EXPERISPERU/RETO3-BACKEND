using backend.businesslogic.Interfaces.Contabilidad;
using backend.domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.services.Controllers.Contabilidad
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AsientoController : ControllerBase
    {
        private readonly IAsientoBL service;

        public AsientoController(IAsientoBL _service)
        {
            this.service = _service;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> getAsientoCaja(AsientoFilterDTO filter)
        {
            try
            {
                var result = await service.getAsientoCaja(filter);
                var fileBytes = await System.IO.File.ReadAllBytesAsync(result);
                var fileName = Path.GetFileName(result);
                System.IO.File.Delete(result);
                return File(fileBytes, "text/plain", fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Ocurrió un error al generar el archivo.",
                    error = ex.Message
                });
            }

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> getAsientoBancos(AsientoFilterDTO filter)
        {
            try
            {
                var result = await service.getAsientoBancos(filter);

                var fileBytes = await System.IO.File.ReadAllBytesAsync(result);
                var fileName = Path.GetFileName(result);
                System.IO.File.Delete(result);
                return File(fileBytes, "text/plain", fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Ocurrió un error al generar el archivo.",
                    error = ex.Message
                });
            }

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> getAsientoBoletas(AsientoFilterDTO filter)
        {
            try
            {
                var result = await service.getAsientoBoletas(filter);

                var fileBytes = await System.IO.File.ReadAllBytesAsync(result);
                var fileName = Path.GetFileName(result);
                System.IO.File.Delete(result);
                return File(fileBytes, "text/plain", fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Ocurrió un error al generar el archivo.",
                    error = ex.Message
                });
            }

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> getAsientoDevoluciones(AsientoFilterDTO filter)
        {
            try
            {
                var result = await service.getAsientoDevoluciones(filter);

                var fileBytes = await System.IO.File.ReadAllBytesAsync(result);
                var fileName = Path.GetFileName(result);
                System.IO.File.Delete(result);
                return File(fileBytes, "text/plain", fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Ocurrió un error al generar el archivo.",
                    error = ex.Message
                });
            }

        }


        [HttpPost("[action]")]
        public async Task<IActionResult> getAsientoIzipay(AsientoFilterDTO filter)
        {
            try
            {
                var result = await service.getAsientoIzipay(filter);

                var fileBytes = await System.IO.File.ReadAllBytesAsync(result);
                var fileName = Path.GetFileName(result);
                System.IO.File.Delete(result);
                return File(fileBytes, "text/plain", fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Ocurrió un error al generar el archivo.",
                    error = ex.Message
                });
            }

        }

        #region VISITA GUIADA

        [HttpPost("[action]")]
        public async Task<IActionResult> getVisitaGuiadaBoletas(AsientoFilterDTO filter)
        {
            try
            {
                var result = await service.getVisitaGuiadaBoletas(filter);
                var fileBytes = await System.IO.File.ReadAllBytesAsync(result);
                var fileName = Path.GetFileName(result);
                System.IO.File.Delete(result);
                return File(fileBytes, "text/plain", fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Ocurrió un error al generar el archivo.",
                    error = ex.Message
                });
            }

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> getVisitaGuiadaBanco(AsientoFilterDTO filter)
        {
            try
            {
                var result = await service.getVisitaGuiadaBanco(filter);

                var fileBytes = await System.IO.File.ReadAllBytesAsync(result);
                var fileName = Path.GetFileName(result);
                System.IO.File.Delete(result);
                return File(fileBytes, "text/plain", fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Ocurrió un error al generar el archivo.",
                    error = ex.Message
                });
            }

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> getVisitaGuiadaCaja(AsientoFilterDTO filter)
        {
            try
            {
                var result = await service.getVisitaGuiadaCaja(filter);

                var fileBytes = await System.IO.File.ReadAllBytesAsync(result);
                var fileName = Path.GetFileName(result);
                System.IO.File.Delete(result);
                return File(fileBytes, "text/plain", fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Ocurrió un error al generar el archivo.",
                    error = ex.Message
                });
            }

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> getVisitaGuiadaNotaC(AsientoFilterDTO filter)
        {
            try
            {
                var result = await service.getVisitaGuiadaNotaC(filter);

                var fileBytes = await System.IO.File.ReadAllBytesAsync(result);
                var fileName = Path.GetFileName(result);
                System.IO.File.Delete(result);
                return File(fileBytes, "text/plain", fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Ocurrió un error al generar el archivo.",
                    error = ex.Message
                });
            }

        }

        #endregion
    }
}
