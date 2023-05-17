namespace Chapter05;

internal class Product
{
	public string Symbol { get; set; }
	public string Name { get; set; }
	public int Quantity { get; set; }
	public string Warehouse { get; set; }

	public Product(string symbol, string name, int quantity, string warehouse)
	{
		Symbol = symbol;
		Name = name;
		Quantity = quantity;
		Warehouse = warehouse;
	}

	public override string ToString() => $"{Symbol} {Name} {Quantity} {Warehouse}";
}