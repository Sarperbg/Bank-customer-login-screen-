using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankacilikUygulamasi
{
    public abstract class MusteriSinif
    {
        protected internal int hesapNo;
        protected internal string adSoyad;
        protected internal string IBANTR_Conflict;
        protected internal double miktarIBANTR;

        public MusteriSinif(int hesapNo, string adSoyad, string IBANTR, double miktarIBANTR)
        {
            this.hesapNo = hesapNo;
            this.adSoyad = adSoyad;
            this.IBANTR_Conflict = IBANTR;
            this.miktarIBANTR = miktarIBANTR;
        }

        public virtual int HesapNo
        {
            get
            {
                return hesapNo;
            }
            set
            {
                if (value.ToString().Length == 6)
                    hesapNo = value;
                else
                    Console.WriteLine("Hesap Numarası 6 Haneli Olmalıdır.");
            }
        }


        public virtual string AdSoyad
        {
            get
            {
                return adSoyad;
            }
            set
            {
                this.adSoyad = value;
            }
        }


        public virtual string IBANTR
        {
            get
            {
                return IBANTR_Conflict;
            }
            set
            {
                this.IBANTR_Conflict = value;
            }
        }


        public virtual double MiktarIBANTR
        {
            get
            {
                return miktarIBANTR;
            }
            set
            {
                this.miktarIBANTR = value;
            }
        }
    }
}
