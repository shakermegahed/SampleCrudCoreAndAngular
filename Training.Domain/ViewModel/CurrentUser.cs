using System;
using System.Collections.Generic;
using System.Text;

namespace Training.Domain.ViewModel
{
    public static class CurrentUser
    {
        public static string User { get; set; }
        public static Training.Domain.Enums.Roles? Role { get; set; }
    }
}
