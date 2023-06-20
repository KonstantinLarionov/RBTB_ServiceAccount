using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTB_ServiceAccount.Client.Extensions
{
    public static class ListExtensions
    {
        public static void AddObjectIfNotNull<T>(this List<T> list, T obj)
        {
            if (obj == null) return;
            list.Add(obj);
        }
    }
}
