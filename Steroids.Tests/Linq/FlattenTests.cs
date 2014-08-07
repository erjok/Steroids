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
    }

    internal class Node : IEnumerable<Node>
    {
        internal int Id { get; set; }
        internal IEnumerable<Node> Children { get; set; }

        public IEnumerator<Node> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
