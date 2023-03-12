using DocumentArchive.Views.Pages.General.Document;
using System.Windows;
using System.Windows.Controls;

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
			Window.GetWindow(this).Close();
		}
    }
}
