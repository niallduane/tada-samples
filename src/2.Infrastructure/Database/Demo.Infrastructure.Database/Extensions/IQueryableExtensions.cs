using Demo.Domain.Core;

using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Database.Extensions;
public static class IQueryableExtensions
{
    public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PagedList<T>(items, count, pageNumber, pageSize);
    }

    public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, BaseListRequest query)
    {
        var count = source.Count();
        var items = await source.Skip((query.Page - 1) * query.Limit).Take(query.Limit).ToListAsync();

        return new PagedList<T>(items, count, query.Page, query.Limit);
    }
}