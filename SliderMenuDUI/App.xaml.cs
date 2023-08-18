using Microsoft.Extensions.DependencyInjection;
using SliderMenuDUI.View;
using System;
using System.IO;
using System.Windows;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using SliderMenuDUI.ViewModel.Abstract;
using SliderMenuDUI.ViewModel;
using SliderMenuDUI.DependencyResolvers;
using SliderMenuDUI.Systems.DependencyResolvers;
using SliderMenuDUI.Base.DependencyResolvers;
using SliderMenuDUI.Base.RestApi.Abstract;
using SliderMenuDUI.Base.RestApi;
using SliderMenuDUI.Systems.Globals.Abstract;
using SliderMenuDUI.Systems.Globals;

namespace SliderMenuDUI
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public IServiceProvider ServiceProvider { get; private set; }
		public IConfiguration Configuration { get; set; }
		


		public App()
		{
			//Appsetting.json kullanılmak için ayarlanıyor
			IConfigurationBuilder builder = new ConfigurationBuilder()		
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

			IConfiguration configuration = builder.Build();


			/*
			var containerBuilder = new ContainerBuilder();
			containerBuilder.RegisterInstance<IConfiguration>(configuration);
			containerBuilder.RegisterModule<SliderMenuDUIModule>();
			container = containerBuilder.Build();
			*/

			
			var serviceCollection = new ServiceCollection();	
			//IConfiguration servis olarak kaydediliyor
			serviceCollection.AddSingleton<IConfiguration>(configuration);
			serviceCollection.UseSliderMenuDUIModule();
			serviceCollection.UseSliderMenuSystemsModule();
			serviceCollection.UseSliderMenuBaseModule();

			//ConfigurationServices(serviceCollection);

			ServiceProvider = serviceCollection.BuildServiceProvider();
			
		}

		
		protected  void OnStartup(object sender, StartupEventArgs e)
		{
			/*
			var builder = new ConfigurationBuilder();			
			Configuration = builder.Build();
            */ 

			
			var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
			try
			{
				mainWindow.Show();
			}
			catch
			{

			}		
				
		
						
		}
		
		private static void ConfigurationServices(IServiceCollection services)
		{
			//services.AddScoped<ILoginService, LoginService>();

			//services.AddScoped<ILoginService, LoginService>();
			//services.AddScoped<ILoginService, LoginService>();
			//services.AddScoped<ILoginManager, LoginManager>();
			services.AddScoped<IRestApiClient, RestApiClient>();
			services.AddScoped<IMainWindowVM, MainWindowVM>();

			services.AddSingleton<IGlobal, Global>();			

			

			//services.AddTransient(typeof(MainWindow));
			services.AddSingleton(typeof(LoginScreen));
			services.AddSingleton(typeof(MainWindow));
		}
	}
}
