using System;
using System.Collections.Generic;

namespace Core.ServiceLayer.Core
{
    public class Converter
    {
        public static L MapTo<T, L>(T from)
        {
            var fromType = typeof(T);
            var toType = typeof(L);
            var model = (L)Activator.CreateInstance(toType);
            foreach (var item in fromType.GetProperties())
            {
                var info = toType.GetProperty(item.Name);
                if (info != null)
                {
                    info.SetValue(model, item.GetValue(from));
                }
            }
            return model;

        }
        public static List<L> MapToList<T, L>(IEnumerable<T> from)
        {
            var toType = typeof(List<L>);
            var model = (List<L>)Activator.CreateInstance(toType);

            foreach (var item in from)
            {
                model.Add(MapTo<T, L>(item));
            }

            return model;

        }

    }
}
