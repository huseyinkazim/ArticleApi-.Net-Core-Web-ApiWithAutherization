using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DtoLayer.Dto
{
    public class UserDto
    {
        public virtual string Email { get; set; }

        public virtual string NormalizedUserName { get; set; }

        public virtual string UserName { get; set; }
    }
}
