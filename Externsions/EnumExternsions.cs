using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OrderingSystem.Externsions
{
    public static class EnumExternsions
    {
            public static string GetDisplayName(this Enum enumValue)
            {
                return enumValue.GetType()
                    .GetMember(enumValue.ToString())
                    .First()
                    .GetCustomAttribute<DisplayAttribute>()?
                    .Name ?? enumValue.ToString();
            }
    }
}
