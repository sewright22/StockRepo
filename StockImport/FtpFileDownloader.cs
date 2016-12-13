using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockImport
{
    public class FtpFileDownloader
    {
        public string Download(string url)
        {
            string retVal = "";

            //FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://ftp.nasdaqtrader.com/SymbolDirectory/otherlisted.txt");
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);

            request.Method = WebRequestMethods.Ftp.DownloadFile;

            //request.Credentials = new NetworkCredential("anonymous", "janeDoe@contoso.com");

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
