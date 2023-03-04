using DocumentArchive.Controller.Navigation;
using DocumentArchive.Views.Screens.General;
using System.Windows;

namespace DocumentArchive
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public MainWindow()
		{
			InitializeComponent();

			FrameTransition.Navigator = FrmEnter;

			FrameTransition.Navigator.Navigate(new LoginScreen());
		}
    }
}
