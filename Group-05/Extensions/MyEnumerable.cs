namespace Extensions;

public static class MyEnumerable
{
	public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Predicate<T> predicate)
	{
		if (source == null) throw new ArgumentNullException(nameof(source));
		if (predicate == null) throw new ArgumentNullException(nameof(predicate));

		foreach (var item in source)
		{
			if (predicate(item))
			{
				yield return item;
			}
		}
	}
}
