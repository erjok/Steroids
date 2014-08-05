using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steroids
{
    public static class Enum<TEnum>
        where TEnum : struct
    {
        static Enum()
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException();
        }

        public static string GetName(int value)
        {
            return Enum.GetName(typeof(TEnum), value);
        }

        public static string GetName(DayOfWeek value)
        {
            return Enum.GetName(typeof(TEnum), value);
        }

        public static string[] GetNames()
        {
            return Enum.GetNames(typeof(TEnum));
        }

        public static Type GetUnderlyingType()
        {
            return Enum.GetUnderlyingType(typeof(TEnum));
        }

        public static IEnumerable<TEnum> GetValues()
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        }

        public static bool IsDefined(string name)
        {
            return Enum.IsDefined(typeof(TEnum), name);
        }

        public static bool IsDefined(TEnum value)
        {
            return Enum.IsDefined(typeof(TEnum), value);
        }

        public static TEnum Parse(string name)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), name);
        }

        public static TEnum ParseIgnoreCase(string name)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), name, true);
        }

        public static bool TryParse(string value, out TEnum result)
        {
            return Enum.TryParse<TEnum>(value, out result);
        }

        public static bool TryParseIgnoreCase(string value, out TEnum result)
        {
            return Enum.TryParse<TEnum>(value, true, out result);
        }
    }
}
