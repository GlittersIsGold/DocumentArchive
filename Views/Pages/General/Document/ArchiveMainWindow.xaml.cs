using DocumentArchive.Controller.Navigation;
using DocumentArchive.Views.Screens.Guest;
using DocumentArchive.Views.Screens.Student;
using DocumentArchive.Views.Screens.Teacher;
using System;
using System.Windows;

namespace DocumentArchive.Views.Pages.General.Document
{
	/// <summary>
	/// Логика взаимодействия для ArchiveMainWindow.xaml
	/// </summary>
	public partial class ArchiveMainWindow : Window
	{
		public ArchiveMainWindow(int userId)
		{
			InitializeComponent();
			FrameTransition.Navigator = FrmMain;

			switch (userId)
			{
				case 1:
					FrmMain.Navigate(new GuestMainScreen());
					break;
				case 2:
					FrmMain.Navigate(new GuestMainScreen());
					break;
				case 3:
					FrmMain.Navigate(new StudentMainScreen());
					break;
				case 4:
					FrmMain.Navigate(new TeacherMainScreen());
					break;
				case 5:
					FrmMain.Navigate(new TeacherMainScreen());
					break;

				default:
					MessageBox.Show("Возникла ошибка\nсмотрите информацию во внутреннем исключении");
					throw new Exception("Не найдены фрагменты .dll");
			}
		}
	}
}
