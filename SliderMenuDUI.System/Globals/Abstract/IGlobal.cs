using SliderMenuDUI.Base.Token.Abstract;
using SliderMenuDUI.Systems.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliderMenuDUI.Systems.Globals.Abstract
{
	public interface IGlobal
	{
		string UserName { get; set; }
		string password { get; set; }
		string ServerName { get; set; }

		IResultToken TokenSetting { get; set; }
		List<MenuList> MenuList { get; set; }
	}
}
