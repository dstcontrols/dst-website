namespace dst_website.Models
{
    #region Namespace import directives

    using System;
    using System.Collections.Generic;

    #endregion

    public class BlogItem
    {
        public string Title { get; set; }

        public string IntroText { get; set; }

        public DateTime PublishedOn { get; set; }

        public string Url { get; set; }

        public string Author { get; set; }

        public string ImageUrl { get; set; }

        public List<string> Tags { get; set; }

        public override string ToString()
        {
            return string.Format(
                                 "Title: {0}, IntroText: {1}, PublishedOn: {2}, Url: {3}, Author: {4}, ImageUrl: {5}",
                                 this.Title, this.IntroText, this.PublishedOn, this.Url, this.Author, this.ImageUrl);
        }
    }
}