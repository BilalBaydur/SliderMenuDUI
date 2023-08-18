using SliderMenuDUI.Systems.Globals.Abstract;
using SliderMenuDUI.Systems.Manager.Abstract;
using SliderMenuDUI.Systems.Model;
using SliderMenuDUI.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliderMenuDUI.ViewModel
{
	/// <summary>
	/// Arayüz için data sağlar
	/// </summary>
	public class MainWindowVM:IMainWindowVM
	{
		private IGlobal _global;
		private IMenuManager _menuManager;
	
		public MainWindowVM(IGlobal global, IMenuManager menuManager)
		{
			_global = global;
			_menuManager = menuManager;			
		}

		#region Property block
		public string UserName { get { return _global.UserName; } }
		public List<MenuList> Menu { get { return _global.MenuList; } }
		#endregion

		#region Method
		public async Task LoadMenu()
		{
			var menulist = await _menuManager.Get();

			if (menulist.Success)
			{			
				_global.MenuList = menulist.Data;
			}
		}
		#endregion
	}
}
