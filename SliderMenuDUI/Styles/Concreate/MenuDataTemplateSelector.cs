using SliderMenuDUI.Systems.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SliderMenuDUI.Styles.Concreate
{
	public class MenuDataTemplateSelector : DataTemplateSelector
	{
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			FrameworkElement elemnt = container as FrameworkElement;
			MenuList menuItem = item as MenuList;
			if (menuItem.IsFolder)
			{
				return elemnt.FindResource("listDataTemplate") as DataTemplate;
			}
			else
			{
				return elemnt.FindResource("ItemsDataTemplate") as DataTemplate;
			}


		}
	}
}
