using System;
using System.Collections.Generic;
using System.Text;

namespace _1_LauguageCharacter
{
    public class RawIterator
    {
        private int[] data = new int[] { 0, 1, 2, 3, 4, 5 };

        public IEnumerator<int> GetEnumerator()
        {
            foreach (int item in data)
                yield return item;
        }

        public IEnumerable<int> GetRange(int start, int end)
        {
            for (int i = start; i <= end; i++)
                yield return data[i];
        }

        public IEnumerable<string> Greeting
        {
            get
            {
                yield return "hello";
                yield return "world";
                yield return "!";
            }
        }


    }
}
