using System.Diagnostics;
using System.Windows.Input;

namespace Chapter13.Commands;

public class RelayCommand : ICommand
{
	private readonly Action<object> _execute;
	private readonly Predicate<object> _canExecute;

	public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
	{
		ArgumentNullException.ThrowIfNull(execute);
		_execute = execute;
		_canExecute = canExecute;
	}

	public event EventHandler CanExecuteChanged
	{
		add
		{
			if (_canExecute != null)
			{
				CommandManager.RequerySuggested += value;
			}
		}
		remove
		{
			if (_canExecute != null)
			{
				CommandManager.RequerySuggested -= value;
			}
		}
	}

	[DebuggerStepThrough]
	public bool CanExecute(object parameter)
		=> _canExecute == null || _canExecute(parameter);

	public void Execute(object parameter)
		=> _execute(parameter);
}