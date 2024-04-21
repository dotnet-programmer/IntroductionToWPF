using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Win32;

namespace Chapter09;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private readonly MediaPlayer _mediaPlayer = new();
	private readonly DispatcherTimer _timer;

	private bool _isSliderMovable = false;

	public MainWindow()
	{
		InitializeComponent();
		_timer = new DispatcherTimer
		{
			Interval = TimeSpan.FromMilliseconds(500)
		};
		_timer.Tick += new EventHandler(TimerTick);
	}

	private void TimerTick(object sender, EventArgs e)
	{
		if (_mediaPlayer.Source != null && _mediaPlayer.NaturalDuration.HasTimeSpan && !_isSliderMovable)
		{
			txtCzas.Text = _mediaPlayer.Position.ToString(@"mm\:ss");
			// Ustawienia dla ProgressBar
			TimeSpan ts = _mediaPlayer.NaturalDuration.TimeSpan;
			pbGra.Maximum = 100;
			pbGra.Value = ((double)_mediaPlayer.Position.TotalMilliseconds / ts.TotalMilliseconds) * 100;
			// Ustawienia dla Slider
			slGra.Maximum = _mediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
			slGra.Value = _mediaPlayer.Position.TotalMilliseconds;
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
			_mediaPlayer.Open(new Uri(dialog.FileName));
			txtUtwor.Text = String.Format("Utwór: {0}", dialog.FileName);
			btnPlay.IsEnabled = true;
			btnPause.IsEnabled = true;
			btnStop.IsEnabled = true;
			_timer.Start();
		}
	}

	private void btnPlay_Click(object sender, RoutedEventArgs e)
		=> _mediaPlayer.Play();

	private void btnPause_Click(object sender, RoutedEventArgs e)
		=> _mediaPlayer.Pause();

	private void btnStop_Click(object sender, RoutedEventArgs e)
		=> _mediaPlayer.Stop();

	private void radio_Checked(object sender, RoutedEventArgs e)
	{
		var radio = sender as RadioButton;
		string kolor = (radio.Content.ToString() == "Niebieski") ? "LightSkyBlue" : "LightGreen";
		pbGra.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(kolor);
	}

	private void slGra_DragStarted(object sender, DragStartedEventArgs e)
		=> _isSliderMovable = true;

	private void slGra_DragCompleted(object sender, DragCompletedEventArgs e)
	{
		_isSliderMovable = false;
		_mediaPlayer.Position = TimeSpan.FromMilliseconds(slGra.Value);
	}
}