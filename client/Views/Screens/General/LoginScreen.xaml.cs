using DocumentArchive.Controller.Connection;
using DocumentArchive.Controller.Navigation;
using DocumentArchive.Model;
using DocumentArchive.Model.Dto;
using DocumentArchive.Views.Pages.General.Document;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace DocumentArchive.Views.Screens.General
{
	/// <summary>
	/// Логика взаимодействия для LoginScreen.xaml
	/// </summary>
	public partial class LoginScreen : Page
	{
		private int UserId { get; set; } = 2;
		private string Jwt { get; set; }
		private UserInfo UserInfo { get; set; }

		public LoginScreen()
		{
			InitializeComponent();
			DataAccess.EDAEntities = new ElectronicDocumentArchiveEntities();

			/// Исправить на binding -https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/application-settings-architecture?view=netframeworkdesktop-4.8
			if (Properties.Settings.Default.IsChbClicked == true)
			{
				TextBoxLogin.Text = Properties.Settings.Default.userName;
				PasswordBoxPassword.Password = Properties.Settings.Default.userPass;
				CheckBoxRememberMe.IsChecked = Properties.Settings.Default.IsChbClicked;
			}
		}

		/// <summary>
		/// Вход в аккаунт
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <exception cref="Exception"></exception>
		private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				LoginDto user = new LoginDto() 
				{
					login = TextBoxLogin.Text,
					password = PasswordBoxPassword.Password,
				};

				bool IfUserExists = DataAccess.EDAEntities.User.Any( u => u.Login == user.login );

				if (IfUserExists == true)
				{
					SendLoginRequest(user);
				}
				else
				{
					MessageBox.Show("Такого пользователя не существует");
					return;
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show("При обработке данных возникла ошибка\nсмотрите полную информацию во внутреннем исключении");
				throw new Exception(ex.Message);
			}
		}

		private void CheckBoxRememberMe_Checked(object sender, RoutedEventArgs e)
		{
			Properties.Settings.Default.userName = TextBoxLogin.Text;
			Properties.Settings.Default.userPass = PasswordBoxPassword.Password;
			Properties.Settings.Default.IsChbClicked = CheckBoxRememberMe.IsChecked;
		}

		private void ButtonSignUp_Click(object sender, RoutedEventArgs e)
		{
			FrameTransition.Navigator.Navigate(new RegistrationScreen());
		}

		private void ButtonContinueAsGuest_Click(object sender, RoutedEventArgs e)
		{
			new ArchiveMainWindow(UserId).Show();
			Window.GetWindow(this).Close();
		}

		/// <summary>
		/// Отправляет данные пользователя для входа в систему
		/// </summary>
		/// <param name="user">данные для входа: логин, пароль</param>
		async void SendLoginRequest(LoginDto user)
		{
			try
			{
				var json = JsonConvert.SerializeObject(user);
				var data = new StringContent(json, Encoding.UTF8, "application/json");
				var url = "http://localhost:5106/api/auth/login";

				var client = new HttpClient();
				var response = await client.PostAsync(url, data);

				var result = await response.Content.ReadAsStringAsync();
				var IsSucces = response.IsSuccessStatusCode;

				if (result != null && IsSucces == true)
				{
					Jwt = result;
					ReceiveUserData(Jwt);
				}
				else
				{
					MessageBox.Show("Вход не выполнен\n");
					return;
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Произошла ошибка\n");
				throw;
			}
		}

		/// <summary>
		/// Возвращает основные данные пользователя
		/// </summary>
		/// <param name="jwt">токен аутентификации пользователя</param>
		async void ReceiveUserData(string jwt)
		{
			try
			{
				var url = "http://localhost:5106/api/auth/user-data";

				var client = new HttpClient();
				
				client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");
				var result = await client.GetStringAsync(url);

				DeserializeReceivedData(result);

			}
			catch (Exception)
			{
				MessageBox.Show("Произошла ошибка\n");
				throw;
			}
		}

		/// <summary>
		/// Десериализация пользовательских данных
		/// </summary>
		/// <param name="json">строка с объектной нотацией java-script</param>
		private void DeserializeReceivedData(string json)
		{
			UserInfo serializedData = JsonConvert.DeserializeObject<UserInfo>(json);
			
			UserInfo = serializedData;

			UserId = Convert.ToInt16(UserInfo.Role);

			NavigateUser(UserId);
		}

		private void NavigateUser(int roleId)
		{
			try
			{
				switch (roleId)
				{
					case 1:
						new ArchiveMainWindow(roleId).Show();
						Window.GetWindow(this).Close();
						break;
					case 2:
						new ArchiveMainWindow(roleId).Show();
						Window.GetWindow(this).Close();
						break;
					case 3:
						new ArchiveMainWindow(roleId).Show();
						Window.GetWindow(this).Close();
						break;
					case 4:
						new ArchiveMainWindow(roleId).Show();
						Window.GetWindow(this).Close();
						break;
					case 5:
						new ArchiveMainWindow(roleId).Show();
						Window.GetWindow(this).Close();
						break;

					default:
						throw new Exception("Проблема идентификации пользователя");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				throw;
			}
			
		}
	}
}
