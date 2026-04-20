using System.ComponentModel.DataAnnotations;

namespace MVC_WebAppEF_ValidationAnnotations.Models
{
    public class LocalPhoneNumber : ValidationAttribute
    {
        string[] locals = { "011", "012", "015", "010" };
        public LocalPhoneNumber() { }

        public override bool IsValid(object obj)
        {
            ErrorMessage = "Phone number is required.";
            if (obj == null)
                return false;
            string PhoneNum = obj.ToString();
            ErrorMessage = "Phone number cannot be empty or whitespace.";
            if (string.IsNullOrWhiteSpace(PhoneNum))
                return false;
            ErrorMessage = $"Phone number must start with one of the following: {string.Join(", ", locals)}";
            return locals.Any(loc => PhoneNum.StartsWith(loc));
        }
    }
}