using System.Globalization;
using System.Text.RegularExpressions;

namespace QuanLyTrungTam_API.Helper
{
    public class InputHelper
    {
        public static string NormalizeName(string fullName)
        {
            fullName = fullName.Trim();

            fullName = Regex.Replace(fullName, @"\p{P}", " ").Trim();
            fullName = Regex.Replace(fullName, @"\s+", " ");

            TextInfo textInfo = new CultureInfo("vi-VN", false).TextInfo;
            return textInfo.ToTitleCase(fullName.ToLower());
        }

        public static bool RegexPassword(string password)
        {
            string pattern = @"^(?=.*\d)(?=.*[\W_])[A-Za-z\d\W_]+$";

            return Regex.IsMatch(password, pattern);
        }
    }
}
