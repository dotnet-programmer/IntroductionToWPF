using System.ComponentModel;
using System.Windows;
using Chapter13.Commands;
using Chapter13.Models;

namespace Chapter13.ViewModels;

internal class StudentViewModel : INotifyPropertyChanged
{
	private Student _student;

	public Student Student
	{
		get => _student;
		set
		{
			_student = value;
			OnPropertyChanged("Kursant");
		}
	}

	public MyCommand ClearDataCommand { get; set; }

	public StudentViewModel()
	{
		Student = new Student
		{
			Name = "Jan",
			Surname = "Kowalski",
			YearStartStudies = 2022
		};

		ClearDataCommand = new MyCommand(ClearData);
	}

	private void ClearData()
	{
		if (MessageBox.Show("Czy wyczyścić dane studenta?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
		{
			Student.Name = string.Empty;
			Student.Surname = string.Empty;
			Student.YearStartStudies = DateTime.Now.Year;
		}
	}

	// Implementacja interfejsu INotifyPropertyChanged
	public event PropertyChangedEventHandler PropertyChanged;

	private void OnPropertyChanged(string property)
		=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
}