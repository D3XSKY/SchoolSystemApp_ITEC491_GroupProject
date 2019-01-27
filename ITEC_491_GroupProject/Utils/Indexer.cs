using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ITEC_491_GroupProject.Utils
{
    //https://stackoverflow.com/questions/9262221/c-sharp-class-auto-increment-id
    public class Indexer : IDisposable
    {
        static private int nextId;
        static private ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
        static private SortedSet<int> reuseIds = new SortedSet<int>();
        public int id { get; private set; }
        public Indexer()
        {
            rwLock.EnterReadLock();
            try
            {
                if (reuseIds.Count == 0)
                {
                    id = Interlocked.Increment(ref nextId);
                    return;
                }
            }
            finally
            {
                rwLock.ExitReadLock();
            }
            rwLock.EnterWriteLock();
            try
            {
                // Check the count again, because we've released and re-obtained the lock
                if (reuseIds.Count != 0)
                {
                    id = reuseIds.Min();
                    reuseIds.Remove(id);
                    return;
                }
                id = Interlocked.Increment(ref nextId);
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }
        public void Dispose()
        {
            rwLock.EnterWriteLock();
            reuseIds.Add(id);
            rwLock.ExitWriteLock();
        }

    }
}