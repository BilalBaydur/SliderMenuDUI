using Microsoft.Extensions.Configuration;
using SliderMenuDUI.Base.RestApi.Abstract;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliderMenuDUI.Base.RestApi
{
	public class RestApiClient:IRestApiClient
	{        
        public IRestClient client { get; set; }
        public IConfiguration _configuration { get; set; }
        private RestOptions webApiOptions { get; set; }



        public RestApiClient(IConfiguration configuration)
        {           
            _configuration = configuration;
            LoadConfig();

        }

        private void LoadConfig()
        {   
            //Web api baglantı bilgileri appsettings.json dosyasından alınıyor
            webApiOptions = _configuration.GetSection("WebApi").Get<RestOptions>();

            var clientOptions = new RestClientOptions(webApiOptions.BaseUrl);
            if (!webApiOptions.UseSsl)
            {
                clientOptions.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            }
            

            client = new RestClient(clientOptions);                      
            client.AddDefaultHeaders(webApiOptions.Headers);            
        }

        public async Task<RestResponse> ExecuteAsync(RestRequest requestPrm)
        {
            return await client.ExecuteAsync(requestPrm);
        }


        public async Task<RestResponse> GetAsync(string resourcePrm)
        {
            var request = GetRestRequest();
            request.Method = Method.Get;
            request.Resource = resourcePrm;
            return await ExecuteAsync(request);
          
        }

        public async Task<RestResponse> PostAsync(string resourcePrm, object objPrm)
        {
            var request = GetRestRequest();
            request.Method = Method.Post;
            request.Resource = resourcePrm;
            request.AddBody(objPrm);
            return await ExecuteAsync(request);
        }

        public async Task<RestResponse> PutAsync(string resourcePrm, object objPrm)
        {
            var request = GetRestRequest();
            request.Method = Method.Put;
            request.Resource = resourcePrm;
            request.AddBody(objPrm);
            return await ExecuteAsync(request);
        }

        public async Task<RestResponse> DeleteAsync(string resourcePrm, object objPrm)
        {
            var request = GetRestRequest();
            request.Method = Method.Delete;
            request.Resource = resourcePrm;
            request.AddBody(objPrm);
            return await ExecuteAsync(request);
        }

        private RestRequest GetRestRequest()
		{
            var request = new RestRequest();            
            
            if (webApiOptions.RequestFormat != "")
            {
                request.RequestFormat = webApiOptions.RequestFormat == "json" ? DataFormat.Json : DataFormat.Xml;
            }
            return request;
        }
    }
}
