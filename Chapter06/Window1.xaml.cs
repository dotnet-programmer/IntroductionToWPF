using System.Windows;

namespace Chapter06;

/// <summary>
/// Interaction logic for Window1.xaml
/// </summary>
public partial class Window1 : Window
{
	private readonly MainWindow _mainWindow;
	private readonly bool _isNewProduct;
	private Product _newProduct;

	public Window1()
		=> InitializeComponent();

	// Przeładowana (przeciążona) wersja konstruktora z obiektem dla głównego okna jako argumentem
	public Window1(MainWindow mainWin, bool isNewProduct = false)
	{
		InitializeComponent();
		_mainWindow = mainWin;
		_isNewProduct = isNewProduct;
		PrepareBinding();
	}

	private void PrepareBinding()
	{
		if (_isNewProduct)
		{
			_newProduct = new Product("AA-00", "", 0, "");
			GridProduct.DataContext = _newProduct;
		}
		else
		{
			if (_mainWindow.LstProducts.SelectedItem is Product productFromList)
			{
				// Wybrany produkt z listy
				GridProduct.DataContext = productFromList;
			}
		}
	}

	private void BtnConfirm_Click(object sender, RoutedEventArgs e)
	{
		if (_isNewProduct)
		{
			_mainWindow._products.Add(_newProduct);
		}

		this.DialogResult = true;

		// Zamknięcie bieżącego okna
		//this.Close();
	}
}