using System.Windows;

namespace Chapter11;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow() => InitializeComponent();

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		SzablonyKontrolek szablonyKontrolek = new();
		szablonyKontrolek.ShowDialog();
	}
}