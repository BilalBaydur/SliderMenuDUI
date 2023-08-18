using SliderMenuDUI.Systems.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SliderMenuDUI.View.UserControls
{
	/// <summary>
	/// Interaction logic for List.xaml
	/// </summary>
	public partial class ListUserControl : UserControl
	{
		public ListUserControl()
		{
			InitializeComponent();
		}

		public ListUserControl(MenuList menu)
		{
			InitializeComponent();
		}
	}
}
