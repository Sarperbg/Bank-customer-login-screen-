using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankacilikUygulamasi
{
    public class Banka
    {
        internal IList<Musteri> musteriList = new List<Musteri>();

        public virtual IList<Musteri> MusteriList
        {
            get
            {
                return musteriList;
            }
            set
            {
                this.musteriList = value;
            }
        }
    }
}
