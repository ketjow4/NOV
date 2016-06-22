using System;
using System.Collections.Generic;

namespace MissionPlanner.Validators
{
	public class NumericValidatorBase<T> where T: IConvertible, IComparable
	{
		public Comparer<T> comparer = Comparer<T>.Default;
		T value;
		T min;
		T max;
		public string Error;

		public NumericValidatorBase(T _min, T _max)
		{
			min = _min;
			max = _max;
		}

		public T Value
		{
			get
			{
				return value;
			}

			set
			{
				this.value = value;
			}
		}

		public T Min
		{
			get
			{
				return min;
			}

			set
			{
				min = value;
			}
		}

		public T Max
		{
			get
			{
				return max;
			}

			set
			{
				max = value;
			}
		}
	}
}
