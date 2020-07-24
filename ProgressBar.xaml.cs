using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Threading;
using System.IO;

namespace CtrlX
{
	/// <summary>
	/// Interaction logic for ProgressBar.xaml
	/// </summary>
	public partial class ProgressBar : Window
	{
		public ProgressBar()
		{
			InitializeComponent();
		}

		private void CloseWindow()
		{
			Dispatcher.Invoke(() => {
				this.Close();
			});
		}
		private void Window_ContentRendered(object sender, EventArgs e)
		{
			BackgroundWorker worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.DoWork += worker_DoWork;
			worker.ProgressChanged += worker_ProgressChanged;

			worker.RunWorkerAsync();
		}

		void worker_DoWork(object sender, DoWorkEventArgs e)
		{
			for (int i = 0; i < 101; i++)
			{
				(sender as BackgroundWorker).ReportProgress(i);
				Thread.Sleep(1);
			}
			CloseWindow();
			Excel ex = new Excel();
			ex.Create();
			ex.Write();
		}

		void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			progress.Value = e.ProgressPercentage;
		}
    }
}
