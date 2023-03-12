using DocumentArchive.Controller.Connection;
using DocumentArchive.Controller.Navigation;
using DocumentArchive.Views.Pages.General.Document;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DocumentArchive.Views.Screens.General
{
	/// <summary>
	/// Логика взаимодействия для LoginScreen.xaml
	/// </summary>
	public partial class LoginScreen : Page
	{
		private int userId = 1;

		public LoginScreen()
		{
			InitializeComponent();
			DataAccess.EDAEntities = new Model.ADO.ElectronicDocumentArchiveEntities();

			/// сделать через биндинг
			TextBoxLogin.Text = Properties.Settings.Default.userName;
			PasswordBoxPassword.Password = Properties.Settings.Default.userPass;
			CheckBoxRememberMe.IsChecked = CheckBoxRememberMe.IsChecked;
		}

		private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
		{
			/// Добавить RegEx
			if (TextBoxLogin.Text != string.Empty && PasswordBoxPassword.Password != string.Empty)
			{
				
				try
				{
					var UserDataToLogin = 
						DataAccess.EDAEntities.Users.FirstOrDefault(
							u => u.Login == TextBoxLogin.Text && u.Password == PasswordBoxPassword.Password
							);


					if (UserDataToLogin != null)
					{
						userId = UserDataToLogin.Id;
					
						switch (UserDataToLogin.RoleId)
						{
							case 1:
								new ArchiveMainWindow(userId).Show();
								Window.GetWindow(this).Close();
								break;
							case 2:
								new ArchiveMainWindow(userId).Show();
								Window.GetWindow(this).Close();
								break;
							case 3:
								new ArchiveMainWindow(userId).Show();
								Window.GetWindow(this).Close();
								break;
							case 4:
								new ArchiveMainWindow(userId).Show();
								Window.GetWindow(this).Close();
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
		}

		private void CheckBoxRememberMe_Checked(object sender, RoutedEventArgs e)
		{
			/// добавить действия на анчек
			Properties.Settings.Default.userName = TextBoxLogin.Text;
			Properties.Settings.Default.userPass = PasswordBoxPassword.Password;
			Properties.Settings.Default.IsChbChecked = CheckBoxRememberMe.IsChecked;
		}

		private void ButtonSignUp_Click(object sender, RoutedEventArgs e)
		{
			FrameTransition.Navigator.Navigate(new RegistrationScreen());
		}

		private void ButtonContinueAsGuest_Click(object sender, RoutedEventArgs e)
		{
			new ArchiveMainWindow(userId).Show();
			Window.GetWindow(this).Close();
		}
	}
}
