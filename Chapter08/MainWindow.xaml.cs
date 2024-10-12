using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Chapter08;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
		=> InitializeComponent();

	#region Menu option click event handlers

	private void FrameOn_Click(object sender, RoutedEventArgs e)
	{
		if (WebBrowserFrame != null)
		{
			WebBrowserFrame.BorderThickness = new Thickness(3);
		}
	}

	private void FrameOff_Click(object sender, RoutedEventArgs e)
	{
		if (WebBrowserFrame != null)
		{
			WebBrowserFrame.BorderThickness = new Thickness(0);
		}
	}

	private void SaveSiteToFile_Click(object sender, RoutedEventArgs e)
	{
		Microsoft.Win32.SaveFileDialog dialog = new()
		{
			Filter = "WebPage|*.html",
			DefaultExt = ".html"
		};
		dynamic document = MainWebBrowser.Document;
		if (document != null)
		{
			var htmlText = document.documentElement.InnerHtml;
			if (dialog.ShowDialog() == true && htmlText != null)
			{
				File.WriteAllText(dialog.FileName, htmlText);
			}
		}
	}

	private void PlaceholderMethod_Click(object sender, RoutedEventArgs e)
		=> MessageBox.Show("Opcja w budowie");

	private void About_Click(object sender, RoutedEventArgs e)
		=> MessageBox.Show("Prosta przeglądarka www, Wersja 1.0");

	private void Exit_Click(object sender, RoutedEventArgs e)
		=> Close();

	#endregion Menu option click event handlers

	#region ToolBar option click event handlers

	private void BtnBack_Click(object sender, RoutedEventArgs e)
	{
		if (MainWebBrowser.CanGoBack)
		{
			MainWebBrowser.GoBack();
		}
	}

	private void BtnNext_Click(object sender, RoutedEventArgs e)
	{
		if (MainWebBrowser.CanGoForward)
		{
			MainWebBrowser.GoForward();
		}
	}

	private void TxtAddress_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.Enter)
		{
			MainWebBrowser.Navigate(TxtAddress.Text);
		}
	}

	private void BtnEnter_Click(object sender, RoutedEventArgs e)
		=> MainWebBrowser.Navigate(TxtAddress.Text);

	private void BtnTreeView_Click(object sender, RoutedEventArgs e)
	{
		TreeViewTest window = new();
		window.ShowDialog();
	}

	#endregion ToolBar option click event handlers

	#region WebBrowser option click event handlers

	// Aktualizacja pola tekstowego z adresem
	private void MainWebBrowser_Navigating(object sender, NavigatingCancelEventArgs e)
		=> TxtAddress.Text = e.Uri.OriginalString;

	// Wywołanie metody ukrywającej błędy JavaScriptu
	private void MainWebBrowser_Navigated(object sender, NavigationEventArgs e)
		=> HideScriptErrors(MainWebBrowser, true);

	// Ukrycie błędów JavaScriptu, rozwiązanie ze strony MSDN "Suppress Script Errors in Windows.Controls.Webbrowser"
	// Typ wyliczeniowy BindingFlags wymaga przestrzeni nazw using System.Reflection;
	public void HideScriptErrors(WebBrowser wb, bool Hide)
	{
		dynamic activeX = MainWebBrowser.GetType().InvokeMember(
			"ActiveXInstance",
			BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
			null,
			MainWebBrowser,
			System.Array.Empty<object>());

		activeX.Silent = true;
	}

	#endregion WebBrowser option click event handlers
}