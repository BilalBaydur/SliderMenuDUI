using SliderMenuDUI.Systems.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliderMenuDUI.ViewModel.Abstract
{
	public interface IMainWindowVM
	{
		string UserName { get; }
		List<MenuList> Menu { get; }
		Task LoadMenu();
	}
}
