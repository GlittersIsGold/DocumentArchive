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

namespace DocumentArchive.Views.Screens.Teacher
{
	/// <summary>
	/// Логика взаимодействия для TeacherMainScreen.xaml
	/// </summary>
	public partial class TeacherMainScreen : Page
	{
		/// <summary>
		/// Пути к файлам
		/// </summary>
		/// <returns>
		/// возврат до 10 ссылок на пути файлов
		/// </returns>
		string[] FilePaths = new string[10];

		private DateTime InfoUpdated;
		private int numRequestCalls = 0;

		/// <summary>
		/// Очередь с подготовленными файлами к сериализации
		/// </summary>
		Queue<Model.FileInfo> FilesToUpload = new Queue<Model.FileInfo>();

		public TeacherMainScreen()
		{
			InitializeComponent();

			try
			{

				List<GuestFileInfo> DgData = DataAccess.EDAEntities.GuestFileInfo.Where(f => f.AccessLevelId == 3).ToList();

				if (DgData != null)
				{
					if (DgData.Count > 0)
					{
						DgPublicFiles.ItemsSource = DgData;
						LbPinnedFiles.ItemsSource = DgData.Where(f => f.IsPinned == true && f.AccessLevelId == 3).ToList();
						InfoUpdated = DateTime.Now;
						RnLastUpdate.Text = InfoUpdated.ToString("T");
						RnCountFiles.Text = DgData.Count.ToString();
						numRequestCalls++;
					}
					else
					{
						System.Windows.MessageBox.Show("Нет данных");
					}
				}
				else
				{
                    System.Windows.MessageBox.Show("Не удалось получить данные");
					throw new ArgumentNullException(nameof(DgData));
				}

			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show("Возникла ошибка\nсмотрите подробности во внутреннем исключении");
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

				List<GuestFileInfo> DgData = DataAccess.EDAEntities.GuestFileInfo.Where(f => f.AccessLevelId == 3).ToList();

				if (DgData != null)
				{
					if (DgData.Count > 0)
					{
						DgPublicFiles.ItemsSource = DgData;
						LbPinnedFiles.ItemsSource = DgData.Where(f => f.IsPinned == true && f.AccessLevelId == 3).ToList();
						InfoUpdated = DateTime.Now;
						RnLastUpdate.Text = InfoUpdated.ToString("T");
						RnCountFiles.Text = DgData.Count.ToString();
						numRequestCalls++;
					}
					else
					{
						System.Windows.MessageBox.Show("Нет данных");
					}
				}
				else
				{
					System.Windows.MessageBox.Show("Не удалось получить данные");
					throw new ArgumentNullException(nameof(DgData));
				}

				GC.Collect(1, GCCollectionMode.Forced);
				GC.WaitForPendingFinalizers();
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show("Возникла ошибка\nсмотрите подробности во внутреннем исключении");
				throw new Exception(ex.Message);
			}
		}

		/// <summary>
		/// Загрузка файлов в систему
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnUploadFile_Click(object sender, RoutedEventArgs e)
		{

			OpenFileDialog dialogScreen = new OpenFileDialog
			{
				DefaultExt = ".docx",
				Filter = "*.pdf|*.pdf|*.docx|*.docx",
				Multiselect = true,
			};

			DialogResult IsFilesPicked = dialogScreen.ShowDialog();

			if (IsFilesPicked == DialogResult.OK)
			{
				FilePaths = dialogScreen.FileNames;

				/// нужно добавить проверку по весу и количеству
				try
				{
					foreach (var filePointer in FilePaths)
					{

						Model.FileInfo file = new Model.FileInfo()
						{
							Title = Path.GetFileName(filePointer),
							Description = File.GetAttributes(filePointer).ToString(),
							Size = new System.IO.FileInfo(filePointer).Length,
							Created = File.GetCreationTime(filePointer),
							Expression = File.ReadAllBytes(filePointer),
							CategoryId = 1,
							AccessLevelId = 1,
							ShareLink = "нет",
							IsPinned = false,
						};

						DataAccess.EDAEntities.FileInfo.Add(file);
						DataAccess.EDAEntities.SaveChanges();
					}

					System.Windows.MessageBox.Show("Файл(ы) успешно загружены");
				}
				catch (System.Exception ex)
				{
					System.Windows.MessageBox.Show("Произошла ошибка при обработке файлов\nсмотрите информацию во внутреннем исключении");
					throw new System.Exception(ex.Message.ToString());
				}

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
				System.Windows.MessageBox.Show("Возникла ошибка\nсмотрите подробности во внутреннем исключении");
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

		private void BtnGenerateLink_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}