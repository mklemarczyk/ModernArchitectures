using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ArqLibrarianClassic;
using NUnit.Framework;

namespace ArcLibrarianClassis.ATests
{
    public class SpyUserOut : UserOut, InputAware
    {
        private readonly List<string> history = new List<string>();

        public SpyUserOut()
        {
            history.Add("");
        }

        public void Print(string text)
        {
            int lastElement = history.Count - 1;
            history[lastElement] = history[lastElement] + text;
        }

        public void PrintLine(string text)
        {
            Print(text);
            history.Add("");
        }

        internal void AssertContains(string expression)
        {
            if (history.Count == 0) 
            {
                Assert.Fail("No entries containing: " + expression);
            }

            Assert.IsTrue(history.FindAll(x => Regex.IsMatch(x, expression)).Count > 0,
                $"{Environment.NewLine}" +
                $"UI does not contain '{expression}'.{Environment.NewLine}" +
                $"{this.FormatHistory()}");
        }

        private string FormatHistory()
        {
            return $"History:{Environment.NewLine}" +
                   $"========={Environment.NewLine}" +
                   $"{string.Join($"{Environment.NewLine}", history)}";
        }

        public void AssertCountainsAtLeastLines(int expectedCount)
        {
            Assert.GreaterOrEqual(history.Count, expectedCount, 
                $"{Environment.NewLine}" +
                $"UI contains less than {expectedCount} lines{Environment.NewLine}" +
                $"{this.FormatHistory()}");
        }

        public void OnTextLineEntered(string text)
        {
            PrintLine(text);
        }
    }
}
