using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Linq;

namespace Chapter07;

/// <summary>
/// Interaction logic for Window1.xaml
/// </summary>
public partial class Window1 : Window
{
	// Plik źródłowy
	private readonly string _file1 = @"Products.xml";

	// Plik wynikowy
	private readonly string _file2 = @"Products2.xml";

	private XElement _products;

	public Window1()
	{
		InitializeComponent();
		PrepareBinding();
	}

	private void PrepareBinding()
	{
		if (File.Exists(_file1))
		{
			// Załadowanie danych z pliku źródłowego
			_products = XElement.Load(_file1);
		}

		GridProducts.DataContext = _products;
		ObservableCollection<string> warehouses = ["Katowice 1", "Katowice 2", "Gliwice 1"];
		WarehouseName.ItemsSource = warehouses;
	}

	private void BtnSave_Click(object sender, RoutedEventArgs e)
	{
		// Zapisanie danych do pliku wynikowego
		_products.Save(_file2);
		MessageBox.Show("Pomyślnie zapisano dane do pliku");
	}
}