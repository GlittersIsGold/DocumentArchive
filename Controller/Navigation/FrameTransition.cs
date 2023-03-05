using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DocumentArchive.Controller.Navigation
{
	/// <summary>
	/// Класс перехода по страницам
	/// </summary>
	internal static class FrameTransition
	{
		public static Frame Navigator { get; set; }

		public static void EnterWindowClosing() 
		{
			Application.Current.MainWindow.Close();
		}
	}
}
