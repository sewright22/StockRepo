using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockFrontEnd.Model
{
    public class FtpFileDownloader
    {
        private string _url;

        public FtpFileDownloader(string url)
        {
            _url = url;
        }
        public string Read()
        {
            var retVal = "";
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_url);

            //var ftpRequest = FtpWebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("anonymous", "janeDoe@contoso.com");

            var response = request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            retVal = reader.ReadToEnd();

            reader.Close();
            response.Close();

            return retVal;
        }
    }
}
