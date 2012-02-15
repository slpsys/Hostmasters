using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hostmasters.DAL;
using Ninject;

namespace Hostmasters
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// Gets or sets the controller.
		/// </summary>
		/// <value>The controller.</value>
		public Hostmaster controller { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="MainWindow"/> class.
		/// </summary>
		public MainWindow()
		{
			InitializeComponent();
			
			IKernel kernel = new StandardKernel();
			kernel.Bind<IHostmastersDAL>().To<RavenDAL>();
			this.controller = kernel.Get<Hostmaster>();
		}
	}
}
