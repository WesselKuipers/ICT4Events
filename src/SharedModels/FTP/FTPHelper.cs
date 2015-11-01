using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SharedModels.Debug;

namespace SharedModels.FTP
{
    public static class FtpHelper
    {
        public static string ServerAddress => Properties.Settings.Default.FTPAddress;
        public static string ServerHardLogin => "ftp://"+ Properties.Settings.Default.FTPUser + ":"+ Properties.Settings.Default.FTPPassword +"@"+ Properties.Settings.Default.FTPAddress;
        private static NetworkCredential DefaultCredentials => new NetworkCredential(Properties.Settings.Default.FTPUser, Properties.Settings.Default.FTPPassword);

        public static bool CreateDirectory(string path)
        {
            try
            {
                var requestDir = (FtpWebRequest)WebRequest.Create(new Uri($"ftp://{ServerAddress}/{path}"));
                requestDir.Credentials = DefaultCredentials;
                requestDir.Method = WebRequestMethods.Ftp.MakeDirectory;
                requestDir.UsePassive = true;
                requestDir.UseBinary = true;
                requestDir.KeepAlive = false;
                var response = (FtpWebResponse)requestDir.GetResponse();
                var ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();

                return true;
            }
            catch (WebException ex)
            {
                var response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    response.Close();
                    return true;
                }
                Logger.Write(ex.Message);
                response.Close();
                return false;
            }
        }

        public static bool UploadFile(string infilepath, string outfilepath)
        {
            using (var request = new WebClient())
            {
                request.Credentials = DefaultCredentials;
                try
                {
                    request.UploadFileAsync(new Uri($"ftp://{ServerAddress}/{outfilepath}"), "STOR", infilepath);
                    return true;
                }
                catch (WebException ex)
                {
                    Logger.Write(ex.Message);
                    return false;
                }
            }
        }

        public static bool DownloadFile(string infilepath, string outfilepath)
        {
            using (var request = new WebClient())
            {
                request.Credentials = DefaultCredentials;
                try
                {
                    request.DownloadFileAsync(new Uri($"ftp://{ServerAddress}/{infilepath}"), outfilepath);
                    return true;
                }
                catch (WebException ex)
                {
                    Logger.Write(ex.Message);
                    return false;
                }
            }
        }

        public static byte[] DownloadFile(string filepath)
        {
            var request = (FtpWebRequest)WebRequest.Create(new Uri($"ftp://{ServerAddress}/{filepath}"));
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            request.Credentials = DefaultCredentials;

            using (var response = (FtpWebResponse) request.GetResponse())
            {



                var responseStream = response.GetResponseStream();
                var buffer = new byte[responseStream.Length + 16];
                var bytesRead = 0;
                var bytesToRead = (int) responseStream.Length;

                do
                {
                    var readCount = responseStream.Read(buffer, bytesRead, 16);
                    bytesRead += readCount;
                    bytesToRead -= readCount;

                } while (bytesToRead > 0);

                return buffer;
            }
        }

        public static bool DeleteFile(string filepath)
        {
            var request = (FtpWebRequest)WebRequest.Create(new Uri($"ftp://{ServerAddress}/{filepath}"));
            request.Method = WebRequestMethods.Ftp.DeleteFile;

            request.Credentials = DefaultCredentials;
            using (var response = (FtpWebResponse)request.GetResponse())
            {
                Console.WriteLine(response.StatusDescription);
                return true;
            }
        }
    }
}
