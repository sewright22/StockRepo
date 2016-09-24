using System.IO;
using System.Net;

namespace StockImport
{
    public class HttpFileDownloader
    {
        public string Download(string url)
        {
            string retVal = "";
            var request = WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;

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
