using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Chapter07;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private ObservableCollection<Product> _products;

	// Format Pack URI jest częścią specyfikacji XML Paper Specification (XPS).
	// Format ten jest definiowany jako: pack://URIPakietu/fragment_ścieżki.
	// zob.także(„Pack URIs in WPF”)
	private readonly string _path = "pack://application:,,,/Images/";

	public MainWindow()
	{
		InitializeComponent();
		PrepareBinding();
	}

	private void PrepareBinding()
	{
		_products =
		[
			new("O1-11", "ołówek", 8, "Katowice 1", new Uri(_path + "Confirm.png"), "Ołówek z gumką HB"),
			new("PW-20", "pióro wieczne", 75, "Katowice 2", new Uri(_path + "Cancel_1.png"), "Pióro ze złotą stalówką"),
			new("DZ-10", "długopis żelowy", 1121, "Katowice 1", new Uri(_path + "Cancel_2.png"), "Długopis z wkładem żelowym"),
			new("DZ-12", "długopis kulkowy", 280, "Katowice 2", new Uri(_path + "Refresh_2b.png"), "Długopis z wkładem kulkowym")
		];
		GridProducts.ItemsSource = _products;

		// dane wyświetlane w combo box w kolumnie magazyn
		ObservableCollection<string> warehouses = ["Katowice 1", "Katowice 2", "Gliwice 1"];
		WarehouseName.ItemsSource = warehouses;

		ICollectionView view = CollectionViewSource.GetDefaultView(GridProducts.ItemsSource);
		view.GroupDescriptions.Add(new PropertyGroupDescription("Warehouse"));
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		ProductsFromXml window = new();
		window.ShowDialog();
	}

	private void BtnImage_Click(object sender, RoutedEventArgs e)
	{
		Microsoft.Win32.OpenFileDialog dialog = new()
		{
			Title = "Wybierz zdjęcie",
			Filter = "Image files (*.jpg,*.png;*.jpeg)|*.jpg;*.png;*.jpeg|All files(*.*) | *.* ",
			InitialDirectory = @"C:\"
		};

		if (dialog.ShowDialog() == true)
		{
			(GridProducts.SelectedItem as Product).Image = new Uri(dialog.FileName);
			GridProducts.CommitEdit(DataGridEditingUnit.Cell, true);
			GridProducts.CommitEdit();
			CollectionViewSource.GetDefaultView(GridProducts.ItemsSource).Refresh();
		}
	}
}