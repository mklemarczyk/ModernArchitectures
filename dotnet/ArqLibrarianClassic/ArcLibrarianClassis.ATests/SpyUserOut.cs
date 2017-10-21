using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ArqLibrarianClassic.ATests
{
    public class SpyUserOut : UserOut
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

        internal void AssertContains(string text)
        {
            if (history.Count == 0) 
            {
                Assert.Fail("No entries containing: " + text);
            }

            Assert.IsTrue(history.FindAll(x => x.Contains(text)).Count > 0,
                $"{Environment.NewLine}" +
                $"UI does not contain '{text}'.{Environment.NewLine}" +
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
    }
}
