using System.Windows;

namespace Chapter10;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
		=> InitializeComponent();

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Window1 window = new();
		window.Show();
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		Window2 window = new();
		window.Show();
	}
}