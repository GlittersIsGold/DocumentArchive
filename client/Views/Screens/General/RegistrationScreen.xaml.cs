using DocumentArchive.Controller.Connection;
using DocumentArchive.Controller.Navigation;
using DocumentArchive.Model;
using DocumentArchive.Model.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace DocumentArchive.Views.Screens.General
{
	/// <summary>
	/// Логика взаимодействия для RegistrationScreen.xaml
	/// </summary>
	public partial class RegistrationScreen : Page
	{
		public RegistrationScreen()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Возврат на страницу входа
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonGoToSignIn_Click(object sender, RoutedEventArgs e)
		{
			FrameTransition.Navigator.Navigate(new LoginScreen());
		}

		/// <summary>
		/// Регистрация нового пользователя
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <exception cref="Exception"></exception>
		private void ButtonSignUp_Click(object sender, RoutedEventArgs e)
		{
			if (TextBoxLogin.Text.Length > 6 && PasswordBoxPassword.Password.Length > 12 && TextBoxName.Text.Length > 4 && TextBoxEmail.Text.Length > 5)
			{
				try
				{
					List<User> ExistingUsers = DataAccess.EDAEntities.User.ToList();

                    RegisterDto user = new RegisterDto()
					{
						Login = TextBoxLogin.Text,
						Password = PasswordBoxPassword.Password,
						Name = TextBoxName.Text,
						Email = TextBoxEmail.Text,
					};

					
					bool IsUserExist = ExistingUsers.Any(x => x.Email == user.Email || x.Login == user.Login);

					if (IsUserExist == false)
					{
						try
						{

							SendRegisterRequest(user);

							MessageBox.Show("Данные отправлены, дождитесь подтверждения");
							FrameTransition.Navigator.Navigate(new LoginScreen());
						}
						catch (Exception ex)
						{
							MessageBox.Show("При попытке регистарции возникла проблема");
							throw new Exception(ex.Message);
						}
					}
					else
					{
						MessageBox.Show("Пользователь существует");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Не удалось обработать данные");
					throw new Exception(ex.Message);
				}
			}

			else
			{
				MessageBox.Show("Введённые данные не соответствуют требованиям");
			}

			async void SendRegisterRequest(RegisterDto user)
			{
				var json = JsonConvert.SerializeObject(user);

				var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

				var url = "http://localhost:5106/api/auth/register";

				var client = new HttpClient();

				var response = await client.PostAsync(url, data);

				var result = await response.Content.ReadAsStringAsync();
			}
		}
	}
}
