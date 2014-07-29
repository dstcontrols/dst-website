namespace dst_website.Models
{
    #region Namespace import directives

    using System;

    #endregion

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