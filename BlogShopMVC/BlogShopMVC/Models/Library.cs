using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepBlog.Models
{
    public class Library
    {
        public ICollection<Article> ArticleUnImportant;
        public ICollection<Article> ArticleImportant;
    }
}