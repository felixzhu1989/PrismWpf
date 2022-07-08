using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace PrismWpf.WeMail.Common.ValidationRules
{
    public class MailRule:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var mail = value.ToString();
            if (string.IsNullOrWhiteSpace(mail)) return new ValidationResult(false, "EMail can not be empty!");
            mail=mail.Trim();
            string pattern = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
            bool isMatch = Regex.IsMatch(mail, pattern);
            string tips = isMatch ? "" : "Email format error!";
            return new ValidationResult(isMatch, tips);
        }
    }
}
