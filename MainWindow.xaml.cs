using DocumentArchive.Model.DataConnect;
using DocumentArchive.Views.Screens.DepLeader;
using DocumentArchive.Views.Screens.General.Registration;
using DocumentArchive.Views.Screens.Guest;
using DocumentArchive.Views.Screens.Student;
using DocumentArchive.Views.Screens.Teacher;
using DocumentArchive.Views.Screens.Tutor;
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

namespace DocumentArchive
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Connection.EDAEntities = new Model.ADO.ElectronicDocumentArchiveEntities();
		}

		private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var data = Connection.EDAEntities.Users.FirstOrDefault(u => u.Login == TextBoxLogin.Text && u.Password == PasswordBoxPassword.Password);
			
				if (data != null)
				{
					switch (data.RoleId)
					{
						case 2:
							new StudentMainScreen();
							break; 
						case 3:
							new TeacherMainScreen();
							break;
						case 4:
							new DepLeadeScreen();
							break;
						case 5:
							new TutorMainScreen();
							break;
						
						default: throw new Exception("Проблема идентификации пользователя");
					}
					Hide();
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

		private void ButtonSignUp_Click(object sender, RoutedEventArgs e)
		{
			Hide();
			new RegistrationScreen();
        }

		private void ButtonContinueAsGuest_Click(object sender, RoutedEventArgs e)
		{
			Hide();
			new GuestMainScreen();
        }

		private void CheckBoxRememberMe_Checked(object sender, RoutedEventArgs e)
		{
			
        }

		//private void Window_closing(object sender, System.ComponentModel.CancelEventArgs e)
		//{
		//	Environment.Exit(0);
		//}
    }
}
