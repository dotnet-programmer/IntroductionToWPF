using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Linq;

namespace Chapter07;

/// <summary>
/// Interaction logic for Window1.xaml
/// </summary>
public partial class ProductsFromXml : Window
{
	// Plik źródłowy
	private readonly string _file1 = @"Products.xml";

	// Plik wynikowy
	private readonly string _file2 = @"Products2.xml";

	private XElement _products;

	public ProductsFromXml()
	{
		InitializeComponent();
		PrepareBinding();
	}

	private void PrepareBinding()
	{
		// Załadowanie danych z pliku źródłowego
		if (File.Exists(_file1))
		{
			_products = XElement.Load(_file1);
		}
		GridProducts.DataContext = _products;

		ObservableCollection<string> warehouses = ["Katowice 1", "Katowice 2", "Gliwice 1"];
		WarehouseName.ItemsSource = warehouses;
	}

	// Zapisanie danych do pliku wynikowego
	private void BtnSave_Click(object sender, RoutedEventArgs e)
	{
		_products.Save(_file2);
		MessageBox.Show("Pomyślnie zapisano dane do pliku");
	}
}