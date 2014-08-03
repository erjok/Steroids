using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Steroids;

namespace Steroids.Tests.Linq
{
    public class BatchTests
    {
        [Fact]
        public void ShouldNotBatchNullSequence()
        {
            IEnumerable<object> sequence = null;
            var exception = Assert.Throws<ArgumentNullException>(() => sequence.Batch(3));
            Assert.Equal("source", exception.ParamName);
        }

        [Fact]
        public void ShouldNotCreateZeroSizedBatches()
        {
            IEnumerable<int> sequence = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => sequence.Batch(0));
            Assert.Equal("size", exception.ParamName);
        }

        [Fact]
        public void ShouldNotCreateBatchesOfNegativeSize()
        {
            IEnumerable<int> sequence = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => sequence.Batch(-1));
            Assert.Equal("size", exception.ParamName);
        }

        [Fact]
        public void ShouldCreateCompletelyFilledBatches()
        {
            IEnumerable<int> sequence = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var batches = sequence.Batch(3).ToArray();
            Assert.Equal(3, batches.Length);
            batches[0].ShouldBeEqual(1, 2, 3);
            batches[1].ShouldBeEqual(4, 5, 6);
            batches[2].ShouldBeEqual(7, 8, 9);
        }
        
        [Fact]
        public void ShouldCreatePartiallyFilledBatch()
        {
            IEnumerable<int> sequence = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var batches = sequence.Batch(5).ToArray();
            Assert.Equal(2, batches.Length);
            batches[0].ShouldBeEqual(1, 2, 3, 4, 5);
            batches[1].ShouldBeEqual(6, 7, 8, 9);
        }

        [Fact]
        public void ShouldUseDeferredExecution()
        {
            var sequence = new BrokenEnumerable<int>();
            var batches = sequence.Batch(3);
            // No exception
        }
    }
}
