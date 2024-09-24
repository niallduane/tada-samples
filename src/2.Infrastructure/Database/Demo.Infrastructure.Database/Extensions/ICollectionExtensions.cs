using Demo.Domain.Core;

namespace Demo.Infrastructure.Database.Extensions;

public static class ICollectionExtensions
{
    public static PagedList<T> ToPagedList<T>(this ICollection<T> source, BaseListRequest query)
    {
        var count = source.Count;
        var items = source.Skip((query.Page - 1) * query.Limit).Take(query.Limit).ToList();

        return new PagedList<T>(items, count, query.Page, query.Limit);
    }
}