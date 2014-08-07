using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Steroids.Tests.Linq
{
    public class FlattenTests
    {
        [Fact]
        public void ShouldNotFlattenNullSequence()
        {
            IEnumerable<EnumerableNode> sequence = null;
            var exception = Assert.Throws<ArgumentNullException>(() => sequence.Flatten());
            exception.ParamName.ShouldBeEqual("source");
        }

        [Fact]
        public void ShouldFlattenHierarchicalEnumerable()
        {
            var sequence = new[] {
                new EnumerableNode(1, 
                    new EnumerableNode(2, 
                        new EnumerableNode(3))),
                new EnumerableNode(4, 
                    new EnumerableNode(5), 
                    new EnumerableNode(6))
            };

            sequence.Flatten().Select(n => n.Value).ShouldBeEqual(1, 2, 3, 4, 5, 6);
        }

        // Deferred
        // Streaming
    }

    internal class EnumerableNode : IEnumerable<EnumerableNode>
    {
        internal EnumerableNode(int value, params EnumerableNode[] children)
        {
            Value = value;
            Children = children;
        }

        internal int Value { get; set; }
        internal IEnumerable<EnumerableNode> Children { get; set; }

        public IEnumerator<EnumerableNode> GetEnumerator()
        {
            return Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
