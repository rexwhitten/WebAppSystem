using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppSystem.Common
{
    public static class TypeExtensions
    {
        public static bool ImplementsInterface(this Type type, Type InterfaceType)
        {
            foreach (var interfaces in type.GetInterfaces())
            {
                if (interfaces == InterfaceType)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
