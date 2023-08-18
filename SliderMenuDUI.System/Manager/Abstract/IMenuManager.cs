using SliderMenuDUI.Base.Results.Abstract;
using SliderMenuDUI.Systems.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliderMenuDUI.Systems.Manager.Abstract
{
	public interface IMenuManager
	{
		Task<IDataResult<List<MenuList>>> Get();
	}
}
