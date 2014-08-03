﻿using System;
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
            Assert.Equal(batches.Length, 3);
            Assert.Equal(new[] { 1, 2, 3 }, batches[0]);
            Assert.Equal(new[] { 4, 5, 6 }, batches[1]);
            Assert.Equal(new[] { 7, 8, 9 }, batches[2]);
        }
    }
}
