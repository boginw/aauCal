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
	/// Interaction logic for Clock.xaml
	/// </summary>
	public partial class Clock : UserControl {
		System.Windows.Forms.Timer Timer = null;
		public Clock() {
			InitializeComponent();
			Timer = new System.Windows.Forms.Timer();
			Timer.Interval = 1000;
			Timer.Tick += new EventHandler(Tick);
			Timer.Enabled = true;
			Tick(null, null);
		}

		private void Tick(object sender, EventArgs e) {
			Time.Text = DateTime.Now.ToString("HH:mm");
			Date.Text = DateTime.Now.ToString("ddd. MMM. dd");
		}
	}
}
