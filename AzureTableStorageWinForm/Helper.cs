using System.Collections.Generic;
using System.Linq;

namespace AzureTableStorageWinForm
{
    public static class Helper
    {

        public static List<T> QueuedAdd<T>(this List<T> list, T item, int maxItems)
        {
            list.Insert(0, item);

            if(list.Count > maxItems)
            {
                list.RemoveAt(list.Count - 1);
            }

            return list.Take(maxItems).ToList();
        }
    }
}
