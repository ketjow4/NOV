using System;

namespace MissionPlanner.Validators
{
	public class NumericValidator<T> : NumericValidatorBase<T>, IValidator<T> where T: IConvertible, IComparable
	{
		public NumericValidator(T min, T max): base(min, max) { }
		
		public string GetError()
		{
			return Error;
		}

		public bool Validate(string textToValidate)
		{
			Error = string.Empty;
			if(string.IsNullOrEmpty(textToValidate))
			{
				Error = "The value cannot be empty";
				return false;
			}
			try
			{
				Value = NumberConverter<T>.GetValue(textToValidate);
				if (comparer.Compare(Value, Min) < 0)
				{
					Error = string.Format("The value cannot be less than {0}.", Min);
					return false;
				}
				else if (comparer.Compare(Value, Max) > 0)
				{
					Error = string.Format("The value cannot be greater than {0}.", Max);
					return false;
				}
			}
			catch(Exception e)
			{
				Error = e.Message;
				return false;
			}
			return true;
		}
	}
}
