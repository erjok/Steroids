using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Steroids.Tests
{
    public class EnumTests
    {
        [Fact]
        public void ShouldFindMemberByName()
        {
            Enum<DayOfWeek>.IsDefined("Friday").ShouldBeTrue();
        }

        [Fact]
        public void ShouldNotFindMemberByInvalidName()
        {
            Enum<DayOfWeek>.IsDefined("Beerday").ShouldBeFalse();
        }

        [Fact]
        public void ShouldFindMemberByValue()
        {
            Enum<DayOfWeek>.IsDefined(DayOfWeek.Monday).ShouldBeTrue();
        }

        [Fact]
        public void ShouldNotFindMemberByInvalidValue()
        {
            DayOfWeek value = (DayOfWeek)8;
            Enum<DayOfWeek>.IsDefined(value).ShouldBeFalse();
        }

        [Fact]
        public void ShoulGetAllValues()
        {
            Enum<DayOfWeek>.GetValues().ShouldBeEqual(
                DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday,
                DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday);
        }

        [Fact]
        public void ShouldParseValidName()
        {
            Enum<DayOfWeek>.Parse("Tuesday").ShouldBeEqual(DayOfWeek.Tuesday);
        }
    }
}
