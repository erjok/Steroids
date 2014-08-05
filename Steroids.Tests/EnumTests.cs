using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Steroids.Tests
{
    public class EnumTests
    {
        [Fact]
        public void ShouldNotInitializeTypeWithInvalidGenericParameter()
        {
            Assert.Throws<TypeInitializationException>(() => Enum<int>.GetName(1));
        }

        [Fact]
        public void ShouldGetMemberNameByIntegerValue()
        {
            Enum<DayOfWeek>.GetName(5).ShouldBeEqual("Friday");
        }

        [Fact]
        public void ShouldGetMemberNameByEnumValue()
        {
            Enum<DayOfWeek>.GetName(DayOfWeek.Monday).ShouldBeEqual("Monday");
        }

        [Fact]
        public void ShouldNotGetMemberNameByInvalidValue()
        {
            Enum<DayOfWeek>.GetName(8).ShouldBeNull();
        }

        [Fact]
        public void ShouldGetAllMemberNames()
        {
            Enum<DayOfWeek>.GetNames().ShouldBeEqual("Sunday", "Monday", "Tuesday",
                "Wednesday", "Thursday", "Friday", "Saturday");
        }

        [Fact]
        public void ShouldGetUnderlyingTypeOfEnum()
        {
            Enum<DayOfWeek>.GetUnderlyingType().ShouldBeEqual(typeof(int));
        }

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

        [Fact]
        public void ShouldNotParseInvalidName()
        {
            Assert.Throws<ArgumentException>(() => Enum<DayOfWeek>.Parse("Beerday"));
        }
    }
}
