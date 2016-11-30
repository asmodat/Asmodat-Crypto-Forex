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

        private string RestRequest(ObjRequest request)
        {
            var client = this.GetRestClient(request);
            var response = this.GetRestResponse(client, request);
            return response.Content;
        }

        private RestClient GetRestClient(ObjRequest request)
        {
            
            RestClient client = new RestClient();
            string url = ApiProperties.BaseBitfinexUrl + request.request;
            client.BaseUrl = new Uri(url);

            return client;
        }

        private RestRequest GetRestRequest(object obj)
        {
            string sJson = JsonConvert.SerializeObject(obj);
            string payload = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(sJson));
            string signatue = GetHexHashSignature(payload);
            var request = new RestRequest();
            request.Method = Method.POST;

            request.AddHeader(ApiProperties.ApiBfxApiKey, APIKey);
            request.AddHeader(ApiProperties.ApiBfxPayload, payload);
            request.AddHeader(ApiProperties.ApiBfxSignature, signatue);
            return request;
        }

        private IRestResponse GetRestResponse(RestClient client, object obj)
        {
            var response = client.Execute(this.GetRestRequest(obj));
            return response;
        }

       /* private void CheckToLogError(IRestResponse response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;
                case HttpStatusCode.OK:
                    break;
                default:
                    ErrorM
                    break;


            }
        }*/

       
    }
}
