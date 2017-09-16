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
	/// Interaction logic for Agenda.xaml
	/// </summary>
	public partial class Agenda : UserControl {
		public Agenda() {
			InitializeComponent();
		}

		public void Add(Lecture lecture) {
			root.Children.Add(lecture);
		}

		public void RemoveAll() {
			root.Children.RemoveRange(0, root.Children.Count);
		}
	}
}
