using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Chapter12;

internal class Person : IDataErrorInfo
{
	public string Surname { get; set; }
	public string Name { get; set; }
	public string Pesel { get; set; }
	public string PostalCode { get; set; }

	public string Error
		=> throw new NotImplementedException();

	public string this[string propertyName]
	{
		get
		{
			string error = string.Empty;
			switch (propertyName)
			{
				case nameof(Surname):
					if (string.IsNullOrEmpty(Surname))
					{
						error = "Nazwisko musi być wpisane!";
					}
					// Proste sprawdzanie czy nazwisko składa się z pierwszej dużej litery i przynajmniej jednej małej litery
					//else if (!Regex.IsMatch(Surname, "^[A-Z][a-z]+$"))

					// Możliwość wpisania nazwisk maksymalnie trójczłonowych,
					// z których każdy człon składa się z pierwszej dużej litery i minimum jednej małej litery.
					// Człony mogą być oddzielone myślnikiem.
					// Wersja uwzględniająca polskie znaki.
					else if (!Regex.IsMatch(Surname, @"^\p{Lu}\p{Ll}+((\s|-)\p{Lu}\p{Ll}+){0,2}$"))
					{
						error = "Nazwisko z dużej litery i minimum 2 znaki!";
					}
					break;

				case nameof(Name):
					if (string.IsNullOrEmpty(Name))
					{
						error = "Należy wpisać imię lub imiona!";
					}
					else if (!Regex.IsMatch(Name, @"^[A-Z][a-z]+(\s[A-Z][a-z]+)*$"))
					{
						error = "Imiona z dużej litery i minimum 2 znaki";
					}
					break;

				case nameof(Pesel):
					if (string.IsNullOrEmpty(Pesel))
					{
						error = "Pesel musi być wpisany!";
					}
					else if (!Regex.IsMatch(Pesel, @"^\d{11}$"))
					{
						error = "Numer PESEL musi mieć 11 znaków";
					}
					break;

				case nameof(PostalCode):
					if (string.IsNullOrEmpty(PostalCode))
					{
						error = "Kod pocztowy musi być wpisany!";
					}
					else if (!Regex.IsMatch(PostalCode, @"^\d{2}-\d{3}$"))
					{
						error = "Kod pocztowy ma mieć format 99-999";
					}
					break;
			};
			return error;
		}
	}
}