using System.ComponentModel;

namespace Chapter12;

//internal class Article
//{
//	public string Name { get; set; }
//	public double Price { get; set; }
//}

internal class Article : IDataErrorInfo
{
	public string Name { get; set; }
	public double Price { get; set; }

	// „Pusta” implementacja właściwości Error
	// Właściwość Error została przewidziana dla błędów, które dotyczą całego obiektu (tu nie wykorzystano tej możliwości).
	public string Error
		=> throw new NotImplementedException();

	// Implementacja indeksatora
	public string this[string propertyName]
	{
		get
		{
			string error = string.Empty;
			switch (propertyName)
			{
				case nameof(Name):
					if (string.IsNullOrEmpty(Name))
					{
						error = "Nazwa musi być wpisana!";
					}
					else if (Name.Length < 3)
					{
						error = "Nazwa minimum 3 znaki!";
					}
					break;
				case nameof(Price):
					if (Price is < 0.01 or > 1000)
					{
						error = "Cena musi być z zakresu od 0,01 do 1000";
					}
					break;
			};
			return error;
		}
	}
}