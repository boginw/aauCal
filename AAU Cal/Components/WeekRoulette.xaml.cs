using AAU_Cal.Objects;
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

namespace AAU_Cal.Components {
	/// <summary>
	/// Interaction logic for WeekRoulette.xaml
	/// </summary>
	public partial class WeekRoulette : UserControl {
		public event RoutedEventHandler DateChanged;
		private CircleButton[] days;
		public WeekRoulette() {
			InitializeComponent();
		}

		public int InitDays(DateTime date) {
			int curDayIndex = 0;
			int daysInWeek = 7;

			DateTime start = StartOfWeek(date, DayOfWeek.Monday);

			days = Enumerable.Range(0, daysInWeek)
				.Select(_ => {
					DateTime d = start.AddDays(_);
					if(d.Date == date.Date) {
						curDayIndex = _;
					}
					CircleButton b = new CircleButton(d, false);

					b.Click += CircleButtonClick;
					return b;
				})
				.ToArray();

			Array.ForEach(days, day => root.Children.Add(day));

			return curDayIndex;
		}

		private void CircleButtonClick(object sender, RoutedEventArgs e) {
			CircleButton b = (CircleButton) sender;
			DateChangeEvent change = new DateChangeEvent();
			change.date = b.dateTime;
			change.index = Array.IndexOf(days, b);

			this.DateChanged?.Invoke(change, e);
		}

		public void SetActive(int index) {
			foreach(CircleButton day in days) {
				day.IsActive = false;
			}
			//days.Select(d => d.IsActive = false);
			days[index].IsActive = true;
		}

		public DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek) {
			int diff = dt.DayOfWeek - startOfWeek;
			if(diff < 0) {
				diff += 7;
			}
			return dt.AddDays(-1 * diff).Date;
		}
	}
}
