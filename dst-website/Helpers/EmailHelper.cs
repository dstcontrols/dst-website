namespace dst_website.Helpers
{
    using System.Text;
    using dst_website.Models;

    public static class EmailHelper
    {
        public static string FormatMessage(ContactFormViewModel contactForm)
        {
            var builder = new StringBuilder();
            builder.AppendFormat("<div>From: {0}</div>", contactForm.Name);
            builder.AppendFormat("<div>Email: {0}</div>", contactForm.Email);

            if (!string.IsNullOrWhiteSpace(contactForm.Message))
            {
                builder.AppendFormat("<div><br/>{0}</div>", contactForm.Message);
            }

            return builder.ToString();
        }
    }
}