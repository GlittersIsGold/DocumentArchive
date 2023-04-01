using DocumentArchive.Controller.Navigation;
using DocumentArchive.Views.Screens.Guest;
using DocumentArchive.Views.Screens.Staff;
using DocumentArchive.Views.Screens.Student;
using DocumentArchive.Views.Screens.Teacher;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace DocumentArchive.Views.Pages.General.Document
{
	/// <summary>
	/// Логика взаимодействия для ArchiveMainWindow.xaml
	/// </summary>
	public partial class ArchiveMainWindow : Window
	{
		private NotifyIcon notifyIcon;
		private WindowState storedWindowState = WindowState.Normal;

		public ArchiveMainWindow(int userId)
		{
			InitializeComponent();
			FrameTransition.Navigator = FrmMain;

			switch (userId)
			{
				case 1:
                    System.Windows.MessageBox.Show("Ваш аккаунт не подтверждён.\nДождитесь подтверждения.\nВы будете переведены на страницу гостя.");
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
					FrmMain.Navigate(new StaffMainScreen());
					break;

				default:
                    System.Windows.MessageBox.Show("Возникла ошибка\nсмотрите информацию во внутреннем исключении");
					throw new Exception("Не найдены фрагменты .dll");
			}

			var iconStream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/Resources/Icons/archiveLogo.ico")).Stream;

			notifyIcon = new NotifyIcon
			{
				BalloonTipText = "The app has been minimised. Click the tray icon to show.",
				BalloonTipTitle = "Electronic archive",
				Text = "Electronic Archive Management System",
				Icon = new Icon(iconStream),

			};

			ShowInTaskbar = true;
			notifyIcon.Click += new EventHandler(notifyIcon_Click);
		}

		private void notifyIcon_Click(object sender, EventArgs e)
		{
			Show();
			WindowState = storedWindowState;
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			notifyIcon.Dispose();
			notifyIcon = null;
		}

		private void Window_StateChanged(object sender, EventArgs e)
		{
			if (WindowState == WindowState.Minimized)
			{
				Hide();
				if(notifyIcon != null)
				{
					notifyIcon.ShowBalloonTip(5000);
				}
				else
				{
					storedWindowState = WindowState;
				}
			}
		}

		private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			CheckTrayIcon();
		}

		private void CheckTrayIcon()
		{
			ShowTrayIcon(!IsVisible);
		}

		private void ShowTrayIcon(bool v)
		{
			if (notifyIcon != null)
			{
				notifyIcon.Visible = v;
			}
		}
	}
}