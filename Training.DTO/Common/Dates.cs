using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Training.DTO.Common
{
    public class Dates
    {
        public static DateTime? ConvertDate(string Date,bool ThrowError=false)
        {
            try
            {
                return DateTime.ParseExact(Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            catch
            {
                if (ThrowError)
                {
                    throw;
                }
                return null;
            }

        }
    }
}
