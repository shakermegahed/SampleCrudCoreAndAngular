using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using Training.Domain.Enums;
using Training.Domain.Jwt;
using Training.Domain.ViewModel;
using Training.Interface;

namespace Training.Implementation
{
    public class ValidateJwt :IJwt
    {
       
        public bool IsValid(string Token)
        {
            if (ValidateToken(Token) == null)
            {
                return false;
            }
            return true;
        }
       
        public ClaimsPrincipal ValidateToken(string Token)
        {
            var mySecret = Jwt.Key;
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

            var myIssuer = Jwt.Issuer;
            var myAudience = Jwt.Audience;

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(Token, new TokenValidationParameters
                {

                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = myIssuer,
                    ValidAudience = myAudience,
                    IssuerSigningKey = mySecurityKey,
                    RequireExpirationTime=true
                }, out validatedToken);

                DateTime ValidTo = validatedToken.ValidTo.ToLocalTime();

                if (ValidTo <= DateTime.Now)
                {
                    return null;
                }
                return principal as ClaimsPrincipal;
                //string Name = VV.Claims.FirstOrDefault(x => x.Properties.Any(z => z.Value == JwtRegisteredClaimNames.Sub)).Value;
                //return true;
            }
            catch
            {
                return null;
            }
        }
        public string GenerateToken(string Sub, string Role,string Name,string userEmail,string phone)
        {
            List<Claim> Claims = new List<Claim>();
            Claims.Add(new Claim(JwtRegisteredClaimNames.Sub, Sub));
            Claims.Add(new Claim(JwtRegisteredClaimNames.GivenName, Name));
            Claims.Add(new Claim(JwtRegisteredClaimNames.Email, userEmail));
            //Claims.Add(new Claim(JwtRegisteredClaimNames.FamilyName, phone));
            Claims.Add(new Claim(ClaimTypes.Role, Role));

            string ScKey = Jwt.Key;
            SymmetricSecurityKey SymKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ScKey));
            SigningCredentials SignCred = new SigningCredentials(SymKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken JwtToken = new JwtSecurityToken
                (
                    issuer: Jwt.Issuer,
                    audience: Jwt.Audience,
                    expires: DateTime.UtcNow.AddHours(Jwt.ExpiryTimeInHours),
                    signingCredentials: SignCred,
                    claims: Claims
                );
            string Token = new JwtSecurityTokenHandler().WriteToken(JwtToken);
            return Token;
        }
        public string GetUserIdFromToken()
        {
            var Res = ValidateToken(JwtToken.Token);
            if (Res == null)
            {
                return null;
            }
            return Res.Claims.FirstOrDefault(x => x.Properties.Any(z => z.Value == JwtRegisteredClaimNames.Sub)).Value;
        }
        public string GetUserIdFromToken(string Token)
        {
            var Res = ValidateToken(Token);
            if (Res == null)
            {
                return null;
            }
            return Res.Claims.FirstOrDefault(x => x.Properties.Any(z => z.Value == JwtRegisteredClaimNames.Sub)).Value;
        }
        public string GetGivenName()
        {
            try
            {
                var Res = ValidateToken(JwtToken.Token);
                return Res.Claims.FirstOrDefault(x => x.Properties.Any(z => z.Value == JwtRegisteredClaimNames.GivenName)).Value;
            }
            catch
            {
                return "";
            }
        }

        public Roles GetRole()
        {
            try
            {
                var Res = ValidateToken(JwtToken.Token);
                if (Res == null)
                {
                    return Domain.Enums.Roles.UnKown;
                }
                //var asd= Res.Claims.FirstOrDefault(x => x.Properties.Any(z => z.Value == ClaimTypes.Role)).Value;
                var Roles = Res.Claims.FirstOrDefault(x => x.Type==ClaimTypes.Role).Value.Replace(" ","");
                return (Domain.Enums.Roles)Enum.Parse(typeof(Domain.Enums.Roles),
                    Roles);
            }
            catch (Exception ex)
            {
                return Domain.Enums.Roles.UnKown;
            }
        }

        public string GetEmail()
        {
            try
            {
                var Res = ValidateToken(JwtToken.Token);
                return Res.Claims.FirstOrDefault(x => x.Properties.Any(z => z.Value == JwtRegisteredClaimNames.Email)).Value;
            }
            catch
            {
                return "";
            }
        }
        [Obsolete("No Phone Number In The Token",true)]
        public string GetPhoneNumber()
        {
            try
            {
                return "";
                //var Res = ValidateToken(JwtToken.Token);
                //return Res.Claims.FirstOrDefault(x => x.Properties.Any(z => z.Value == JwtRegisteredClaimNames.FamilyName)).Value;
            }
            catch
            {
                return "";
            }
        }
    }
}
