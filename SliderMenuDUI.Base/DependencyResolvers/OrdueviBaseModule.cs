using Microsoft.Extensions.DependencyInjection;
using SliderMenuDUI.Base.RestApi;
using SliderMenuDUI.Base.RestApi.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliderMenuDUI.Base.DependencyResolvers
{
	public static class SliderMenuBaseModule
	{
		public static void UseSliderMenuBaseModule(this IServiceCollection services)
		{
			services.AddScoped<IRestApiClient, RestApiClient>();

		}
	}
}
