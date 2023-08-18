using SliderMenuDUI.Base.Results;
using SliderMenuDUI.Base.Results.Abstract;
using SliderMenuDUI.Systems.Manager.Abstract;
using SliderMenuDUI.Systems.Model;
using SliderMenuDUI.Systems.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliderMenuDUI.Systems.Manager
{
	public class MenuManager: IMenuManager
	{
		private IMenuService _menuService;

		public MenuManager(IMenuService menuService)
		{
			_menuService = menuService;
		}

		public async Task<IDataResult<List<MenuList>>> Get()
		{
			var menuList = await _menuService.Get();

			if (!menuList.Success)
			{
				return new ErrorDataResult<List<MenuList>>(null, menuList.Message);
			}

			return new SuccessDataResult<List<MenuList>>(menuList.Data);

		}
	}
}
