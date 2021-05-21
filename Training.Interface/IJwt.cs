using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Training.Domain.Enums;

namespace Training.Interface
{
    public interface IJwt 
    {
        bool IsValid(string Token);
        ClaimsPrincipal ValidateToken(string Token);
        string GenerateToken(string Sub, string Role,string Name, string userEmail, string phone);
        string GetGivenName();
        string GetEmail();
        string GetPhoneNumber();
        string GetUserIdFromToken();
        Roles GetRole();
    }
}
