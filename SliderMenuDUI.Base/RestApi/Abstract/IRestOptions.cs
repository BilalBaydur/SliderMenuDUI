using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliderMenuDUI.Base.RestApi.Abstract
{
	public interface IRestOptions
	{
		Uri BaseUrl { get; set; }
		string RequestFormat { get; set; }
		Dictionary<string, string> Headers { get; set; }
		bool UseSsl { get; set; }
	}
}
