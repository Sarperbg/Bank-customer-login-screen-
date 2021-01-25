using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankacilikUygulamasi
{
    public class Musteri : MusteriSinif, MusteriSoyut
    {
        protected internal double miktarIBANEURO;
        protected internal string IBANEURO_Conflict;
        protected internal string parola;

        public Musteri(int hesapNo, string adSoyad, string IBANTR, double miktarIBANTR, double miktarIBANEURO, string IBANEURO, string parola) : base(hesapNo, adSoyad, IBANTR, miktarIBANTR)
        {
            this.miktarIBANEURO = miktarIBANEURO;
            this.IBANEURO_Conflict = IBANEURO;
            this.parola = parola;
        }

        public virtual double MiktarIBANEURO
        {
            get
            {
                return miktarIBANEURO;
            }
            set
            {
                this.miktarIBANEURO = value;
            }
        }

        public virtual string IBANEURO
        {
            get
            {
                return IBANEURO_Conflict;
            }
            set
            {
                this.IBANEURO_Conflict = value;
            }
        }

        protected internal virtual string Parola
        {
            get
            {
                return parola;
            }
        }

    }
}
