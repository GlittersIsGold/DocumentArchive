using DocumentArchive.Controller.Connection;
using DocumentArchive.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DocumentArchive.Views.Screens.Guest
{
	/// <summary>
	/// Логика взаимодействия для GuestMainScreen.xaml
	/// </summary>
	public partial class GuestMainScreen : Page
	{
		private DateTime InfoUpdated;
		
		public GuestMainScreen()
		{
			InitializeComponent();
			
			/// всё по классам
			/// освобождать память
			/// обновлять по времени
			try
			{
				
				List<GuestFileInfo> DgData = DataAccess.EDAEntities.GuestFileInfo.ToList();

				if (DgData != null)
				{
					if (DgData.Count > 0)
					{
						DgPublicFiles.ItemsSource = DgData;
						LbPinnedFiles.ItemsSource = DgData;
						InfoUpdated = DateTime.Now;
						RnLastUpdate.Text = InfoUpdated.ToString("T");
						RnCountFiles.Text = DgData.Count.ToString();
					}
					else
					{
						MessageBox.Show("Нет данных");
					}
				}
				else 
				{
					MessageBox.Show("Не удалось получить данные");
					throw new ArgumentNullException(nameof(DgData));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Возникла ошибка\nсмотрите подробности во внутреннем исключении");
				throw new Exception(ex.Message);
			}
		}

		private void BtnOpenReader_Click(object sender, RoutedEventArgs e)
		{

        }

		private void BtnNextStrings_Click(object sender, RoutedEventArgs e)
		{

        }

		private void BtnLogin_Click(object sender, RoutedEventArgs e)
		{
			new MainWindow().Show();
			Window.GetWindow(this).Close();
		}
    }
}
