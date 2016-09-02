using NUnit.Framework;
using System;
using MissionPlanner.Validators;

namespace MissionPlannerTests.Validators
{
	[TestFixture]
	public class NumberConverterTests
	{
		[Test]
		[TestCase(int.MinValue)]
		[TestCase(int.MaxValue)]
		[TestCase(-100)]
		[TestCase(100)]
		[TestCase(0)]
		public void NumberConverter_GetValue_ConvertsToInt(int value)
		{
			string valueString = value.ToString();
			int result = NumberConverter<int>.GetValue(valueString);
			Assert.Pass();
		}

		[Test]
		[TestCase("")]
		[TestCase("1.5")]
		[TestCase("-1.5")]
		[TestCase("--1.5")]
		[TestCase("17aasx")]
		[TestCase("adasv")]
		public void NumberConverter_GetValue_FailToConvertBadInputToInt(string value)
		{
			Assert.Throws<FormatException>(() => {
				int result = NumberConverter<int>.GetValue(value);
			});
		}

		[Test]
		[TestCase(double.MinValue / 10)]
		[TestCase(double.MaxValue / 10)]
		[TestCase(-100.321d)]
		[TestCase(100.83213465131d)]
		[TestCase(0.0d)]
		[TestCase(1d)]
		[TestCase(new object[] { 1.123456, true })]
		[TestCase(new object[] { -1.42, true })]
		public void NumberConverter_GetValue_ConvertsToDouble(double value, bool comma = false)
		{
			string valueString = value.ToString();
			if (comma)
			{
				valueString = valueString.Replace('.', ',');
			}
			double result = NumberConverter<double>.GetValue(valueString);
			Assert.Pass();
		}

		[Test]
		[TestCase("")]
		[TestCase("--1.5")]
		[TestCase("17aasx")]
		[TestCase("adasv")]
		public void NumberConverter_GetValue_FailToConvertBadInputToDouble(string value)
		{
			Assert.Throws<FormatException>(() => {
				double result = NumberConverter<double>.GetValue(value);
			});
		}

		[Test]
		[TestCase(float.MinValue)]
		[TestCase(float.MaxValue)]
		[TestCase(-100.4f)]
		[TestCase(100.42f)]
		[TestCase(0.0f)]
		[TestCase(new object[] { 1.123456f, true })]
		[TestCase(new object[] { -1.42f, true })]
		public void NumberConverter_GetValue_ConvertsToFloat(float value, bool comma = false)
		{
			string valueString = value.ToString();
			if (comma)
			{
				valueString = valueString.Replace('.', ',');
			}
			float result = NumberConverter<float>.GetValue(valueString);
			Assert.Pass();
		}

		[Test]
		[TestCase("")]
		[TestCase("--1.5")]
		[TestCase("17aasx")]
		[TestCase("adasv")]
		public void NumberConverter_GetValue_FailToConvertBadInputToFloat(string value)
		{
			Assert.Throws<FormatException>(() => {
				float result = NumberConverter<float>.GetValue(value);
			});
		}

		[Test]
		public void NumberConverter_UnsupportedNumberType()
		{
			Assert.Throws<NotSupportedException>(() => {
				ushort result = NumberConverter<ushort>.GetValue("128");
			});
		}
	}
}
