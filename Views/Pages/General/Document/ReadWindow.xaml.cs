using DocumentArchive.Controller.Converter;
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
		public ReadWindow(Model.FileInfo file)
		{
			InitializeComponent();	
		}
	}
}
