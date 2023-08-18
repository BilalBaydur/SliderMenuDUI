using SliderMenuDUI.Base.RestApi.Abstract;
using SliderMenuDUI.Base.Results;
using SliderMenuDUI.Base.Results.Abstract;
using RestSharp;
using SliderMenuDUI.Base.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SliderMenuDUI.Systems.Globals.Abstract;
using SliderMenuDUI.Systems.Services.Abstract;
using SliderMenuDUI.Systems.Model;

namespace SliderMenuDUI.Systems.Services
{

	public class MenuService : IMenuService
	{
		private IRestApiClient _restApiClient;
		private IGlobal _global;

		public MenuService(IRestApiClient restApiClient, IGlobal global)
		{
			_restApiClient = restApiClient;
			_global = global;
			//Token eklenerek kullanılacak			
		}

		private void AddDefaultHeader()
		{
			//varsa tekrar eklenmemeli
			_restApiClient.client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", _global.TokenSetting.Token));
		}


		public async Task<IDataResult<List<MenuList>>> Get()
		{		
			List<MenuList> menuList = new List<MenuList>();

			MenuList altMenu = new MenuList() { Caption = "Muhasebe raporları", IsFolder = true };
			altMenu.items.Add(new MenuList() { Caption = "Rapor 1", IsFolder = false });

			MenuList menu = new MenuList() { Caption = "Muhasebe", IsFolder = true };
			menu.items.Add(new MenuList() { Caption = "Hesap Listesi", IsFolder = false });
			menu.items.Add(altMenu);


			menuList.Add(menu);
			menuList.Add(new MenuList() { Caption = "Kasa", IsFolder = true });
			menuList.Add(new MenuList() { Caption = "Demirbaş", IsFolder = true });
			return new SuccessDataResult<List<MenuList>>(menuList);

			/*
			AddDefaultHeader();

			var response = await _restApiClient.GetAsync("auth-api/ActionList/MenuYetki");
			if (!response.IsSuccessful)
			{

				if (response.ResponseStatus == ResponseStatus.Error)
				{
					string errorMessage = (response.ErrorMessage != null) ? response.ErrorMessage : "";
					return new ErrorDataResult<List<MenuList>>(null, errorMessage);
				}
				return new ErrorDataResult<List<MenuList>>(null, response.Content);
			}
			return new SuccessDataResult<List<MenuList>>(response.ToObject<List<MenuList>>());
			*/
		}
	}
}
