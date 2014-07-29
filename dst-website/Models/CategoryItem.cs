namespace dst_website.Models
{
    using System;

    public class CategoryItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Id: {1}", this.Name, this.Id);
        }
    }
}