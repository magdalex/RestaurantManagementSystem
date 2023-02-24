using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSWPF.Models
{
    class AccountChecks

    {
   

        public Boolean IsLoggedIn(string IsLoggedIn)
        {
            
            if(Equals("login valid", IsLoggedIn.ToLower()))
            {
                return true;
            }
            else { return false; }
        }


    }
}
