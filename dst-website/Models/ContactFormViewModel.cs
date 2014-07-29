namespace dst_website.Models
{
    #region Namespace import directives

    using System.ComponentModel.DataAnnotations;
    using BetterCms.Module.Root.ViewModels.Cms;
    using dst_website.Infrastructure;

    #endregion

    public class ContactFormViewModel : RenderWidgetViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Email(ErrorMessage = "Invalid Email address")]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        public string EmailTo { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Email: {1}, Phone: {2}, Message: {3}", this.Name, this.Email, this.Message);
        }
    }
}