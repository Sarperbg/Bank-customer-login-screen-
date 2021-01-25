using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankacilikUygulamasi
{
    public class Login
    {
        internal virtual bool loginControl(Banka bank, int id, string pass)
        {

            bool flag = false;
            for (int i = 0; i < bank.MusteriList.Count; i++)
            {
                if (bank.MusteriList[i].HesapNo == id)
                {
                    if (bank.MusteriList[i].Parola.Equals(pass))
                    {
                        flag = true;
                    }

                }
            }
            return flag;

        }

    }
}
