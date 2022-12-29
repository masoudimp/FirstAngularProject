using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public static class RandomOrder
    {
        public static ICollection<T> RandomListOrders<T>(this IEnumerable<T> list)
        {
            Random random = new Random();
            var result = list.OrderBy(l => random.Next());
            return result.ToList();
        }
    }
}
