using DocumentArchive.Controller.Connection;
using DocumentArchive.Controller.Navigation;
using DocumentArchive.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
					List<Model.ADO.User> ExistingUsers = DataAccess.EDAEntities.Users.ToList();

					FreshUserBuilder freshUser = new FreshUserBuilder()
					{
						Login = TextBoxLogin.Text,
						Password = PasswordBoxPassword.Password,
						Name = TextBoxName.Text,
						Email = TextBoxEmail.Text,
						Registered = DateTime.Now,
						RoleId = 1
					};
					///
					/// В асинхрон всё нужно
					///
					// проверка на существование
					bool IsUserExist = ExistingUsers.Any(x => x.Email == freshUser.Email || x.Login == freshUser.Login);

					if (IsUserExist == false)
					{
						try
						{
							// добавление доделать
							DataAccess.EDAEntities.Users.Add(freshUser);
							DataAccess.EDAEntities.SaveChanges();
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message.ToString());
							throw;
						}
					}
					else
					{
						MessageBox.Show("Пользователь существует");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Не удалось зарегистрировать");
					throw new Exception(ex.Message);
				}
			}

			else
			{
				MessageBox.Show("Введённые данные не соответствуют требованиям");
			}
		}
	}
}
