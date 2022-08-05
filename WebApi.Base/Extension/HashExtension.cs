using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Base.Extension
{
    public static class HashExtension
    {
        public static bool CheckingPassword(this string storagePassword, string loginPassword)
        {
            try
            {
                if (string.Equals(storagePassword, loginPassword))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }



    }
}
