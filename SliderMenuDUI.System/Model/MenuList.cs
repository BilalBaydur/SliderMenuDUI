using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SliderMenuDUI.Systems.Model
{
	public class MenuList
	{
		public int ActionID { get; set; }
		public string ActionName { get; set; }
		public string Caption { get; set; }
		public bool IsFolder { get; set; }
		public short? RightType { get; set; }
		public short? ImageIndex { get; set; }

		public DrawingImage Image { 
			get {
				switch (ImageIndex)
				{
					case 1:
						{
							return Application.Current.Resources.MergedDictionaries[0]["ic_Add"] as DrawingImage;
						}
					case 25:
						{
							return Application.Current.Resources.MergedDictionaries[0]["ic_list"] as DrawingImage;
						}
				}

				return null;
				} 
		}
		public short? UserActionRight { get; set; }
		public ObservableCollection<MenuList> items { get; set; }

		public MenuList()
		{
			this.items = new ObservableCollection<MenuList>();
		}
	}
}
