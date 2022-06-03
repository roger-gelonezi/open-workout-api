using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extensions
{
    internal static class StringExtensions
    {
        internal static string SnakeCaseToCamelCase(this string snakeCase)
        {
            return snakeCase.Replace('_', ' ');
        }
    }
}
