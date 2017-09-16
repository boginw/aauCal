using AAU_Cal.Components;
using AAU_Cal.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace AAU_Cal {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();

			int curDate = WeekRouletteView.InitDays(DateTime.Now);
			WeekRouletteView.DateChanged += WeekRouletteView_DateChanged;
			WeekRouletteView.SetActive(curDate);


			AgendaView.Add(new Lecture(
				"[E17] Systems Development (SU) (DAT3, SW3, IxD5, iDA7)", "Jan Stage",
				DateTime.Parse("2017-09-11 08:15:00"), DateTime.Parse("2017-09-11 10:10:00"),
				"Lecture", "NOVI8, AUD."));

		}

		private void WeekRouletteView_DateChanged(object sender, RoutedEventArgs e) {
			DateChangeEvent change = (DateChangeEvent) sender;
			WeekRouletteView.SetActive(change.index);
			Debug.WriteLine(change.date.ToString());
		}
	}
}
