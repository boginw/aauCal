using AAU_Cal.Components;
using System;
using System.Diagnostics;
using System.Windows;
using AAU_Cal.Objects;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAU_Cal {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		LectureCont[] lectures;

		public MainWindow() {
			InitializeComponent();

			int curDate = WeekRouletteView.InitDays(DateTime.Now);
			WeekRouletteView.DateChanged += WeekRouletteView_DateChanged;
			WeekRouletteView.SetActive(curDate);

			CalScraper scraper = new CalScraper("https://www.moodle.aau.dk/calmoodle/public/?sid=4334");
			lectures = scraper.GetLectures();

			DateChangeEvent d = new DateChangeEvent();
			d.date = DateTime.Now.Date;
			d.index = -1;
			WeekRouletteView_DateChanged(d,null);
		}

		private void WeekRouletteView_DateChanged(object sender, RoutedEventArgs e) {
			DateChangeEvent change = (DateChangeEvent) sender;
			if(change.index > 0) {
				WeekRouletteView.SetActive(change.index);
			}

			AgendaView.RemoveAll();
			LectureCont[] todaysLectures = Array.FindAll(lectures, (l) => l.Start.Date == change.date);
			Array.ForEach(todaysLectures, (l) => AgendaView.Add(new Lecture(l)));
		}
	}
}
