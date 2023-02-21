namespace G05_LINQ;

internal static class DataProvider
{
	public static IEnumerable<Product> GetTestData() =>
		new List<Product>
		{
				new(1, "Apple", 0.99m),
				new(2, "Banana", 0.69m),
				new(3, "Carrot", 1.29m),
				new(4, "Donut", 0.89m),
				new(5, "Eggplant", 2.49m),
				new(6, "Frozen Pizza", 5.99m),
				new(7, "Grapes", 3.99m),
				new(8, "Honey", 8.99m),
				new(9, "Ice Cream", 4.99m),
				new(10, "Juice", 2.99m)
		};
}
