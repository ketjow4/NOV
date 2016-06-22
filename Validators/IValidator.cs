namespace MissionPlanner.Validators
{
	public interface IValidator<T>
	{
		bool Validate(string textToValidate);
		string GetError();
	}
}
