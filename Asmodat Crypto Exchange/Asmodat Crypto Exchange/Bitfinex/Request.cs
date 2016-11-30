using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Asmodat.BitfinexV1.API;
using Newtonsoft.Json;

using Asmodat.Abbreviate;
using Asmodat.Debugging;
using System.IO;
using RestSharp;

namespace Asmodat.BitfinexV1
{
    public partial class BitfinexManager
    {


        private string GetHexHashSignature(string payload)
        {
            byte[] hash = HashProvider.ComputeHash(Encoding.UTF8.GetBytes(payload));
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }


        private string Request(ObjRequest request, string method)
        {
            string sJson = JsonConvert.SerializeObject(request);
            string payload = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(sJson));
            string signatue = GetHexHashSignature(payload);
            string url = ApiProperties.BaseBitfinexUrl + request.request;

            HttpWebRequest hwrRequest = (HttpWebRequest)WebRequest.Create(url);
            hwrRequest.Headers.Add(ApiProperties.ApiBfxApiKey, APIKey);
            hwrRequest.Headers.Add(ApiProperties.ApiBfxPayload, payload);
            hwrRequest.Headers.Add(ApiProperties.ApiBfxSignature, signatue);
            hwrRequest.Method = method;

            string response = null;
            try
            {
                HttpWebResponse hwrResponse = (HttpWebResponse)hwrRequest.GetResponse();
                StreamReader stream = new StreamReader(hwrResponse.GetResponseStream());
                response = stream.ReadToEnd();
                stream.Close();
            }
            catch(WebException ex)
            {
                ex.ToOutput();
                StreamReader stream = new StreamReader(ex.Response.GetResponseStream());
                response = stream.ReadToEnd();
                stream.Close();
            }

            return response;
        }
        
    }
}
