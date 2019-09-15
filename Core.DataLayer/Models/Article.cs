using Core.EntityLayer.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EntityLayer.Models
{
    public class Article : ArticleBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual ICollection<Comment> comments { set; get; }
    }
}
