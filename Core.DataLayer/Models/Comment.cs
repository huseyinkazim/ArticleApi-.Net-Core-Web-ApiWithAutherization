using Core.EntityLayer.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.EntityLayer.Models
{
    public class Comment : CommentBase
    {
        public string Title { set; get; }
        public string Content { get; set; }
        public int ArticleId { get; set; }
        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }
    }
}
