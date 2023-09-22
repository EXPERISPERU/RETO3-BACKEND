using backend.services.Utils;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> DownloadFile(string sFile, string sFileExtension)
        {
            FtpClient client = new FtpClient();
            byte[] file = client.DownloadFile(sFile);
            return File(file, client.sContentType(sFileExtension));
        }
    }
}
