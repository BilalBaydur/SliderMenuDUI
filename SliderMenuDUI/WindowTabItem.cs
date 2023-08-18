using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SliderMenuDUI
{

	public class WindowTabItem
	{
		public int ItemIndex { get; set; }		
		public string Header { get; set; }
		public UserControl Content { get; set; }

	}
}
