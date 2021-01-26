using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace BankacilikUygulamasi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Banka banka = new Banka();
            Musteri Ismail = new Musteri(326785, "IsmailBorazan", "TR610003200013900000326785", 350.00, 8000.00, "EU610003", "IsmB1982");
            Musteri Kamile = new Musteri(400129, "KamileHursitogullari", "TR610008324560000000400129", 2980.45, 0.00, "EU610003", "12Hrst34");
            Musteri Zebercet = new Musteri(388000, "ZebercetBak", "TR6100007222250001200388000", 19150.00, 52.93, "EU610003","zb123456");
            Musteri NazGul = new Musteri(201005, "NazGulUcan", "TR610032455466661200201005", 666.66, 10000.00, "EU610003", "Mordor99");

            banka.musteriList.Add(Ismail);
            banka.musteriList.Add(Kamile);
            banka.musteriList.Add(Zebercet);
            banka.musteriList.Add(NazGul);

            Login loginController = new Login();
            int id;
            string pass;
            int kalanDenemeHakki = 2;

            Console.WriteLine("-------------------------------------------");
            while (true)
                try
                {
                    int choise;
                    Console.WriteLine("Giris yapmak icin lutfen id giriniz");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Giris yapmak icin lutfen sifre giriniz");
                    pass = Console.ReadLine();
                    if (loginController.loginControl(banka, id, pass))
                    {
                        Console.WriteLine("Giris BASARILI!!");
                        int whoAmI = 90;
                        Console.WriteLine("Hesap Bilgileriniz : ");
                        for (int i = 0; i < banka.MusteriList.Count; i++)
                        {
                            if (banka.MusteriList[i].HesapNo == id)
                            {
                                whoAmI = i;
                                Console.WriteLine("Hesap no : " + banka.MusteriList[i].HesapNo);
                                Console.WriteLine("Isim - Soyisim : " + banka.MusteriList[i].AdSoyad);
                                Console.WriteLine("IBAN TR : " + banka.MusteriList[i].IBANTR);
                                Console.WriteLine("TL birikim miktari : " + banka.MusteriList[i].MiktarIBANTR);
                                Console.WriteLine("IBAN EURO : " + banka.MusteriList[i].IBANEURO);
                                Console.WriteLine("Doviz birikim miktari : " + banka.MusteriList[i].MiktarIBANEURO);
                            }

                        }
                        Console.WriteLine(" EFT yapmak icin (1) - Cikis yapmak icin farkli bir rakam tuslayiniz... ");
                        choise = Convert.ToInt32(Console.ReadLine());
                        if (choise == 1)
                        {
                            int whom;
                            for (int j = 0; j < banka.MusteriList.Count; j++)
                            {
                                if (j != whoAmI)
                                {
                                    Console.WriteLine(banka.MusteriList[j].AdSoyad + " icin " + j + " tuslayiniz...");
                                }
                            }
                            whom = Convert.ToInt32(Console.ReadLine());
                            int tlOrUsd;
                            double amount;
                            Console.WriteLine("TL icin 1'i Doviz icin 2'yi tuslayin...");
                            tlOrUsd = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Transfer Miktarini Giriniz...");
                            amount = Convert.ToDouble(Console.ReadLine());
                            if (tlOrUsd == 1)
                            {
                                if (amount > banka.MusteriList[whoAmI].MiktarIBANTR)
                                {
                                    while (amount > banka.MusteriList[whoAmI].MiktarIBANTR)
                                    {
                                        Console.WriteLine("Bakiyeniz Yetersiz, Lutfen en fazla " + banka.MusteriList[whoAmI].MiktarIBANTR + " TL olacak sekilde giris yapiniz..");
                                        amount = Convert.ToDouble(Console.ReadLine());
                                    }
                                }

                                banka.MusteriList[whoAmI].MiktarIBANTR = banka.MusteriList[whoAmI].MiktarIBANTR - amount;
                                banka.MusteriList[whom].MiktarIBANTR = banka.MusteriList[whom].MiktarIBANTR + amount;
                            }
                            else
                            {

                                if (amount > banka.MusteriList[whoAmI].MiktarIBANEURO)
                                {
                                    while (amount > banka.MusteriList[whoAmI].MiktarIBANEURO)
                                    {
                                        Console.WriteLine("Bakiyeniz Yetersiz, Lutfen en fazla " + banka.MusteriList[whoAmI].MiktarIBANEURO + " TL olacak sekilde giris yapiniz..");
                                        amount = Convert.ToDouble(Console.ReadLine());
                                    }
                                }

                                banka.MusteriList[whoAmI].MiktarIBANEURO = banka.MusteriList[whoAmI].MiktarIBANEURO - amount;
                                banka.MusteriList[whom].MiktarIBANEURO = banka.MusteriList[whom].MiktarIBANEURO + amount;
                            }
                            Console.WriteLine("Isleminiz Basariyla Gerceklesmistir !! ");
                            Console.WriteLine("Islem sonrasi hesap durumunuz : ");

                            int i = whoAmI;
                            Console.WriteLine("Hesap no : " + banka.MusteriList[i].HesapNo);
                            Console.WriteLine("Isim - Soyisim : " + banka.MusteriList[i].AdSoyad);
                            Console.WriteLine("IBAN TR : " + banka.MusteriList[i].IBANTR);
                            Console.WriteLine("TL birikim miktari : " + banka.MusteriList[i].MiktarIBANTR);
                            Console.WriteLine("IBAN EURO : " + banka.MusteriList[i].IBANEURO);
                            Console.WriteLine("Doviz birikim miktari : " + banka.MusteriList[i].MiktarIBANEURO);

                            Console.WriteLine("Guvenliginiz icin sistem her islem sonrasi hesabinizdan otomatik olarak cikis yapmaktadir.");
                            Console.WriteLine("Yeniden islem yapmak istiyorsaniz lutfen tekrar giris yapiniz...");
                            Console.WriteLine("Tekrar Giris Yapmak Icin (1) - Cikmak icin(0) tuslayin");
                            int oout = Convert.ToInt16(Console.ReadLine());
                            if (oout != 1)
                            {
                                Environment.Exit(0);
                            }
                            Console.WriteLine(" --------------------------------------------------- ");

                        }
                        else
                        {
                            Environment.Exit(0);
                        }


                    }
                    else
                    {
                        if (kalanDenemeHakki >= 0)
                        {

                            Console.WriteLine("Hesap No veya Sifre Yanlis!!" + kalanDenemeHakki + " deneme hakkiniz kaldi.");
                            kalanDenemeHakki--;
                        }
                        else
                        {
                            Console.WriteLine("24 Saatligine Erisim Kisitlamasi Cezasi Aldiniz Lutfen 24 saat bekleyiniz...");
                            long start = DateTimeHelper.CurrentUnixTimeMillis();
                            Thread.Sleep(86400000);
                            kalanDenemeHakki = 2;
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Lütfen verilen rakamlardan başka bir rakam tuşlamayınız");
                }
        }
    }
}

internal static class DateTimeHelper
{
    private static readonly System.DateTime Jan1st1970 = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
    public static long CurrentUnixTimeMillis()
    {
        return (long)(System.DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
    }
}