using DocumentArchive.Controller.Connection;
using DocumentArchive.Controller.Navigation;
using DocumentArchive.Views.Pages.General.Document;
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

namespace DocumentArchive.Views.Screens.General
{
	/// <summary>
	/// Логика взаимодействия для LoginScreen.xaml
	/// </summary>
	public partial class LoginScreen : Page
	{
		public LoginScreen()
		{
			InitializeComponent();
			DataAccess.EDAEntities = new Model.ADO.ElectronicDocumentArchiveEntities();
		}

		private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var data = DataAccess.EDAEntities.Users.FirstOrDefault(u => u.Login == TextBoxLogin.Text && u.Password == PasswordBoxPassword.Password);

				if (data != null)
				{
					switch (data.RoleId)
					{
						case 1:
							new ArchiveMainWindow().Show();
							FrameTransition.EnterWindowClosing();
							break;
						case 2:
							new ArchiveMainWindow().Show();
							FrameTransition.EnterWindowClosing();
							break;
						case 3:
							new ArchiveMainWindow().Show();
							FrameTransition.EnterWindowClosing();
							break;
						case 4:
							new ArchiveMainWindow().Show();
							FrameTransition.EnterWindowClosing();
							break;

						default: throw new Exception("Проблема идентификации пользователя");
					}
				}
				else
				{
					MessageBox.Show("Пользователь не найден");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				throw;

			}
		}

		private void CheckBoxRememberMe_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void ButtonSignUp_Click(object sender, RoutedEventArgs e)
		{
			FrameTransition.Navigator.Navigate(new RegistrationScreen());
		}

		private void ButtonContinueAsGuest_Click(object sender, RoutedEventArgs e)
		{
			new ArchiveMainWindow().Show();
			FrameTransition.EnterWindowClosing();
		}
	}
}
