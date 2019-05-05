using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepBlog.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleShortcut { get; set; }
        public string ArticleContent { get; set; }
        public string NameOfImageArticle { get; set; }
        public bool ArticleImportant { get; set; }


    }
}