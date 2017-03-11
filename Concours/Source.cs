using System;
using System.Collections;
using System.Linq;

public static class ListUtils
{
    public static void ReverseInPlace(IList values)
    {
        if (values == null) throw new ArgumentNullException(nameof(values));

        var count = values.Count;
        for (int i = 0, j = count - 1; i < count / 2; ++i, j--)
        {
            var tmp = values[i];
            values[i] = values[j];
            values[j] = tmp;
        }
    }
    public static void EmptyAndDispose(IList values)
    {
        if (values == null) throw new ArgumentNullException(nameof(values));

        var valuesToDispose = values.OfType<IDisposable>();        
        DisposeAll(valuesToDispose);
        values.Clear();
    }

    public static void DisposeAll(IEnumerable values)
    {
        if (values == null) throw new ArgumentNullException(nameof(values));

        foreach (IDisposable disposable in values)
        {
            using (disposable)
            {
                //disposable.Dispose();
            }
        }
    }
}