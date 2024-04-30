using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;

namespace IntelligentDiagnostician.DAL.Helpers;

public class SortHelper<T> : ISortHelper<T>
{
    public IQueryable<T> ApplySort(IQueryable<T> collection, string orderByQueryString)
    {
        if (!collection.Any())
            return collection;

        if (string.IsNullOrWhiteSpace(orderByQueryString))
        {
            return collection;
        }

        var orderParams = orderByQueryString.Trim().Split(',');
        var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var orderQueryBuilder = new StringBuilder();

        foreach (var param in orderParams)
        {
            if (string.IsNullOrWhiteSpace(param))
                continue;

            var propertyFromQueryName = param.Split(" ")[0];
            var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

            if (objectProperty == null)
                continue;

            var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";

            orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}, ");
        }

        var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
        return string.IsNullOrWhiteSpace(orderQuery) ? collection : collection.OrderBy(orderQuery);
    }
}
