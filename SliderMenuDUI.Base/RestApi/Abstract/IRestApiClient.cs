using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliderMenuDUI.Base.RestApi.Abstract
{
    public interface IRestApiClient
    {
        IRestClient client { get; set; }
        //RestRequest request { get; set; }

        Task<RestResponse> ExecuteAsync(RestRequest requestPrm);
        Task<RestResponse> PostAsync(string resourcePrm, object objPrm);
        Task<RestResponse> GetAsync(string resourcePrm);
        Task<RestResponse> PutAsync(string resourcePrm, object objPrm);
        Task<RestResponse> DeleteAsync(string resourcePrm, object objPrm);
    }
}
