using System;
using System.Collections.Generic;
using System.Text;

namespace Training.DTO
{
    public class ExceptionMessageResponse
    {
        public string Message { set; get; }
        public string ExceptionMessage { set; get; }
        public string ExceptionHead { get; set; }
        public string Source { get; set; }
        public string ClientIpaddress { get; set; }
        public string LoginedUserId { get; set; }
    }

}
