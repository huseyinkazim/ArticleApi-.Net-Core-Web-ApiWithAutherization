using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Service
{
    public static class Extension
    {
        public static Dictionary<string, string> GetParameters<T>(this T model)
        {
            var typeofT = typeof(T);
            var result = new Dictionary<string, string>();
            foreach (var item in typeofT.GetProperties())
            {
                var value = typeofT.GetProperty(item.Name).GetValue(model);
                if (value != null)
                {
                    result.Add(item.Name, value.ToString());
                }
            }
            return result;
        }
    }
}
