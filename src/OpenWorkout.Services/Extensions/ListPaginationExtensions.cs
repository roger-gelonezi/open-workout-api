using System.Linq.Dynamic.Core;
using OpenWorkout.Services.Abstractions.Dto;
using RogerioGelonezi.Entity.Sdk;

namespace OpenWorkout.Services.Extensions
{
    internal static class ListPaginationExtensions
    {
        internal static IQueryable<T> SetQueryParams<T>(this IQueryable<T> query, ListParamsDto listParamsDto) where T : EntityBase
        {
            return query.SetLastUpdateFilter(listParamsDto?.LastUpdateSince)
                        .SetOrderBy(listParamsDto?.OrderBy ?? "")
                        .SetPagination(listParamsDto?.PageSize, listParamsDto?.Page);
        }

        internal static IQueryable<T> SetLastUpdateFilter<T>(this IQueryable<T> query, DateTime? lastUpdateSince) where T : EntityBase
        {
            if (lastUpdateSince != null)
                return query.Where(e => e.LastUpdate >= lastUpdateSince);

            return query;
        }

        private static IQueryable<T> SetOrderBy<T>(this IQueryable<T> query, string orderBy) where T : EntityBase
        {
            if (!string.IsNullOrEmpty(orderBy))
                return query.OrderBy(orderBy.SnakeCaseToCamelCase());

            return query;
        }

        private static IQueryable<T> SetPagination<T>(this IQueryable<T> query, int? pageSize, int? page) where T : EntityBase
        {
            if (pageSize != null && page != null)
                return query.Skip((int)(pageSize * (page - 1)))
                            .Take((int)pageSize);

            return query;
        }
    }
}
