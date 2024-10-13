using System.Windows;

namespace Chapter12;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
		=> InitializeComponent();

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		RegexValidation regexValidation = new();
		regexValidation.ShowDialog();
	}
}