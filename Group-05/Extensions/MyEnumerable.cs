namespace Extensions;

public static class MyEnumerable
{
    //todo: remove enumerable word from parameter names.

    public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
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

    public static IEnumerable<T> MyUnion<T>(this IEnumerable<T> source1, IEnumerable<T> source2)
    {
        if (source1 == null) throw new ArgumentNullException(nameof(source1));
        if (source2 == null) throw new ArgumentNullException(nameof(source2));

        HashSet<T> result = new();

        foreach (var item in source1)
        {
            result.Add(item);
        }

        foreach (var item in source2)
        {
            result.Add(item);
        }

        return result;
    }

    public static IEnumerable<T> MyConcat<T>(this IEnumerable<T> source1, IEnumerable<T> source2)
    {
        if (source1 == null) throw new ArgumentNullException(nameof(source1));
        if (source2 == null) throw new ArgumentNullException(nameof(source2));

        foreach (var item in source1)
        {
            yield return item;
        }

        foreach (var item in source2)
        {
            yield return item;
        }
    }

    public static IEnumerable<T> MyExcept<T>(this IEnumerable<T> source1, IEnumerable<T> source2)
    {
        if (source1 == null) throw new ArgumentNullException(nameof(source1));
        if (source2 == null) throw new ArgumentNullException(nameof(source2));

        source1 = source1.MyDistinct();
        source2 = source2.MyDistinct();

        foreach (var item in source1)
        {
            if (!source2.Contains(item))
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<T> MyIntersect<T>(this IEnumerable<T> source1, IEnumerable<T> source2)
    {
        if (source1 == null) throw new ArgumentNullException(nameof(source1));
        if (source2 == null) throw new ArgumentNullException(nameof(source2));

        source1 = source1.MyDistinct();
        source2 = source2.MyDistinct();

        foreach (var item in source1)
        {
            if (source2.Contains(item))
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<T> MyDistinct<T>(this IEnumerable<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        HashSet<T> result = new();

        foreach (var item in source)
        {
            result.Add(item);
        }

        return result;
    }

    //todo: Think about same approach for other methods too.
    public static T MyFirst<T>(this IEnumerable<T> source) =>
        source.MyFirst(_ => true);

    public static T MyFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate)
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

        throw new InvalidOperationException(nameof(source));
    }

    public static T? MyFirstOrDefault<T>(this IEnumerable<T> source) =>
        source.MyFirstOrDefault(_ => true);

    public static T? MyFirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
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

        return default;
    }

    public static T MyLast<T>(this IEnumerable<T> source) =>
        source.MyLast(_ => true);

    public static T MyLast<T>(this IEnumerable<T> source, Func<T, bool> predicate)
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

        throw new InvalidOperationException(nameof(source));
    }

    public static T? MyLastOrDefault<T>(this IEnumerable<T> source) =>
        source.MyLastOrDefault(_ => true);

    public static T? MyLastOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
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

    public static T MySingle<T>(this IEnumerable<T> source) =>
        source.MySingle(_ => true);

    public static T MySingle<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        T? result = default;
        int count = 0;

        foreach (var item in source)
        {
            if (predicate(item))
            {
                count++;
                result = item;
            }
        }

        if (count == 1) return result;

        throw new InvalidOperationException(nameof(source));
    }

    public static T? MySingleOrDefault<T>(this IEnumerable<T> source) =>
       source.MySingleOrDefault(_ => true);

    public static T? MySingleOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        T? result = default;
        int count = 0;

        foreach (var item in source)
        {
            if (predicate(item))
            {
                count++;
                result = item;
            }
        }

        if (count == 1) return result;

        return default;
    }

    public static bool MyAny<T>(this IEnumerable<T> source) =>
        source.MyAny(_ => true);

    public static bool MyAny<T>(this IEnumerable<T> source, Func<T, bool> predicate)
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

    public static bool MyAll<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));

        foreach (var item in source)
        {
            if (!predicate(item))
            {
                return false;
            }
        }

        return true;
    }

    public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selectExecuter)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selectExecuter == null) throw new ArgumentNullException(nameof(selectExecuter));

        foreach (TSource item in source)
        {
            yield return selectExecuter(item);
        }
    }
}
