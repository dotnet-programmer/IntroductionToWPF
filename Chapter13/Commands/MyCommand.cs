using System.Windows.Input;

namespace Chapter13.Commands;

internal class MyCommand : ICommand
{
	private readonly Action _execute;

	public MyCommand(Action executeMethod)
		=> _execute = executeMethod;

	public event EventHandler CanExecuteChanged;

	public void Execute(object parameter)
		=> _execute?.Invoke();

	public bool CanExecute(object parameter)
		=> true;
}