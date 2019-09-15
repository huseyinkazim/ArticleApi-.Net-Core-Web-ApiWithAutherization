using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EntityLayer.Models.Base
{
    public abstract class CommentBase
    {
        public int Id { get; set; }
        public bool IsActive { set; get; }
        public DateTime CreatedOn { set; get; }
        public DateTime ModifiedOn { set; get; }

    }
}
