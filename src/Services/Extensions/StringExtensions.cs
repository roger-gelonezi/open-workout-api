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
