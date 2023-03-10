using DocumentArchive.Controller.Connection;
using DocumentArchive.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace DocumentArchive.Views.Screens.Guest
{
	/// <summary>
	/// Логика взаимодействия для GuestMainScreen.xaml
	/// </summary>
	public partial class GuestMainScreen : Page
	{
		private DateTime InfoUpdated;
		private int numRequestCalls = 0;
		
		public GuestMainScreen()
		{
			InitializeComponent();
			
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
						numRequestCalls++;
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

			DispatcherTimer dt = new DispatcherTimer();
			dt.Tick += new EventHandler(dt_Tick);
			dt.Interval = new TimeSpan(0, 0, 1);
			dt.Start();

			/// всё по классам
		}

		private void dt_Tick(object sender, EventArgs e)
		{
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
						numRequestCalls++;
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

				GC.Collect(1, GCCollectionMode.Forced);
				GC.WaitForPendingFinalizers();
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

		private void BtnLogin_Click(object sender, RoutedEventArgs e)
		{
			new MainWindow().Show();
			Window.GetWindow(this).Close();
		}

		private void BtnNextLbItem_Click(object sender, RoutedEventArgs e)
		{
			int LbItems = LbPinnedFiles.Items.Count;
			if (LbPinnedFiles.SelectedIndex < LbItems - 1)
			{
				LbPinnedFiles.SelectedIndex++;
				LbPinnedFiles.Focus();
				LbPinnedFiles.ScrollIntoView(LbPinnedFiles.SelectedItem);
			}
		}

		private void BtnPrevLbItem_Click(object sender, RoutedEventArgs e)
		{
			int LbIndex = LbPinnedFiles.SelectedIndex;
			if (LbIndex > 0)
			{
				LbPinnedFiles.SelectedIndex--;
				LbPinnedFiles.Focus();
				LbPinnedFiles.ScrollIntoView(LbPinnedFiles.SelectedItem);
			}
		}
	}
}
