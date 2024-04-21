using System.Collections.ObjectModel;

namespace Chapter11;

internal class TaskCollection : ObservableCollection<MyTask>
{
	public TaskCollection()
	{
		Add(new MyTask
		{
			Name = "Zamówienie",
			Description = "Zamówić 100 długopisów żelowych",
			Priority = 1
		});
		Add(new MyTask
		{
			Name = "Zaproszenie",
			Description = "Zaprosić kontrahentów na pokaz nowego produktu",
			Priority = 2
		});
		Add(new MyTask
		{
			Name = "Sprzątanie",
			Description = "Posprzątać magazyn",
			Priority = 3
		});
	}
}