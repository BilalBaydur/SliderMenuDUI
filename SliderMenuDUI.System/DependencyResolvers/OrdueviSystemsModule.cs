using Microsoft.Extensions.DependencyInjection;
using SliderMenuDUI.Systems.Globals;
using SliderMenuDUI.Systems.Globals.Abstract;
using SliderMenuDUI.Systems.Manager;
using SliderMenuDUI.Systems.Manager.Abstract;
using SliderMenuDUI.Systems.Services;
using SliderMenuDUI.Systems.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliderMenuDUI.Systems.DependencyResolvers
{
	public static class SliderMenuSystemsModule
	{
		public static void UseSliderMenuSystemsModule(this IServiceCollection services)
		{
			services.AddScoped<ILoginService, LoginService>();
			services.AddScoped<ILoginManager, LoginManager>();
			services.AddScoped<IMenuService, MenuService>();
			services.AddScoped<IMenuManager, MenuManager>();
			services.AddSingleton<IGlobal, Global>();
		}
	}
}
