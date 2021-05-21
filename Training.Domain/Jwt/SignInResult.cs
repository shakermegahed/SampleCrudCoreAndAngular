using System;
using System.Collections.Generic;
using System.Text;

namespace Training.Domain.Jwt
{
    public class SignInResult
    {
        public string Token { get; set; }
        public bool Succeeded { get; set; }
        public bool IsLockedOut { get; set; }
        public bool IsDeleted { get; set; }
        public string Message { get; set; }
    }
}
