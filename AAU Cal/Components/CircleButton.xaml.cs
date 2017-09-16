using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
	/// Interaction logic for CircleButton.xaml
	/// </summary>
	public partial class CircleButton : UserControl {
		public event RoutedEventHandler Click;

		public static DependencyProperty TextProperty = DependencyProperty.Register(
			"Text",
			typeof(string),
			typeof(CircleButton),
			new PropertyMetadata(string.Empty)
		);
		
		public string Text {
			get { return (string) GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		public static DependencyProperty WeekTextProperty = DependencyProperty.Register(
			"WeekText",
			typeof(string),
			typeof(CircleButton),
			new PropertyMetadata(string.Empty)
		);

		public string WeekText {
			get { return (string) GetValue(WeekTextProperty); }
			set { SetValue(WeekTextProperty, value); }
		}

		public static DependencyProperty IsActiveProperty = DependencyProperty.Register(
			"IsActive",
			typeof(bool),
			typeof(CircleButton),
			new UIPropertyMetadata(false)
		);

		private DateTime _dateTime;
		public DateTime dateTime {
			get { return _dateTime; }
			set {
				_dateTime = value;
				Text = _dateTime.Day.ToString();
				WeekText = _dateTime.ToString("ddd");
			}
		}
		

		public bool IsActive {
			get { return (bool) GetValue(IsActiveProperty); }
			set { SetValue(IsActiveProperty, value); }
		}

		public CircleButton(string Date, bool Active) {
			InitializeComponent();
			this.Text = Date;
			this.IsActive = Active;
		}

		public CircleButton() {
			InitializeComponent();
		}

		public CircleButton(DateTime dateTime, bool Active) {
			InitializeComponent();
			this.dateTime = dateTime;
			this.IsActive = Active;
		}

		private void OnClick(object sender, MouseButtonEventArgs e) {
			this.Click?.Invoke(this, e);
		}

	}

}
