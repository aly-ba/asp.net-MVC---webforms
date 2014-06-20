using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Binder
{
    public static class IValueProviderExtensions
    {
        public static T GetValue<T>(this IValueProvider provider, string key)
        {
            return (T)provider.GetValue(key).ConvertTo(typeof(T));
        }
    }
}