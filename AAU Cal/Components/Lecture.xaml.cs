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
	/// Interaction logic for Lecture.xaml
	/// </summary>
	public partial class Lecture : UserControl {
		public static DependencyProperty LectureTitleProperty = DependencyProperty.Register(
			"LectureTitle",
			typeof(string),
			typeof(Lecture),
			new PropertyMetadata(string.Empty)
		);
		public static DependencyProperty LectorNameProperty = DependencyProperty.Register(
			"LectorName",
			typeof(string),
			typeof(Lecture),
			new PropertyMetadata(string.Empty)
		);
		public static DependencyProperty LocationProperty = DependencyProperty.Register(
			"Location",
			typeof(string),
			typeof(Lecture),
			new PropertyMetadata(string.Empty)
		);
		public static DependencyProperty NoteProperty = DependencyProperty.Register(
			"Note",
			typeof(string),
			typeof(Lecture),
			new PropertyMetadata(string.Empty)
		);
		public static DependencyProperty StartTimeProperty = DependencyProperty.Register(
			"StartTime",
			typeof(DateTime),
			typeof(Lecture),
			new PropertyMetadata(null)
		);
		public static DependencyProperty EndTimeProperty = DependencyProperty.Register(
			"EndTime",
			typeof(DateTime),
			typeof(Lecture),
			new PropertyMetadata(null)
		);
		public static DependencyProperty DateFromDateToProperty = DependencyProperty.Register(
			"DateFromDateTo",
			typeof(string),
			typeof(Lecture),
			new PropertyMetadata(string.Empty)
		);

		public string LectureTitle {
			get { return (string) GetValue(LectureTitleProperty); }
			set { SetValue(LectureTitleProperty, value); }
		}
		public string LectorName {
			get { return (string) GetValue(LectorNameProperty); }
			set { SetValue(LectorNameProperty, value); }
		}
		public string Location {
			get { return (string) GetValue(LocationProperty); }
			set { SetValue(LocationProperty, value); }
		}
		public string Note {
			get { return (string) GetValue(NoteProperty); }
			set { SetValue(NoteProperty, value); }
		}
		public DateTime StartTime {
			get { return (DateTime) GetValue(StartTimeProperty); }
			set { SetValue(StartTimeProperty, value); }
		}
		public DateTime EndTime {
			get { return (DateTime) GetValue(EndTimeProperty); }
			set { SetValue(EndTimeProperty, value); }
		}
		public string DateFromDateTo {
			get { return StartTime.ToString("HH:mm") + " - " + EndTime.ToString("HH:mm"); }
			set { SetValue(DateFromDateToProperty, StartTime.ToString("HH:mm") + " - " + EndTime.ToString("HH:mm")); }
		}

		public Lecture() {
			InitializeComponent();
		}

		public Lecture(string LectureTitle, string LectorName, DateTime StartTime, DateTime EndTime, string Note, string Location) {
			InitializeComponent();
			this.LectureTitle = LectureTitle;
			this.LectorName = LectorName;
			this.StartTime = StartTime;
			this.EndTime = EndTime;
			this.Location = Location;
			this.Note = Note;
			this.DateFromDateTo = "";
		}

		public Lecture(LectureCont lecture) {
			InitializeComponent();
			this.LectureTitle = lecture.Title;
			this.LectorName = lecture.Lector;
			this.StartTime = lecture.Start;
			this.EndTime = lecture.End;
			this.Location = lecture.Location;
			this.Note = lecture.Note;
			this.DateFromDateTo = "";
		}
	}
}
