using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blog.Data.EF;

using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Contracts.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> query, IBaseSpecifications<TEntity> specifications)
        {
            // Do not apply anything if specifications is null
            if (specifications == null)
            {
                return query;
            }

            // Modify the IQueryable
            // Apply filter conditions
            if (specifications.FilterCondition != null)
            {
                query = query.Where(specifications.FilterCondition);
            }

            // Includes
            query = specifications.Includes
                        .Aggregate(query, (current, include) => current.Include(include));

            // Apply ordering
            if (specifications.OrderBy != null)
            {
                query = query.OrderBy(specifications.OrderBy);
            }
            else if (specifications.OrderByDescending != null)
            {
                query = query.OrderByDescending(specifications.OrderByDescending);
            }

            // Apply GroupBy
            if (specifications.GroupBy != null)
            {
                query = query.GroupBy(specifications.GroupBy).SelectMany(x => x);
            }

            return query;
        }
    }
}
