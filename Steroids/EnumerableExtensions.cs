using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steroids
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int size)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (size <= 0)
                throw new ArgumentOutOfRangeException("size");

            return BatchIterator(source, size);
        }

        private static IEnumerable<IEnumerable<T>> BatchIterator<T>(this IEnumerable<T> source, int size)
        {
            var batch = new List<T>(size);

            foreach (var item in source)
            {
                if (batch.Count == size)
                {
                    yield return batch;
                    batch = new List<T>(size);
                }

                batch.Add(item);
            }

            if (batch.Any())
                yield return batch;
        }
    }
}
