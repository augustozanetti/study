using System;

namespace Hyper.Web.ExtensionMethod
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty(this String str)
        {
            return String.IsNullOrEmpty(str);
        }
    }   
}