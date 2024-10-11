using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Chapter05;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private Product _product;

	public MainWindow()
	{
		InitializeComponent();
		PrepareBinding();
		FillColors();
	}

	private void BtnConfirm_Click(object sender, RoutedEventArgs e)
		=> MessageBox.Show($"Wprowadzono dane:{Environment.NewLine}{_product}");

	private void PrepareBinding()
	{
		_product = new("DZ-10", "długopis żelowy", 132, "Katowice 1");
		GridProduct.DataContext = _product;
	}

	private void FillColors()
	{
		CbColors.ItemsSource = typeof(Brushes).GetProperties().Select(x => x.Name);
		CbColors.SelectedValue = "Red";
	}
}