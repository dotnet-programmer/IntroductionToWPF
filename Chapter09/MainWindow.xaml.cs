using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;

namespace Chapter09;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private readonly MediaPlayer mediaPlayer = new();
	private readonly DispatcherTimer timer;
	private bool czySuwakJestPrzesuwany = false;

	public MainWindow()
	{
		InitializeComponent();
		timer = new DispatcherTimer
		{
			Interval = TimeSpan.FromMilliseconds(500)
		};
		timer.Tick += new EventHandler(timerTick);
	}

	private void timerTick(object sender, EventArgs e)
	{
		if (mediaPlayer.Source != null && mediaPlayer.NaturalDuration.HasTimeSpan && !czySuwakJestPrzesuwany)
		{
			txtCzas.Text = mediaPlayer.Position.ToString(@"mm\:ss");
			// Ustawienia dla ProgressBar
			TimeSpan ts = mediaPlayer.NaturalDuration.TimeSpan;
			pbGra.Maximum = 100;
			pbGra.Value = ((double)mediaPlayer.Position.TotalMilliseconds / ts.TotalMilliseconds) * 100;
			// Ustawienia dla Slider
			slGra.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
			slGra.Value = mediaPlayer.Position.TotalMilliseconds;
		}
	}

	private void btnWybierz_Click(object sender, RoutedEventArgs e)
	{
		OpenFileDialog dialog = new()
		{
			Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*"
		};
		if (dialog.ShowDialog() == true)
		{
			mediaPlayer.Open(new Uri(dialog.FileName));
			txtUtwor.Text = String.Format("Utwór: {0}", dialog.FileName);
			btnPlay.IsEnabled = true;
			btnPause.IsEnabled = true;
			btnStop.IsEnabled = true;
			timer.Start();
		}
	}

	private void btnPlay_Click(object sender, RoutedEventArgs e) => mediaPlayer.Play();

	private void btnPause_Click(object sender, RoutedEventArgs e) => mediaPlayer.Pause();

	private void btnStop_Click(object sender, RoutedEventArgs e) => mediaPlayer.Stop();

	private void radio_Checked(object sender, RoutedEventArgs e)
	{
		var radio = sender as RadioButton;
		string kolor = (radio.Content.ToString() == "Niebieski") ? "LightSkyBlue" : "LightGreen";
		pbGra.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(kolor);
	}

	private void slGra_DragStarted(object sender, DragStartedEventArgs e) => czySuwakJestPrzesuwany = true;

	private void slGra_DragCompleted(object sender, DragCompletedEventArgs e)
	{
		czySuwakJestPrzesuwany = false;
		mediaPlayer.Position = TimeSpan.FromMilliseconds(slGra.Value);
	}
}