namespace Sourcefier.Extensions;

public static class IEnumerable
{
    public static IEnumerable<T> RemoveAt<T>(this IEnumerable<T> source, int index)
        => source.Where((item, idx) => idx != index);
}
