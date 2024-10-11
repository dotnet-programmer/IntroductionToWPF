using System;
using System.Windows;
using System.Windows.Input;

namespace Chapter02;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
		=> InitializeComponent();

	private void BtnStart_Click(object sender, RoutedEventArgs e)
	{
		BtnStart.Opacity = 0.2;
		BtnEnableStart.Visibility = Visibility.Hidden;
		MessageBox.Show("Hello world");
		BtnEnableStart.Visibility = Visibility.Visible;
		BtnStart.Opacity = 1;
	}

	private void BtnTime_MouseEnter(object sender, MouseEventArgs e)
		=> BtnTime.Content = DateTime.Now.ToString("T");

	private void BtnTime_MouseLeave(object sender, MouseEventArgs e)
		=> BtnTime.Content = "Time";

	private void BtnEnableStart_Click(object sender, RoutedEventArgs e)
	{
		BtnStart.IsEnabled = true;
		BtnEnableStart.IsEnabled = false;
	}

	private void BtnYes_MouseEnter(object sender, MouseEventArgs e)
		=> (BtnYes.Margin, BtnNo.Margin) = (BtnNo.Margin, BtnYes.Margin);
}