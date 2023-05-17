using System.Windows;

namespace Chapter11;

/// <summary>
/// Interaction logic for SzablonyKontrolek.xaml
/// </summary>
public partial class SzablonyKontrolek : Window
{
	public SzablonyKontrolek() => InitializeComponent();

	private void Button_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Zapisano dane!");
}