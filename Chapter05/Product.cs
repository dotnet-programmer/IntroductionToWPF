namespace Chapter05;

internal class Product(string symbol, string name, int quantity, string warehouse)
{
	public string Symbol { get; set; } = symbol;
	public string Name { get; set; } = name;
	public int Quantity { get; set; } = quantity;
	public string Warehouse { get; set; } = warehouse;

	public override string ToString()
		=> $"{Symbol} {Name} {Quantity} {Warehouse}";
}