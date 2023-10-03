namespace StoreManager.API.Controllers;

public record EmployeeModel(string FirstName, string LastName)
{
	public string FullName => string.Concat(FirstName, " ", LastName);
}
