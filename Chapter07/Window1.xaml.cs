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
	private readonly string plik1 = @"Products.xml";

	// Plik wynikowy
	private readonly string plik2 = @"Products2.xml";

	private XElement wykazProduktow;

	public Window1()
	{
		InitializeComponent();
		PrepareBinding();
	}

	private void PrepareBinding()
	{
		if (File.Exists(plik1))
		{
			// Załadowanie danych z pliku źródłowego
			wykazProduktow = XElement.Load(plik1);
		}

		GridProducts.DataContext = wykazProduktow;
		ObservableCollection<string> ListaMagazynow = new() { "Katowice 1", "Katowice 2", "Gliwice 1" };
		WarehouseName.ItemsSource = ListaMagazynow;
	}

	private void BtnSave_Click(object sender, RoutedEventArgs e)
	{
		// Zapisanie danych do pliku wynikowego
		wykazProduktow.Save(plik2);
		MessageBox.Show("Pomyślnie zapisano dane do pliku");
	}
}