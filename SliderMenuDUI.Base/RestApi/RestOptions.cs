using SliderMenuDUI.Base.RestApi.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliderMenuDUI.Base.RestApi
{
	public class RestOptions
	{
        public Uri BaseUrl { get; set; }
        public string RequestFormat { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public bool UseSsl { get; set; }
    }
}
