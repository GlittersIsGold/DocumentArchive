﻿using DocumentArchive.Controller.Connection;
using DocumentArchive.Model;
using DocumentArchive.View.Page.General.Document;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Threading;
using MessageBox = System.Windows.MessageBox;

namespace DocumentArchive.Views.Screens.Student
{
	/// <summary>
	/// Логика взаимодействия для StudentMainScreen.xaml
	/// </summary>
	public partial class StudentMainScreen : Page
	{
		private DateTime InfoUpdated;
		private int numRequestCalls = 0;

		public StudentMainScreen()
		{
			InitializeComponent();

			try
			{
				List<GuestFileInfo> DgData = DataAccess.EDAEntities.GuestFileInfo.Where(f => f.AccessLevelId == 2).ToList();

				if (DgData != null)
				{
					if (DgData.Count > 0)
					{
						DgPublicFiles.ItemsSource = DgData;
						LbPinnedFiles.ItemsSource = DgData.Where(f => f.IsPinned == true).ToList();
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
			dt.Tick += new EventHandler(Dt_Tick);
			dt.Interval = new TimeSpan(0, 0, 1);
			dt.Start();

		}

		private void Dt_Tick(object sender, EventArgs e)
		{
			try
			{

				List<GuestFileInfo> DgData = DataAccess.EDAEntities.GuestFileInfo.Where(f => f.AccessLevelId == 2).ToList();

				if (DgData != null)
				{
					if (DgData.Count > 0)
					{
						DgPublicFiles.ItemsSource = DgData;
						LbPinnedFiles.ItemsSource = DgData.Where(f => f.IsPinned == true).ToList();
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

		private void BtnOpenReader_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				GuestFileInfo selectedFile = ((FrameworkElement)sender).DataContext as GuestFileInfo;

				Model.FileInfo fileToUpload = DataAccess.EDAEntities.FileInfo.First(f => f.Title == selectedFile.Title);

				new ReadWindow(fileToUpload).Show();
			}
			catch (Exception)
			{
				MessageBox.Show("Возникла ошибка\nсмотрите подробности во внутреннем исключении");
				throw;
			}
		}

		private void BtnDownloadFile_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				GuestFileInfo selectedFile = ((FrameworkElement)sender).DataContext as GuestFileInfo;

				Model.FileInfo fileToUpload = DataAccess.EDAEntities.FileInfo.First(f => f.Title == selectedFile.Title);

				SaveFileDialog sfd = new SaveFileDialog()
				{
					Filter = "*.pdf|*.pdf|*.docx|*.docx",
					Title = "Сохранить",
					FileName = selectedFile.Title
				};

				var dr = sfd.ShowDialog();

				if (sfd.FileName != string.Empty && dr == DialogResult.OK)
				{
					File.WriteAllBytes(sfd.FileName, fileToUpload.Expression);
				}
				else if (dr == DialogResult.Cancel)
				{
					return;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void BtnLogout_Click(object sender, RoutedEventArgs e)
		{
			new MainWindow().Show();
			Window.GetWindow(this).Close();
		}

		private void LbPinnedFiles_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			try
			{
				var LbItem = ItemsControl.ContainerFromElement(LbPinnedFiles, e.OriginalSource as DependencyObject) as ListBoxItem;

				if (LbItem != null)
				{
					GuestFileInfo selectedDocument = LbItem.Content as GuestFileInfo;
					Model.FileInfo fileToUpload = DataAccess.EDAEntities.FileInfo.First(f => f.Title == selectedDocument.Title);
					new ReadWindow(fileToUpload).Show();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Возникла ошибка\nсмотрите подробности во внутреннем исключении");
				throw;
			}
		}
	}
}
