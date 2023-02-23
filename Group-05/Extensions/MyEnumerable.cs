using System;
using System.Linq;

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

    public static IEnumerable<T> MyConcat<T>(this IEnumerable<T> firstEnumerable, IEnumerable<T> secondEnumerable)
    {
        if (firstEnumerable == null) throw new ArgumentNullException(nameof(firstEnumerable));
        if (secondEnumerable == null) throw new ArgumentNullException(nameof(secondEnumerable));

        foreach (var item in firstEnumerable)
        {
            yield return item;
        }

        foreach (var item in secondEnumerable)
        {
            yield return item;
        }
    }

    public static IEnumerable<T> MyExcept<T>(this IEnumerable<T> firstEnumerable, IEnumerable<T> secondEnumerable)
    {
        if (firstEnumerable == null) throw new ArgumentNullException(nameof(firstEnumerable));
        if (secondEnumerable == null) throw new ArgumentNullException(nameof(secondEnumerable));

        firstEnumerable = firstEnumerable.MyDistinct();
        secondEnumerable = secondEnumerable.MyDistinct();

        foreach (var item in firstEnumerable)
        {
            if (!secondEnumerable.Contains(item))
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<T> MyIntersect<T>(this IEnumerable<T> firstEnumerable, IEnumerable<T> secondEnumerable)
    {
        if (firstEnumerable == null) throw new ArgumentNullException(nameof(firstEnumerable));
        if (secondEnumerable == null) throw new ArgumentNullException(nameof(secondEnumerable));

        firstEnumerable = firstEnumerable.MyDistinct();
        secondEnumerable = secondEnumerable.MyDistinct();

        foreach (var item in firstEnumerable)
        {
            if (secondEnumerable.Contains(item))
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<T> MyDistinct<T>(this IEnumerable<T> enumerable)
    {
        if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));

        HashSet<T> result = new HashSet<T>();

        foreach (var item in enumerable)
        {
            result.Add(item);
        }

        return result;
    }

    public static T MyFirst<T>(this IEnumerable<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        return source.ToArray()[0];

        throw new ArgumentNullException(nameof(source));
    }

    public static T MyFirst<T>(this IEnumerable<T> source, Predicate<T> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        foreach (var item in source)
        {
            if (predicate(item))
            {
                return item;
            }
        }

        throw new ArgumentNullException(nameof(source));
    }

    public static T? MyFirstOrDefault<T>(this IEnumerable<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        if (source.Count() > 0) return source.MyFirst();

        return default(T);
    }

    public static T? MyFirstOrDefault<T>(this IEnumerable<T> source, Predicate<T> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        foreach (var item in source)
        {
            if (predicate(item))
            {
                return item;
            }
        }

        return default(T);
    }

    public static T MyLast<T>(this IEnumerable<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        return source.ToList()[source.Count() - 1];

        throw new ArgumentNullException(nameof(source));
    }

    public static T MyLast<T>(this IEnumerable<T> source, Predicate<T> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        for (int i = source.Count() - 1; i >= 0; i--)
        {
            if (predicate(source.ToArray()[i]))
            {
                return source.ToArray()[i];
            }
        }

        throw new ArgumentNullException(nameof(source));
    }

    public static T? MyLastOrDefault<T>(this IEnumerable<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        if (source.Count() > 0) return source.MyLast();

        return default(T);
    }

    public static T? MyLastOrDefault<T>(this IEnumerable<T> source, Predicate<T> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        for (int i = source.Count() - 1; i >= 0; i--)
        {
            if (predicate(source.ToArray()[i]))
            {
                return source.ToArray()[i];
            }
        }

        return default(T);
    }

    public static T MySingle<T>(this IEnumerable<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        if (source.Count() == 1) return source.ToArray()[0];

        throw new ArgumentNullException(nameof(source));
    }

    public static T MySingle<T>(this IEnumerable<T> source, Predicate<T> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        List<T> result = new List<T>();

        foreach (var item in source)
        {
            if (predicate(item))
            {
                result.Add(item);
            }
        }

        if (result.Count == 1) return result[0];

        throw new ArgumentNullException(nameof(source));
    }

    public static T? MySingleOrDefault<T>(this IEnumerable<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (source.Count() == 0) return default(T);

        if (source.Count() == 1) return source.ToArray()[0];

        throw new ArgumentNullException(nameof(source));
    }

    public static T? MySingleOrDefault<T>(this IEnumerable<T> source, Predicate<T> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        if (source.Count() == 0) return default(T);

        List<T> result = new List<T>();

        foreach (var item in source)
        {
            if (predicate(item))
            {
                result.Add(item);
            }
        }

        if (result.Count == 1) return result[0];

        throw new ArgumentNullException(nameof(source));
    }

    public static bool MyAny<T>(this IEnumerable<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (source.Count() > 0) return true;
        return false;
    }

    public static bool MyAny<T>(this IEnumerable<T> source, Predicate<T> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        foreach (var item in source)
        {
            if (predicate(item))
            {
                return true;
            }
        }
        return false;
    }

    public static bool MyAll<T>(this IEnumerable<T> source, Predicate<T> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        int count = 0;

        foreach (var item in source)
        {
            if (predicate(item))
            {
                count++;
            }
        }

        if (count == source.Count()) return true;
        return false;
    }
}
