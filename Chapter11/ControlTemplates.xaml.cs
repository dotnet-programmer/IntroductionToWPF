using System.Windows;

namespace Chapter11;

/// <summary>
/// Interaction logic for SzablonyKontrolek.xaml
/// </summary>
public partial class ControlTemplates : Window
{
	public ControlTemplates()
		=> InitializeComponent();

	private void Button_Click(object sender, RoutedEventArgs e)
		=> MessageBox.Show("Przycisk działa!");
}