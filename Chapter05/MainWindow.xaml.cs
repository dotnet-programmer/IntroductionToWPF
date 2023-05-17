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
	private readonly Product _product;

	public MainWindow()
	{
		InitializeComponent();

		_product = new("DZ-10", "długopis żelowy", 132, "Katowice 1");
		GridProduct.DataContext = _product;

		var colors = typeof(Brushes).GetProperties().Select(x => x.Name);
		CbColors.ItemsSource = colors;
		CbColors.SelectedValue = "Red";
	}

	private void BtnConfirm_Click(object sender, RoutedEventArgs e)
	{
		string text = $"Wprowadzono dane:{Environment.NewLine}{_product}";
		MessageBox.Show(text);
	}
}