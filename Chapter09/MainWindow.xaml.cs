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
	private readonly DispatcherTimer _timer = new();

	private bool _isSliderMovable = false;

	public MainWindow()
	{
		InitializeComponent();
		SetTimer();
	}

	private void SetTimer()
	{
		_timer.Interval = TimeSpan.FromMilliseconds(500);
		_timer.Tick += new EventHandler(TimerTick);
	}

	private void TimerTick(object sender, EventArgs e)
	{
		if (_mediaPlayer.Source != null && _mediaPlayer.NaturalDuration.HasTimeSpan && !_isSliderMovable)
		{
			TxtTime.Text = _mediaPlayer.Position.ToString(@"mm\:ss");

			// Ustawienia dla ProgressBar
			TimeSpan ts = _mediaPlayer.NaturalDuration.TimeSpan;
			ProgressBarElapsedTime.Maximum = 100;
			ProgressBarElapsedTime.Value = ((double)_mediaPlayer.Position.TotalMilliseconds / ts.TotalMilliseconds) * 100;

			// Ustawienia dla Slider
			SliderElapsedTime.Maximum = _mediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
			SliderElapsedTime.Value = _mediaPlayer.Position.TotalMilliseconds;
		}
	}

	private void BtnSelectFile_Click(object sender, RoutedEventArgs e)
	{
		OpenFileDialog dialog = new()
		{
			Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*"
		};

		if (dialog.ShowDialog() == true)
		{
			_mediaPlayer.Open(new Uri(dialog.FileName));
			TxtSong.Text = $"Utwór: {dialog.FileName}";
			BtnPlay.IsEnabled = true;
			BtnPause.IsEnabled = true;
			BtnStop.IsEnabled = true;
			_timer.Start();
		}
	}

	private void BtnPlay_Click(object sender, RoutedEventArgs e)
		=> _mediaPlayer.Play();

	private void BtnPause_Click(object sender, RoutedEventArgs e)
		=> _mediaPlayer.Pause();

	private void BtnStop_Click(object sender, RoutedEventArgs e)
		=> _mediaPlayer.Stop();

	private void RadioColor_Checked(object sender, RoutedEventArgs e)
	{
		string color = ((sender as RadioButton).Content.ToString() == "Niebieski") ? "LightSkyBlue" : "LightGreen";
		ProgressBarElapsedTime.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(color);
	}

	private void SliderElapsedTime_DragStarted(object sender, DragStartedEventArgs e)
		=> _isSliderMovable = true;

	private void SliderElapsedTime_DragCompleted(object sender, DragCompletedEventArgs e)
	{
		_isSliderMovable = false;
		_mediaPlayer.Position = TimeSpan.FromMilliseconds(SliderElapsedTime.Value);
	}
}