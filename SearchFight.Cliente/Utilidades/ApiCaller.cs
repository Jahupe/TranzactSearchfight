using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Cliente
{
    public class ApiCaller
    {
        public static string consume_endpoint_method(string url, object obj, string method)
        {

            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Method = method;
            request.Accept = "application/json";
            request.ContentType = "application/json";

            if (Constantes.api_url.Contains("https"))
            {
                request.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            }

            byte[] byteArray = null;
            if (obj != null && method != "GET")
            {
                string data = JsonConvert.SerializeObject(obj);
                byteArray = Encoding.UTF8.GetBytes(data);
                request.ContentLength = byteArray.Length;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
            }

            WebResponse ws = request.GetResponse();
            using (Stream stream = ws.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string response = reader.ReadToEnd();
                return response;
            }
        }
    }
}
