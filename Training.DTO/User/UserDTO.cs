using System;
using System.Collections.Generic;
using System.Text;

namespace Training.DTO.User
{
    public class UserDTO
    {
        public string Token { set; get; }
        public string Name { set; get; }
        public string DBUserId { set; get; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public List<string> UserRoles { get; set; }
        public string UserRolesName { get; set; }
        public bool Succeeded { get; set; }
    }
}
