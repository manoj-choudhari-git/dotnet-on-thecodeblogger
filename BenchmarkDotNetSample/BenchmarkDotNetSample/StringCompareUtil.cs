using BenchmarkDotNet.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkDotNetSample
{
    public class StringCompareUtil
    {
        [ParamsSource(nameof(ValuesForFirst))]
        public string First { get; set; }

        [ParamsSource(nameof(ValuesForSecond))]
        public string Second { get; set; }

        // public methods
        public IEnumerable<string> ValuesForFirst => new string[] { "some-random-string", "another-string" };
        public IEnumerable<string> ValuesForSecond => new string[] { "some-random-string", "non-matching" };

        [Benchmark]
        public bool EqualUsingCompare()
        {
            if (First == null || Second == null)
            {
                return false;
            }

            return string.Compare(First, Second, StringComparison.OrdinalIgnoreCase) == 0;
        }

        [Benchmark]
        public bool EqualUsingOperator()
        {
            if (First == null || Second == null)
            {
                return false;
            }
            return First == Second;
        }

        [Benchmark]
        public bool EqualUsingEquals()
        {
            if (First == null || Second == null)
            {
                return false;
            }
            return First.Equals(Second);
        }
    }
}
