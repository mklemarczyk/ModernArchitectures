using System;
using System.Collections.Generic;

namespace Bnsit.ArqLibrarianClassic.Library
{
    public static class Generated
    {
        private static readonly Dictionary<string, long> ids = new Dictionary<string, long>();
        
        public static long BookId()
        {
            return IdFor("book");
        }

        private static long IdFor(string name)
        {
            if (ids.ContainsKey(name))
            {
                var id = ids[name];
                ids[name] = Increment(id);
            }
            else
            {
                long id = 1;
                ids[name] = id;
            }

            return ids[name];
        }

        private static long Increment(long id)
        {
            return id + 1;
        }

        public static void ResetBookId()
        {
            ResetIdFor("book");
        }

        private static void ResetIdFor(string name)
        {
            ids[name] = 0;
        }
    }
}