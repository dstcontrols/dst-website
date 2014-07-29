namespace dst_website.Models
{
    public class MenuItemViewModel
    {
        public string Caption { get; set; }

        public string Url { get; set; }

        public override string ToString()
        {
            return string.Format("Caption: {0}, Url: {1}", this.Caption, this.Url);
        }
    }
}