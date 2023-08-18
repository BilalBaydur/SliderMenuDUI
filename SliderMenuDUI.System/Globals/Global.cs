
using SliderMenuDUI.Base.Token.Abstract;
using SliderMenuDUI.Systems.Globals.Abstract;
using SliderMenuDUI.Systems.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliderMenuDUI.Systems.Globals
{
	public class Global:IGlobal
	{
		public string UserName { get; set; }
		public string password { get; set; }
		public string ServerName { get; set; }

		public IResultToken TokenSetting { get; set; }
		public List<MenuList> MenuList { get; set; }
		
	}
}
