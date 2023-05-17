using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Chapter06;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	internal readonly ObservableCollection<Product> _products;

	public MainWindow()
	{
		InitializeComponent();

		_products = new ObservableCollection<Product>
		{
			new Product("PW-20", "pióro wieczne", 75, "Katowice 2"),
			new Product("O1-11", "ołówek", 8, "Katowice 1"),
			new Product("DZ-10", "długopis żelowy", 1121, "Katowice 1"),
			new Product("DZ-12", "długopis kulkowy", 280, "Katowice 2")
		};

		LstProducts.ItemsSource = _products;

		CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LstProducts.ItemsSource);
		view.SortDescriptions.Add(new SortDescription("Warehouse", ListSortDirection.Ascending));
		view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));

		view.Filter = UserFilter;
	}

	private bool UserFilter(object item) => string.IsNullOrEmpty(TxtFilter.Text) || (item as Product).Name.IndexOf(TxtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0;

	private void TxtFilter_TextChanged(object sender, TextChangedEventArgs e) => CollectionViewSource.GetDefaultView(LstProducts.ItemsSource).Refresh();

	private void LstProducts_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
	{
		Window1 okno1 = new(this);
		okno1.ShowDialog();
	}

	private void BtnAdd_Click(object sender, RoutedEventArgs e)
	{
		Window1 okno1 = new(this, true);
		okno1.ShowDialog();
	}

	private void BtnDelete_Click(object sender, RoutedEventArgs e) => DeleteProduct();

	private void LstProducts_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
	{
		if (e.Key == System.Windows.Input.Key.Delete)
		{
			DeleteProduct();
		}
	}

	private void DeleteProduct()
	{
		Product product = LstProducts.SelectedItem as Product;
		if (MessageBox.Show($"Czy chcesz skasować produkt:{Environment.NewLine}{product}", "Potwierdzenie", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
		{
			_products.Remove(product);
		}
	}
}