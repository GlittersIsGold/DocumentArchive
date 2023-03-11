using DocumentArchive.Controller.Connection;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

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

		/// <summary>
		/// Очередь с подкотовленными файлами к сериализации
		/// </summary>
		Queue<Model.ADO.FileInfo> FilesToUpload = new Queue<Model.ADO.FileInfo>();

		public TeacherMainScreen()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Загрузка файлов в систему
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void BtnUploadFile_Click(object sender, RoutedEventArgs e)
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

						Model.ADO.FileInfo file = new Model.ADO.FileInfo()
						{
							Title = Path.GetFileName(filePointer),
							Description = File.GetAttributes(filePointer).ToString(),
							Size = new FileInfo(filePointer).Length,
							Created = File.GetCreationTime(filePointer),
							Expression = File.ReadAllBytes(filePointer),
							CategoryId = 1,
						};

						DataAccess.EDAEntities.FileInfoes.Add(file);
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

		/// <summary>
		/// Сериализация json и отправка на API
		/// </summary>
		//foreach (var file in FilesToUpload)
		//{

		//	var json = JsonConvert.SerializeObject(file);

		//	var Data = new StringContent(json, Encoding.UTF8, "application/json");

		//	string url = "https://httpbin.org/post";

		//	HttpClient httpClient = new HttpClient();

		//	if (url != null)
		//	{
		//		var response = await httpClient.PostAsync(url, Data);

		//		var result = await response.Content.ReadAsStringAsync();
		//		System.Windows.MessageBox.Show(result);
		//	}
		//}


		private void BtnNextStrings_Click(object sender, RoutedEventArgs e)
		{

		}

		private void BtnPreviousStrings_Click(object sender, RoutedEventArgs e)
		{

		}

		private void BtnOpenReader_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}