using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kt.Net
{
    public static class Kt
    {
        // https://kotlinlang.org/api/latest/jvm/stdlib/kotlin/index.html#functions


        public static void TODO()
        {
            TODO<bool>(null);
        }

        public static void TODO(string message)
        {
            TODO<bool>(message);
        }

        public static T TODO<T>()
        {
            return TODO<T>(null);
        }

        public static T TODO<T>(string message)
        {
            throw new NotImplementedException(message);
            return default(T);
        }

        public static T Also<T>(this T obj, Action<T> code)
        {
            code(obj);
            return obj;
        }

        // Due to C#'s constraints `Apply` is impossible to implement

        public static T[] ArrayOf<T>(params T[] items) => items;

        public static T[] ArrayOfNulls<T>(int size) => new T[size];

        public static void Assert(bool boolean, Func<object> lazyMessage)
        {
            if (!boolean) throw new Exception("Assertion failed: " + lazyMessage());
        }

        public static void Assert(bool boolean) => Assert(boolean, () => "");

        public static T CheckNotNull<T>(T? value, Func<object> lazyMessage) where T: struct
        {
            if (value == null) throw new Exception("Valuecannot be null");
            return value.Value;
        }

        public static T CheckNotNull<T>(T? value) where T : struct => CheckNotNull(value, () => "");

        public static T[] EmptyArray<T>() => new T[0];

        public static T EnumValueOf<T>(string name)
        {
            var type = typeof(T);
            Assert(type.IsEnum, () => "`T` is not an enum type");
            return (T) Enum.Parse(type, name);
        }

        public static T[] EnumValues<T>()
        {
            var type = typeof(T);
            Assert(type.IsEnum, () => "`T` is not an enum type");
            var oldSchoolArray = Enum.GetValues(type);
            var result = new T[oldSchoolArray.Length];
            for (int i = 0; i < oldSchoolArray.Length; i++)
            {
                result[i] = (T) oldSchoolArray.GetValue(i);
            }

            return result;
        }

        public static Lazy<T> Lazy<T>(Func<T> initializer)
        {
            return new Lazy<T>(initializer);
        }

        public static Lazy<T> LazyOf<T>(T value) => Lazy(() => value);

        public static T Let<T>(this object obj, Func<T> code) where T: class
        {
            if (obj == null) return null;
            return code();
        }

        public static void Repeat(int times, Action<int> code)
        {
            Enumerable.Range(0, times).ToList().ForEach(code);
        }

        public static T Run<T>(Func<T> code) => code();

        public static T TakeIf<T>(this T value, Func<T, bool> predicate) where T: class => predicate(value)? value : null;

        public static T TakeUnless<T>(this T value, Func<T, bool> predicate) where T : class => TakeIf(value, it => !predicate(it));

        public static Tuple<T1, T2> To<T1, T2>(this T1 any1, T2 any2) => Tuple.Create(any1, any2);

        public static List<T> ToList<T>(Tuple<T, T> tuple)
        {
            return new List<T> { tuple.Item1, tuple.Item2 };
        }

        public static List<T> ToList<T>(Tuple<T, T, T> tuple)
        {
            return new List<T> { tuple.Item1, tuple.Item2, tuple.Item3 };
        }

        public static T With<T,R>(R obj, Func<R, T> code) => code(obj);

    }
}
