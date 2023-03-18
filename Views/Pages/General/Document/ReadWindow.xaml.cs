using DocumentArchive.Model;
using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace DocumentArchive.View.Page.General.Document
{
	/// <summary>
	/// Логика взаимодействия для ReadWindow.xaml
	/// </summary>
	public partial class ReadWindow : Window
	{
		public ReadWindow(Model.FileInfo file)
		{
			InitializeComponent();
			string path = @"/Resources/TempFiles/" + file.Title;
			File.WriteAllBytes(path, file.Expression);
			using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				FlowDocument doc = new FlowDocument();	
				FDReader.Document = doc;
			}
		}
	}
}
