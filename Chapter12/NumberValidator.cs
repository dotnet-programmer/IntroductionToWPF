using System.Globalization;
using System.Windows.Controls;

namespace Chapter12;

internal class NumberValidator : ValidationRule
{
	public double Min { get; set; }
	public double Max { get; set; }

	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		double checkedNumber = 0;
		try
		{
			if (value.ToString().Length > 0)
			{
				checkedNumber = double.Parse(value.ToString());
			}
		}
		catch (FormatException e)
		{
			return new ValidationResult(false, "Niedozwolone znaki - " + e.Message);
		}

		return checkedNumber < Min || checkedNumber > Max
			? new ValidationResult(false, "Wprowadź liczbę z zakresu: " + Min + " - " + Max)
			: new ValidationResult(true, null);
	}
}