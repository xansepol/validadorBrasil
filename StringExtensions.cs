using System.Text.RegularExpressions;
namespace validadorBrasil
{
    public static class StringExtensions
    {
        public static bool IsPlaca(this string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return false;

            return Regex.IsMatch(placa, Keys.REGEX_PLACA, RegexOptions.IgnoreCase);
        }
    }
}