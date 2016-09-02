using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MissionPlanner.Validators;

namespace MissionPlannerTests
{
	[TestFixture]
	public class NumericValidatorTests
	{
		// Int conversion 

		[Test]
		[TestCase(new object[] { "100", 0, 100})]
		[TestCase(new object[] { "0", -10, 10})]
		public void NumericValidator_Int_Validate_ValidInput(string value, int min, int max)
		{
			NumericValidator<int> validator = new NumericValidator<int>(min, max);
			Assert.True(validator.Validate(value));
			Assert.True(string.IsNullOrEmpty(validator.GetError()));
		}

		[Test]
		[TestCase(new object[] { "100", 0, 99 })]
		[TestCase(new object[] { "0", 1, 5 })]
		public void NumericValidator_Int_Validate_InvalidInput(string value, int min, int max)
		{
			NumericValidator<int> validator = new NumericValidator<int>(min, max);
			Assert.False(validator.Validate(value));
			Assert.True(!string.IsNullOrEmpty(validator.GetError()));
		}

		[Test]
		[TestCase(new object[] { "--100", 0, 100 })]
		[TestCase(new object[] { "", 0, 200 })]
		[TestCase(new object[] { "500.0", -100, 0 })]
		[TestCase(new object[] { "-1.0f", -10, 10 })]
		[TestCase(new object[] { "asd", -10, 10 })]
		[TestCase(new object[] { "0xfa", -10, 10 })]
		public void NumericValidator_Int_Validate_Bad(string value, int min, int max)
		{
			NumericValidator<int> validator = new NumericValidator<int>(min, max);
			Assert.False(validator.Validate(value));
			Assert.True(!string.IsNullOrEmpty(validator.GetError()));
		}

		// Float conversion 

		[Test]
		[TestCase(new object[] { "99.5", 0, 100 })]
		[TestCase(new object[] { "0.953e+1", -10, 10 })]
		[TestCase(new object[] { "+5", -10, 10 })]
		[TestCase(new object[] { "0", -10, 10 })]
		[TestCase(new object[] { "-.123", -10, 10 })]
		public void NumericValidator_Float_Validate_ValidInput(string value, float min, float max)
		{
			NumericValidator<float> validator = new NumericValidator<float>(min, max);
			Assert.True(validator.Validate(value));
			Assert.True(string.IsNullOrEmpty(validator.GetError()));
		}

		[Test]
		[TestCase(new object[] { "100.0", 0, 99 })]
		[TestCase(new object[] { "0", 1, 5 })]
		public void NumericValidator_Float_Validate_InvalidInput(string value, float min, float max)
		{
			NumericValidator<float> validator = new NumericValidator<float>(min, max);
			Assert.False(validator.Validate(value));
			Assert.True(!string.IsNullOrEmpty(validator.GetError()));
		}

		[Test]
		[TestCase(new object[] { "--100", 0, 100 })]
		[TestCase(new object[] { "", 0, 200 })]
		[TestCase(new object[] { "asd", -10, 10 })]
		[TestCase(new object[] { "0xfa", -10, 10 })]
		[TestCase(new object[] { "(10)", 0, 20 })]
		public void NumericValidator_Float_Validate_Bad(string value, float min, float max)
		{
			NumericValidator<float> validator = new NumericValidator<float>(min, max);
			Assert.False(validator.Validate(value));
			Assert.True(!string.IsNullOrEmpty(validator.GetError()));
		}

		// Double conversion 

		[Test]
		[TestCase(new object[] { "100", 0, 100 })]
		[TestCase(new object[] { "0", -10, 10 })]
		public void NumericValidator_Double_Validate_ValidInput(string value, double min, double max)
		{
			NumericValidator<double> validator = new NumericValidator<double>(min, max);
			Assert.True(validator.Validate(value));
			Assert.True(string.IsNullOrEmpty(validator.GetError()));
		}

		[Test]
		[TestCase(new object[] { "100", 0, 99 })]
		[TestCase(new object[] { "0", 1, 5 })]
		public void NumericValidator_Double_Validate_InvalidInput(string value, double min, double max)
		{
			NumericValidator<double> validator = new NumericValidator<double>(min, max);
			Assert.False(validator.Validate(value));
			Assert.True(!string.IsNullOrEmpty(validator.GetError()));
		}

		[Test]
		[TestCase(new object[] { "--100", 0, 100 })]
		[TestCase(new object[] { "", 0, 200 })]
		[TestCase(new object[] { "500.0", -100, 0 })]
		[TestCase(new object[] { "-1.0f", -10, 10 })]
		[TestCase(new object[] { "asd", -10, 10 })]
		[TestCase(new object[] { "0xfa", -10, 10 })]
		public void NumericValidator_Double_Validate_Bad(string value, double min, double max)
		{
			NumericValidator<double> validator = new NumericValidator<double>(min, max);
			Assert.False(validator.Validate(value));
			Assert.True(!string.IsNullOrEmpty(validator.GetError()));
		}
	}
}
