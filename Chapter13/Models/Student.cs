using System.ComponentModel;

namespace Chapter13.Models;

public class Student : INotifyPropertyChanged
{
	private string _name;
	private string _surname;
	private int _yearStartStudies;

	public string Name
	{
		get => _name;
		set
		{
			if (_name != value)
			{
				_name = value;
				OnPropertyChanged(nameof(Name));
			}
		}
	}

	public string Surname
	{
		get => _surname;
		set
		{
			if (_surname != value)
			{
				_surname = value;
				OnPropertyChanged(nameof(Surname));
			}
		}
	}

	public int YearStartStudies
	{
		get => _yearStartStudies;
		set
		{
			if (_yearStartStudies != value)
			{
				_yearStartStudies = value;
				OnPropertyChanged(nameof(YearStartStudies));
				OnPropertyChanged(nameof(LengthOfStudy));
			}
		}
	}

	public string LengthOfStudy
		=> (DateTime.Now.Year - YearStartStudies).ToString();

	// Implementacja interfejsu INotifyPropertyChanged
	public event PropertyChangedEventHandler PropertyChanged;

	private void OnPropertyChanged(string property)
		=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
}