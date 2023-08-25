namespace YaChitay.Data.Repositories.QueryObjects
{
    public static class PageQuery
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageNumZeroStart, int pageSize)
        {
            if (pageSize == 0)
            {
                throw new ArgumentException("pageSize is 0");
            }

            int totalCount = query.Count();

            if (pageNumZeroStart != 0 && totalCount > pageNumZeroStart * pageSize)
            {
                query = query.Skip(pageNumZeroStart * pageSize);
            }

            return query.Take(pageSize);
        }
    }
}
