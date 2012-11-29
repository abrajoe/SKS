using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SKS.Scada.DAL;
using System.Net;
using System.IO;

namespace SKS.Scada.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int myid = 1;
            string unit = "Fahrenheit";
            string uri = "http://localhost:2791/SiteService.svc/UploadMeasurement/" + myid + "/" + unit;
            double value = 1293;
            string json = "{\"value:\"\"" + value.ToString() + "\"}";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = json.Length;
            StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
            }
        }

        private static void ProcessNotOKResponse(HttpWebResponse webResponse)
        {
            throw new NotImplementedException();
        }

        private static void ProcessOKResponse(HttpWebResponse webResponse)
        {
            throw new NotImplementedException();
        }
    }
}
