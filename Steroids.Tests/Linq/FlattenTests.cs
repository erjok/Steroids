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
            IEnumerable<Node> sequence = null;
            var exception = Assert.Throws<ArgumentNullException>(() => sequence.Flatten());
            exception.ParamName.ShouldBeEqual("source");
        }

        [Fact]
        public void ShouldFlattenHierarchicalEnumerable()
        {
            var sequence = new[] {
                new Node(1) { Children = new [] { new Node(2) }},
                new Node(3) { Children = new [] { new Node(4), new Node(5) }}
            };

            sequence.Flatten().Select(n => n.Value).ShouldBeEqual(1, 2, 3, 4, 5);
        }
    }

    internal class Node : IEnumerable<Node>
    {
        internal Node(int value)
        {
            Value = value;
            Children = Enumerable.Empty<Node>();
        }

        internal int Value { get; set; }
        internal IEnumerable<Node> Children { get; set; }

        public IEnumerator<Node> GetEnumerator()
        {
            return Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
