using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chapter03;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	private const string InfoStart = "Wpisz wymiar boku";
	private const string InfoCorrectNumber = "Wpisz liczbę dodatnią";

	public MainWindow() => InitializeComponent();

	private void TxtSide_TextChanged(object sender, TextChangedEventArgs e)
	{
		if (double.TryParse(TxtSide.Text, out double number) && number > 0)
		{
			TxtArea.Text = (number * number).ToString();
			TxtPerimeter.Text = (4 * number).ToString();
			TxtInformation.Text = string.Empty;
		}
		else
		{
			TxtInformation.Text = InfoCorrectNumber;
			TxtArea.Clear();
			TxtPerimeter.Clear();
		}
	}

	private void BtnClear_Click(object sender, RoutedEventArgs e)
	{
		TxtSide.Clear();
		TxtArea.Clear();
		TxtPerimeter.Clear();
		TxtInformation.Text = InfoStart;
	}

	private void BtnDraw_Click(object sender, RoutedEventArgs e)
	{
		var color = (SolidColorBrush)new BrushConverter().ConvertFromString(CbColors.Text);
		MainRectangle.Fill = color;
		MainRectangle.Opacity = ChbOpacity.IsChecked.Value ? 0.5 : 1;
	}

	private void RbHide_Checked(object sender, RoutedEventArgs e) => MainRectangle.Visibility = Visibility.Collapsed;

	private void RbShow_Checked(object sender, RoutedEventArgs e) => MainRectangle.Visibility = Visibility.Visible;
}