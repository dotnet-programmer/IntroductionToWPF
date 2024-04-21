﻿using System.IO;
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

	// Metody obsługi zdarzeń kliknięcia opcji Menu

	// Włączenie ramki
	private void RamkaOn_Click(object sender, RoutedEventArgs e)
	{
		if (brdRamka != null)
		{
			brdRamka.BorderThickness = new Thickness(3);
		}
	}

	// Wyłączenie ramki
	private void RamkaOff_Click(object sender, RoutedEventArgs e)
	{
		if (brdRamka != null)
		{
			brdRamka.BorderThickness = new Thickness(0);
		}
	}

	// Zapisanie strony do pliku
	private void Zapisz_Click(object sender, RoutedEventArgs e)
	{
		Microsoft.Win32.SaveFileDialog dialog = new()
		{
			Filter = "WebPage|*.html",
			DefaultExt = ".html"
		};
		dynamic doc = wbPrzegladarka.Document;
		if (doc != null)
		{
			var htmlText = doc.documentElement.InnerHtml;
			if (dialog.ShowDialog() == true && htmlText != null)
			{
				// File wymaga using System.IO;
				File.WriteAllText(dialog.FileName, htmlText);
			}
		}
	}

	// Tymczasowa metoda dla niegotowych opcji
	private void Tmp_Click(object sender, RoutedEventArgs e)
		=> MessageBox.Show("Opcja w budowie");

	// Informacje o programie
	private void OProgramie_Click(object sender, RoutedEventArgs e)
		=> MessageBox.Show("Prosta przeglądarka www, Wersja 1.0, Helion 2017");

	// Wyjście  (zamknięcie okna aplikacji)
	private void Exit_Click(object sender, RoutedEventArgs e)
		=> Close();

	// Metody obsługi zdarzeń dla kontrolek umieszczonych w ToolBar
	private void btnWejdz_Click(object sender, RoutedEventArgs e)
		=> wbPrzegladarka.Navigate(txtAdres.Text);

	private void btnWstecz_Click(object sender, RoutedEventArgs e)
	{
		if (wbPrzegladarka.CanGoBack)
		{
			wbPrzegladarka.GoBack();
		}
	}

	private void btnDalej_Click(object sender, RoutedEventArgs e)
	{
		if (wbPrzegladarka.CanGoForward)
		{
			wbPrzegladarka.GoForward();
		}
	}

	private void txtAdres_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.Enter)
		{
			wbPrzegladarka.Navigate(txtAdres.Text);
		}
	}

	// Metody obsługi zdarzeń dla kontrolki WebBrowser (Navigating i Navigated)
	private void wbPrzegladarka_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
		=> txtAdres.Text = e.Uri.OriginalString;   // Aktualizacja pola tekstowego z adresem

	// Wywołanie metody ukrywającej błędy JavaScriptu

	private void wbPrzegladarka_Navigated(object sender, NavigationEventArgs e)
		=> HideScriptErrors(wbPrzegladarka, true);

	public void HideScriptErrors(WebBrowser wb, bool Hide)
	{
		// Ukrycie błędów JavaScriptu, rozwiązanie ze strony MSDN "Suppress Script Errors in Windows.Controls.Webbrowser"
		// Typ wyliczeniowy BindingFlags wymaga przestrzeni nazw using System.Reflection;
		dynamic activeX = wbPrzegladarka.GetType().InvokeMember(
			"ActiveXInstance",
			BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
			null,
			this.wbPrzegladarka,
			new object[] { });

		activeX.Silent = true;
	}

	private void BtnNewWindow_Click(object sender, RoutedEventArgs e)
	{
		var window = new Window1();
		window.ShowDialog();
	}
}