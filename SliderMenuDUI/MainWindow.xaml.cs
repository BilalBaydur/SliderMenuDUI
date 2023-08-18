using Microsoft.Extensions.DependencyInjection;
using SliderMenuDUI.Systems.Globals.Abstract;
using SliderMenuDUI.Systems.Model;
using SliderMenuDUI.View;
using SliderMenuDUI.View.UserControls;
using SliderMenuDUI.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SliderMenuDUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ThicknessAnimation MenuOpenAnimation { get; set; }
		private ThicknessAnimation MenuCloseAnimation { get; set; }
		private bool IsOpenMenu { get; set; }
		private Button SelectedButton { get; set; }

		private LoginScreen _loginScreen;
		private IMainWindowVM _mainWindowVM;		



		public MainWindow(LoginScreen loginScreen, IMainWindowVM mainWindowVM)
		{

			_loginScreen = loginScreen;
			_mainWindowVM = mainWindowVM;			
			
			InitializeComponent();
			
			IsOpenMenu = false;
			InitializeMenu();
			PrepareAnimation();
		}

		private async void Window_Initialized(object sender, EventArgs e)
		{
			//var loginScreen = ServiceProvider.GetRequiredService<LoginScreen>();
			//var loginScreen = new  LoginScreen();
			if (_loginScreen.ShowDialog() == false)
			{
				this.Close();
			}


			await _mainWindowVM.LoadMenu();			
		    DataContext = _mainWindowVM;
			//trvMenu.DataContext = _mainWindowVM.Menu;
			
		}

		private void Window_Activated(object sender, EventArgs e)
		{

		}
		#region window
		private void Window_SourceInitialized(object sender, EventArgs e)
		{
			IntPtr mWindowHandle = (new WindowInteropHelper(this)).Handle;
			HwndSource.FromHwnd(mWindowHandle).AddHook(new HwndSourceHook(WindowProc));
		}

		private static System.IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			switch (msg)
			{
				case 0x0024:
					WmGetMinMaxInfo(hwnd, lParam);
					break;
			}

			return IntPtr.Zero;
		}

		private static void WmGetMinMaxInfo(System.IntPtr hwnd, System.IntPtr lParam)
		{
			POINT lMousePosition;
			GetCursorPos(out lMousePosition);

			IntPtr lPrimaryScreen = MonitorFromPoint(new POINT(0, 0), MonitorOptions.MONITOR_DEFAULTTOPRIMARY);
			MONITORINFO lPrimaryScreenInfo = new MONITORINFO();
			if (GetMonitorInfo(lPrimaryScreen, lPrimaryScreenInfo) == false)
			{
				return;
			}

			IntPtr lCurrentScreen = MonitorFromPoint(lMousePosition, MonitorOptions.MONITOR_DEFAULTTONEAREST);

			MINMAXINFO lMmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

			if (lPrimaryScreen.Equals(lCurrentScreen) == true)
			{
				lMmi.ptMaxPosition.X = lPrimaryScreenInfo.rcWork.Left;
				lMmi.ptMaxPosition.Y = lPrimaryScreenInfo.rcWork.Top;
				lMmi.ptMaxSize.X = lPrimaryScreenInfo.rcWork.Right - lPrimaryScreenInfo.rcWork.Left;
				lMmi.ptMaxSize.Y = lPrimaryScreenInfo.rcWork.Bottom - lPrimaryScreenInfo.rcWork.Top;
			}
			else
			{
				lMmi.ptMaxPosition.X = lPrimaryScreenInfo.rcMonitor.Left;
				lMmi.ptMaxPosition.Y = lPrimaryScreenInfo.rcMonitor.Top;
				lMmi.ptMaxSize.X = lPrimaryScreenInfo.rcMonitor.Right - lPrimaryScreenInfo.rcMonitor.Left;
				lMmi.ptMaxSize.Y = lPrimaryScreenInfo.rcMonitor.Bottom - lPrimaryScreenInfo.rcMonitor.Top;
			}

			Marshal.StructureToPtr(lMmi, lParam, true);
		}


		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool GetCursorPos(out POINT lpPoint);


		[DllImport("user32.dll", SetLastError = true)]
		static extern IntPtr MonitorFromPoint(POINT pt, MonitorOptions dwFlags);

		enum MonitorOptions : uint
		{
			MONITOR_DEFAULTTONULL = 0x00000000,
			MONITOR_DEFAULTTOPRIMARY = 0x00000001,
			MONITOR_DEFAULTTONEAREST = 0x00000002
		}


		[DllImport("user32.dll")]
		static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);


		[StructLayout(LayoutKind.Sequential)]
		public struct POINT
		{
			public int X;
			public int Y;

			public POINT(int x, int y)
			{
				this.X = x;
				this.Y = y;
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct MINMAXINFO
		{
			public POINT ptReserved;
			public POINT ptMaxSize;
			public POINT ptMaxPosition;
			public POINT ptMinTrackSize;
			public POINT ptMaxTrackSize;
		};


		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public class MONITORINFO
		{
			public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));
			public RECT rcMonitor = new RECT();
			public RECT rcWork = new RECT();
			public int dwFlags = 0;
		}


		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int Left, Top, Right, Bottom;

			public RECT(int left, int top, int right, int bottom)
			{
				this.Left = left;
				this.Top = top;
				this.Right = right;
				this.Bottom = bottom;
			}
		}
		#endregion

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void btnMaximize_Click(object sender, RoutedEventArgs e)
		{
			if (this.WindowState == WindowState.Normal)
			{
				this.WindowState = WindowState.Maximized;
				pthMaximize.Data = (Geometry)this.FindResource("rsNormal-icon");
			}
			else
			{
				this.WindowState = WindowState.Normal;
				pthMaximize.Data = (Geometry)this.FindResource("rsMaximize-icon");
			}
		}

		private void btnMinimize_Click(object sender, RoutedEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}


		private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}





		/*Menu*/
		private void InitializeMenu()
		{

		}

		private void PrepareAnimation()
		{
			MenuOpenAnimation = new ThicknessAnimation()
			{
				From = new Thickness(-240, 0, 0, 0),
				To = new Thickness(60, 0, 0, 0),
				Duration = TimeSpan.FromSeconds(.9),
				FillBehavior = FillBehavior.HoldEnd,
				AccelerationRatio = .5
			};

			MenuCloseAnimation = new ThicknessAnimation()
			{
				From = new Thickness(60, 0, 0, 0),
				To = new Thickness(-240, 0, 0, 0),
				Duration = TimeSpan.FromSeconds(.9),
				FillBehavior = FillBehavior.HoldEnd,
				AccelerationRatio = .5
			};
			
		}


		private void ShowHideMenu(Button btn)
		{			
			
			if (SelectedButton != btn)
			{				

				MenuContent.Visibility = Visibility.Hidden;
				StarContent.Visibility = Visibility.Hidden;
				UsersContent.Visibility = Visibility.Hidden;
				NotificationContent.Visibility = Visibility.Hidden;
				HelpContent.Visibility = Visibility.Hidden;
				SettingContent.Visibility = Visibility.Hidden;				

				switch (btn.Name)
				{
					case "btnMenu":
						MenuContent.Visibility = Visibility.Visible;
						break;
					case "btnStar":
						StarContent.Visibility = Visibility.Visible;
						break;
					case "btnNotification":
						NotificationContent.Visibility = Visibility.Visible;
						break;
					case "btnUser":
						UsersContent.Visibility = Visibility.Visible;
						break;
					case "btnHelp":
						HelpContent.Visibility = Visibility.Visible;
						break;
					case "btnSetting":
						SettingContent.Visibility = Visibility.Visible;
						break;
				}				
			}

			var BlueColor = new SolidColorBrush();
			BlueColor.Color = (Color)ColorConverter.ConvertFromString("#274bf0");


			if (SelectedButton == null)
			{
				IsOpenMenu = true;
				SelectedButton = btn;
				(btn.Content as Path).Stroke = BlueColor;
				MenuPanel.BeginAnimation(ContentControl.MarginProperty, MenuOpenAnimation);
			}
			else
			{
				if (SelectedButton == btn)
				{
					IsOpenMenu = false;
					SelectedButton = null;
					btn.Background = Brushes.Transparent;					
									
					(btn.Content as Path).Stroke = Brushes.White;					
					MenuPanel.BeginAnimation(ContentControl.MarginProperty, MenuCloseAnimation);
				}
				else
				{
					SelectedButton.Background = Brushes.Transparent;
					SelectedButton.BorderBrush = Brushes.White;
					(SelectedButton.Content as Path).Stroke = Brushes.White;
					(btn.Content as Path).Stroke = BlueColor;
					SelectedButton = btn;					
				}
				
			}
				
			
		}
		
		private void btnMenu_Click(object sender, RoutedEventArgs e)
		{
			ShowHideMenu((sender as Button));			
		}

		private void btnExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void btnHelp_Click(object sender, RoutedEventArgs e)
		{
			ShowHideMenu((sender as Button));
		}

		private void btnStar_Click(object sender, RoutedEventArgs e)
		{
			ShowHideMenu((sender as Button));
		}

		private void btnUser_Click(object sender, RoutedEventArgs e)
		{
			ShowHideMenu((sender as Button));
		}

		private void btnNotification_Click(object sender, RoutedEventArgs e)
		{
			ShowHideMenu((sender as Button));
		}

		private void btnSetting_Click(object sender, RoutedEventArgs e)
		{
			ShowHideMenu((sender as Button));
		}

		private void btnStar_MouseMove(object sender, MouseEventArgs e)
		{
			

		}

		private void btnMenu_MouseEnter(object sender, MouseEventArgs e)
		{
			MouseEnterLeave(sender as Button);

		}

		private void btnMenu_MouseLeave(object sender, MouseEventArgs e)
		{
			MouseEnterLeave(sender as Button, false);
		}


		private void MouseEnterLeave(Button btn, bool IsEnter = true)
		{
			if (IsEnter)
			{
				btn.Background = Brushes.Red;
			}
			else
			{
				btn.Background = (SelectedButton == btn) ? Brushes.White : Brushes.Transparent;
			}
			

		}

		private void btnStar_MouseEnter(object sender, MouseEventArgs e)
		{
			MouseEnterLeave(sender as Button);
		}

		private void btnStar_MouseLeave(object sender, MouseEventArgs e)
		{
			MouseEnterLeave(sender as Button, false);
		}

		private void btnUser_MouseEnter(object sender, MouseEventArgs e)
		{
			MouseEnterLeave(sender as Button);
		}

		private void btnUser_MouseLeave(object sender, MouseEventArgs e)
		{
			MouseEnterLeave(sender as Button, false);

		}

		private void btnNotification_MouseEnter(object sender, MouseEventArgs e)
		{
			MouseEnterLeave(sender as Button);
		}

		private void btnNotification_MouseLeave(object sender, MouseEventArgs e)
		{
			MouseEnterLeave(sender as Button, false);
		}

		private void btnSetting_MouseEnter(object sender, MouseEventArgs e)
		{
			MouseEnterLeave(sender as Button);
		}

		private void btnSetting_MouseLeave(object sender, MouseEventArgs e)
		{
			MouseEnterLeave(sender as Button, false);
		}

		private void btnHelp_MouseEnter(object sender, MouseEventArgs e)
		{
			MouseEnterLeave(sender as Button);
		}

		private void btnHelp_MouseLeave(object sender, MouseEventArgs e)
		{
			MouseEnterLeave(sender as Button, false);
		}

		private void btnExit_MouseEnter(object sender, MouseEventArgs e)
		{
			MouseEnterLeave(sender as Button);
		}

		private void btnExit_MouseLeave(object sender, MouseEventArgs e)
		{
			MouseEnterLeave(sender as Button, false);
		}



		private void trvMenu_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
		

		}
	}



}
