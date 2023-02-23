﻿namespace Extensions;

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

    public static IEnumerable<T> MyUnion<T>(this IEnumerable<T> firstEnumerable, IEnumerable<T> secondEnumerable)
    {
        if (firstEnumerable == null) throw new ArgumentNullException(nameof(firstEnumerable));
        if (secondEnumerable == null) throw new ArgumentNullException(nameof(secondEnumerable));

        HashSet<T> result = new HashSet<T>();

        foreach (var item in firstEnumerable)
        {
            result.Add(item);
        }

        foreach (var item in secondEnumerable)
        {
            result.Add(item);
        }

        return result;
    }
}
