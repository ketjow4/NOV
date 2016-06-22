using System;
using System.Globalization;

namespace MissionPlanner.Validators
{
	public static class NumberConverter<T> where T:IConvertible, IComparable
	{
		public static T GetValue(string text)
		{
			text = text.Replace(',', '.');
			if(typeof(T) == typeof(int))
			{
				return (T)Convert.ChangeType(int.Parse(text, CultureInfo.InvariantCulture), typeof(T));
			}
			else if(typeof(T) == typeof(double))
			{
				return (T)Convert.ChangeType(double.Parse(text, CultureInfo.InvariantCulture), typeof(T));
			}
			else if(typeof(T) == typeof(float))
			{
				return (T)Convert.ChangeType(float.Parse(text, CultureInfo.InvariantCulture), typeof(T));
			}
			else
			{
				throw new NotSupportedException("The requested type is not supported by NumberConverter.");
			}
		}
	}
}
