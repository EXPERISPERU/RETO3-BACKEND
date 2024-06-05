using System.Net;
using System;
using System.IO;
using System.Security.Cryptography;
using backend.domain;

namespace backend.services.Utils
{
    public class imbFile {
        public string sRutaFile { get; set; }
        public byte[]? data { get; set; }
    }

    public class FtpClient
    {
        private string ftpUrlServer;
        private string ftpUser;
        private string ftpPassword;
        private bool ftpPassiveMode;

        public FtpClient(IConfiguration configuration) 
        {
            ftpUrlServer = configuration["FTPConfig:url"];
            ftpUser = "imbftp";
            ftpPassword = "$1mbftpcl1";
            ftpPassiveMode = configuration["FTPConfig:passiveMode"] == "1";
        }

        public string sContentType(string sFileExtension)
        {
            switch (sFileExtension)
            {
                case "pdf":
                    return "application/pdf";
                case "jpeg":
                    return "image/jpeg";
                case "jpg":
                    return "image/jpeg";
                case "png":
                    return "image/png";
                default:
                    return "";
            }
        }

        public ApiResponse<string> ValidateFtpDirectory(string ftpPath)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrlServer + ftpPath);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(ftpUser, ftpPassword);
                request.UsePassive = ftpPassiveMode;

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    return new ApiResponse<string> { success = true, data = "OK", errMsj = "" };
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null && ex.Response is FtpWebResponse ftpResponse &&
                    ftpResponse.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return CreateFtpDirectory(ftpPath);
                }
                else
                {
                    return new ApiResponse<string> { success = false, data = "", errMsj = ex.Message };
                }
            }
        }

        private ApiResponse<string> CreateFtpDirectory(string ftpPath)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrlServer + ftpPath);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(ftpUser, ftpPassword);
                request.UsePassive = ftpPassiveMode;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();

                return new ApiResponse<string> { success = true, data = "OK", errMsj = "" };
            }
            catch (Exception ex)
            {
                return new ApiResponse<string> { success = false, data = "", errMsj = ex.Message };
            }
        }

        public ApiResponse<string> UploadFile(imbFile file)
        {
            try
            {
                string tempRes = "";
                for (int i = 0; i < file.sRutaFile.Split("/").Length - 1; i++)
                {
                    ApiResponse<string> res;
                    tempRes += file.sRutaFile.Split("/")[i] + "/";
                    res = ValidateFtpDirectory(tempRes);

                    if (!res.success) return res;
                }

                FtpWebRequest request = (FtpWebRequest) WebRequest.Create(ftpUrlServer+file.sRutaFile);
                request.Credentials = new NetworkCredential(ftpUser, ftpPassword);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UsePassive = ftpPassiveMode;

                byte[] bytes = file.data;

                request.ContentLength = bytes.Length;
                using (Stream request_stream = request.GetRequestStream())
                {
                    request_stream.Write(bytes, 0, bytes.Length);
                    request_stream.Close();
                }

                return new ApiResponse<string> { success = true, data = "OK", errMsj = "" };
            }
            catch (Exception e)
            {
                return new ApiResponse<string> { success = false, data = "", errMsj = e.Message };
            }
        }

        public byte[] DownloadFile(string sArchivo)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest) WebRequest.Create(ftpUrlServer + sArchivo);
                request.Credentials = new NetworkCredential(ftpUser, ftpPassword);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.UsePassive = ftpPassiveMode;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();

                MemoryStream ms = new MemoryStream();
                byte[] chunk = new byte[4096];
                int bytesRead;
                while ((bytesRead = responseStream.Read(chunk, 0, chunk.Length)) > 0)
                {
                    ms.Write(chunk, 0, bytesRead);
                }

                return ms.ToArray();
            }
            catch (Exception e)
            {
                return new byte[0];
            }
        }
    }
}
