using DocumentArchive.Controller.Connection;
using DocumentArchive.Model;
using DocumentArchive.View.Page.General.Document;
using System.Windows;
using System;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using System.IO;
using System.Collections.Generic;
using System.Windows.Threading;

namespace DocumentArchive.Views.Screens.Staff
{
	/// <summary>
	/// Логика взаимодействия для StaffMainScreen.xaml
	/// </summary>
	public partial class StaffMainScreen : Page
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

		public StaffMainScreen()
		{
			InitializeComponent();

			try
			{

				List<GuestFileInfo> DgData = DataAccess.EDAEntities.GuestFileInfo.Where(f => f.AccessLevelId == 4).ToList();

				if (DgData != null)
				{
					if (DgData.Count > 0)
					{
						DgPublicFiles.ItemsSource = DgData;
						LbPinnedFiles.ItemsSource = DgData.Where(f => f.IsPinned == true && f.AccessLevelId == 4).ToList();
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

				List<GuestFileInfo> DgData = DataAccess.EDAEntities.GuestFileInfo.Where(f => f.AccessLevelId == 4).ToList();

				if (DgData != null)
				{
					if (DgData.Count > 0)
					{
						DgPublicFiles.ItemsSource = DgData;
						LbPinnedFiles.ItemsSource = DgData.Where(f => f.IsPinned == true && f.AccessLevelId == 4).ToList();
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

		private void BtnStats_Click(object sender, System.Windows.RoutedEventArgs e)
		{

        }

		private void BtnGrant_Click(object sender, System.Windows.RoutedEventArgs e)
		{

        }

		private async void BtnUploadFile_Click(object sender, System.Windows.RoutedEventArgs e)
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
						await DataAccess.EDAEntities.SaveChangesAsync();
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

		private void BtnLogout_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			new MainWindow().Show();
			Window.GetWindow(this).Close();
        }

		private void BtnGenerateLink_Click(object sender, System.Windows.RoutedEventArgs e)
		{

		}

		private void BtnPrevLbItem_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			int LbIndex = LbPinnedFiles.SelectedIndex;
			if (LbIndex > 0)
			{
				LbPinnedFiles.SelectedIndex--;
				LbPinnedFiles.Focus();
				LbPinnedFiles.ScrollIntoView(LbPinnedFiles.SelectedItem);
			}
		}

		private void BtnNextLbItem_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			int LbItems = LbPinnedFiles.Items.Count;
			if (LbPinnedFiles.SelectedIndex < LbItems - 1)
			{
				LbPinnedFiles.SelectedIndex++;
				LbPinnedFiles.Focus();
				LbPinnedFiles.ScrollIntoView(LbPinnedFiles.SelectedItem);
			}
		}

		private void BtnOpenReader_Click(object sender, System.Windows.RoutedEventArgs e)
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

		private void BtnDownloadFile_Click(object sender, System.Windows.RoutedEventArgs e)
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
