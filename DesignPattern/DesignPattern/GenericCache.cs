using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _1_LauguageCharacter
{
    public class GenericCache<Tkey, TValue>
    {
        private Dictionary<Tkey, TValue> dictionary = new Dictionary<Tkey, TValue>();

        private ReaderWriterLock rwLock = new ReaderWriterLock();

        private readonly TimeSpan lockTimeOut = TimeSpan.FromMilliseconds(100);

        public void Add(Tkey key, TValue value)
        {
            bool isExisting = false;
            rwLock.AcquireWriterLock(lockTimeOut);
            try
            {
                if (!dictionary.ContainsKey(key))
                {
                    dictionary.Add(key, value);
                }
                else
                {
                    isExisting = true;
                }
            }
            finally
            {
                rwLock.ReleaseWriterLock();
            }
            if (isExisting)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public bool TryGetValue(Tkey key, out TValue value)
        {
            rwLock.AcquireReaderLock(lockTimeOut);
            bool result;
            try
            {
                result = dictionary.TryGetValue(key, out value);
            }
            finally
            {
                rwLock.ReleaseReaderLock();
            }
            return result;
        }

        public void Clear()
        {
            if (dictionary.Count > 0)
            {
                rwLock.AcquireWriterLock(lockTimeOut);
                try
                {
                    dictionary.Clear();
                }
                finally
                {
                    rwLock.ReleaseWriterLock();
                }
            }
        }

        public bool ContainsKey(Tkey key)
        {
            if (dictionary.Count <= 0) return false;

            bool result;
            rwLock.AcquireReaderLock(lockTimeOut);
            try
            {
                result = dictionary.ContainsKey(key);
            }
            finally
            {
                rwLock.ReleaseReaderLock();
            }
            return result;
        }

        public int Count
        {
            get
            {
                return dictionary.Count;
            }
        }
    }
}
