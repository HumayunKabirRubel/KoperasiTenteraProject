
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KoperasiTentera.Services
{
    public class KTOtp
    {
        public static string GetOtpCode(string secret)
        {
            //Otp Code generate
            return "1234";
        }

        public static bool IsValid(string secret, string code)
        {
            //Otp Code match here
            return true;
        }
    }
}
