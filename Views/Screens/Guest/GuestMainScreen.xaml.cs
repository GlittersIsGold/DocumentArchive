using DocumentArchive.Controller.Navigation;
using DocumentArchive.Model.ADO;
using DocumentArchive.Views.Pages.General.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DocumentArchive.Views.Screens.Guest
{
	/// <summary>
	/// Логика взаимодействия для GuestMainScreen.xaml
	/// </summary>
	public partial class GuestMainScreen : Page
	{
		public GuestMainScreen()
		{
			InitializeComponent();
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
		}
    }
}
