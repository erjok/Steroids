using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Steroids.Tests
{
    public static class AssertionExtensions
    {
        public static void ShouldBeEqual<T>(this T actual, T expected)
        {
            Assert.Equal(expected, actual);
        }

        public static void ShouldBeEqual<T>(this IEnumerable<T> actual, params T[] expected)
        {
            Assert.Equal(expected, actual.ToArray());
        }

        public static void ShouldBeTrue(this bool actual)
        {
            Assert.True(actual);
        }

        public static void ShouldBeFalse(this bool actual)
        {
            Assert.False(actual);
        }
    }
}
