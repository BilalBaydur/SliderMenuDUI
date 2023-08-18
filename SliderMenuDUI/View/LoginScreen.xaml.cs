using SliderMenuDUI.Systems.Dto;
using SliderMenuDUI.Systems.Globals.Abstract;
using SliderMenuDUI.Systems.Manager.Abstract;
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
using System.Windows.Shapes;

namespace SliderMenuDUI.View
{
	/// <summary>
	/// Interaction logic for LoginScreen.xaml
	/// </summary>
	public partial class LoginScreen : Window
	{
		public ILoginManager _loginManager;
		public IGlobal _global;


		public LoginScreen(ILoginManager loginManager, IGlobal global)
		{
			_loginManager = loginManager;
			_global = global;

			InitializeComponent();
						
		}

		private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void CancelBtn_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = false;
			
		}

		private async void LoginBtn_Click(object sender, RoutedEventArgs e)
		{
			try{
				LoginBtn.IsEnabled = false;
				//Gerekli kontroller yapılacak	
				LoginDto logindto =  _loginManager.GetNewLoginDto(txtUserName.Text, txtPassword.Password);

				var ValidResponce = _loginManager.IsValidation(logindto);
				if (!ValidResponce.Success)
				{
					MessageBox.Show(ValidResponce.Message);
					return;
				}

				var responce = await _loginManager.Login(logindto);
				if (!responce.Success)
				{
					MessageBox.Show(responce.Message);
					return;
				}

				this.DialogResult = true;
			}
			finally
			{
				LoginBtn.IsEnabled = true;
			}
		}
	}
}
