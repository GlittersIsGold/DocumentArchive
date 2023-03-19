using DocumentArchive.Controller.Converter;
using SautinSoft;
using System;
using System.IO;
using System.Windows;

namespace DocumentArchive.View.Page.General.Document
{
	/// <summary>
	/// Логика взаимодействия для ReadWindow.xaml
	/// </summary>
	public partial class ReadWindow : Window
	{
		private static FileStream fs { get; set; }
		private string LocalPath { get; set; }

		public ReadWindow(Model.FileInfo file)
		{
			InitializeComponent();
			
			LocalPath = "";

			if (file.Title.EndsWith(".pdf"))
			{
				File.WriteAllBytes(LocalPath += file.Title, file.Expression);
				
				PdfFocus focus = new PdfFocus();
				focus.OpenPdf(LocalPath);
				if (focus.PageCount > 0)
				{
					int convertionResult = focus.ToWord(LocalPath.Replace(".pdf", ".docx"));
					if (convertionResult == 0) 
					{
						ReadDocx(LocalPath);
					}
				}
				MessageBox.Show("Возникла ошибка");
			}
			else if (file.Title.EndsWith(".docx"))
			{
				File.WriteAllBytes(LocalPath += file.Title, file.Expression);
				ReadDocx(LocalPath);
			}
			else
			{
				MessageBox.Show("Неподдерживаемое расширение файла");
			}
		}

		private void ReadDocx(string path)
		{
			using (var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				var flowDocumentConverter = new DocxToFlowDocumentConverter(stream);
				flowDocumentConverter.Read();
				this.FDReader.Document = flowDocumentConverter.Document;
				this.Title = Path.GetFileName(path);
			}
		}
	}
}
