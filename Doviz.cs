using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankacilikUygulamasi
{
    public class Doviz
    {
        public virtual double Dolar
        {
            get
            {
                return Dolar_Conflict;
            }
        }

        public virtual double Euro
        {
            get
            {
                return Euro_Conflict;
            }
        }
        
        public double Dolar_Conflict = 7.1094;
        public double Euro_Conflict = 7.9283;

    }
}
