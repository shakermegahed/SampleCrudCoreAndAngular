using System;
using System.Collections.Generic;
using System.Text;

namespace Training.Domain.Jwt
{
    public class Jwt
    {
        public static string Key { get { return "JWTFORTHE#@!Au7u!&Toke()en)M!ZLKJ@_)(CLKNA_:LKJQWELMNL_:LJASD+@!ASC!@#@"; } }
        public static string Issuer { get { return "MainSignIn"; } }
        public static string Audience { get { return "Audeience"; } }
        public static long ExpiryTimeInHours {  get { return 24; } }
    }


}
