namespace Chapter11;

internal class Zadanie
{
	public string Nazwa { get; set; }
	public string Opis { get; set; }
	public int Priorytet { get; set; }

	public override string ToString() => $"{Nazwa} {Opis} {Priorytet}";
}