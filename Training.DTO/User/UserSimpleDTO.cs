using System;
using System.Collections.Generic;
using System.Text;

namespace Training.DTO.User
{
    public class UserSimpleDTO
    {
        public string Token { set; get; }
        public string Name { set; get; }
        public string DBUserId { set; get; }
        public string UserName { get; set; }

    }
}
