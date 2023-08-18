using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SliderMenuDUI.Styles.Concreate
{
	public class TabItemTemplateSelector : DataTemplateSelector
	{
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			FrameworkElement elemnt = container as FrameworkElement;
			WindowTabItem tabItem = item as WindowTabItem;
			if (tabItem.Header == null)
			{
				return elemnt.FindResource("TabItemAddTemplate") as DataTemplate;
			}
			else
			{
				return elemnt.FindResource("TabItemPageTemplate") as DataTemplate;
			}
		}
	}
}
