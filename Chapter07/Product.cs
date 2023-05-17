using System;

namespace Chapter07;

internal class Product
{
	public string Symbol { get; set; }
	public string Name { get; set; }
	public int Quantity { get; set; }
	public string Warehouse { get; set; }
	public Uri Image { get; set; }
	public string Description { get; set; }

	// wymagany przez DataGrid
	public Product()
	{
	}

	public Product(string symbol, string name, int quantity, string warehouse, Uri image, string description)
	{
		Symbol = symbol;
		Name = name;
		Quantity = quantity;
		Warehouse = warehouse;
		Image = image;
		Description = description;
	}

	public override string ToString() => $"{Symbol} {Name} {Quantity} {Warehouse}";
}