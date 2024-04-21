namespace Chapter11;

internal class MyTask
{
	public string Name { get; set; }
	public string Description { get; set; }
	public int Priority { get; set; }

	public override string ToString()
		=> $"{Name} {Description} {Priority}";
}