using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steroids
{
    public static class Enum<T>
    {
        static Enum()
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException();
        }

        public static string GetName(int value)
        {
            return Enum.GetName(typeof(T), value);
        }

        public static string GetName(DayOfWeek value)
        {
            return Enum.GetName(typeof(T), value);
        }

        public static string[] GetNames()
        {
            return Enum.GetNames(typeof(T));
        }

        public static Type GetUnderlyingType()
        {
            return Enum.GetUnderlyingType(typeof(T));
        }

        public static IEnumerable<T> GetValues()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static bool IsDefined(string name)
        {
            return Enum.IsDefined(typeof(T), name);
        }

        public static bool IsDefined(T value)
        {
            return Enum.IsDefined(typeof(T), value);
        }

        public static T Parse(string name)
        {
            return (T)Enum.Parse(typeof(T), name);
        }

        public static T ParseIgnoreCase(string name)
        {
            return (T)Enum.Parse(typeof(T), name, true);
        }
    }
}
