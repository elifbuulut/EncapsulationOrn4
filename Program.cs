using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationOrn4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Set ve Get metotlarını birer kontrol mekanizması olarak düşünebiliriz.
            //Olası problemleri önlemek, işlemleri güvenilir ve kontrollü bir şekilde gerçekleştirmek için Set ve Get metotlarını kullanırız.

            //Basit bir senaryo üzerinden konumuzu açıklamaya devam edelim. Otel otomasyonu için müşteri bilgilerini tutan bir sınıf tasarladığımızı düşünelim.
            //Müşterinin ad-soyad, TC kimlik numarası ve oda numarası bilgilerini tutmak istiyorsak aşağıdaki gibi bir tasarım yapabiliriz.
            /*
             * class Muster
             * {
             * public string AdSoyad;
             * public ulong TCNo;
             * public int OdaNo;
             * }*/
            //Musteri sınıfının üyeleri public olarak bildirildiği için bu üyelere doğrudan erişilip değerler atanabilir.
            //İşte bu noktada kontrolü elimize almamız lazım aksi taktirde TC kimlik numarası eksik/fazla girilebilir veya 120 odalı bir otelde oda
            //numarası negatif veya 120’den büyük girilebilir. Amacımız dikkatsizlik sonucu yaşanabilecek olası sorunların önüne geçmek.
            //Bu yüzden üyelere doğrudan erişimi engelleyip (Private), Get ve Set metotları ile kontrollü bir erişim sağlayacağız.
           
            // fieldlarımız 
            Musteri musteri = new Musteri();
            Console.WriteLine("Ad ve soyadınızı giriniz");
            string adSoyad=Console.ReadLine();
            Console.WriteLine("Tc no giriniz");
            string tcNo=Console.ReadLine();        
            musteri.Tcno= tcNo;

            Console.WriteLine("Oda no giriniz");
            int odaNo=Convert.ToInt32(Console.ReadLine());
            musteri.OdaNo= odaNo;
            Console.WriteLine($"Otelimize hoşgeldiniz Sayın {adSoyad}.TC NUMARASI: {musteri.Tcno}, Oda Numarası:{odaNo}");
            Console.ReadLine();


     
            

         
        }
    }

    //
    class Musteri
    {
        //fieldlarımız 
        private string _adSoyad, _tcNo;
        private int _odaNo;

        public string adSoyad
        {
            get { return _adSoyad; }

            set
            {
                _adSoyad = value;

            }
        }
        public string Tcno
        {
            get { return _tcNo; } 
            set {
                if (value.ToString().Length==11) // donen değerin uzunluğu, kelime sayısı 11 ise 
                {
                    _tcNo = value;

                }

                else
                {
                    Console.WriteLine("11 haneli olmalıdır!");
                }
            }

        }

        public int OdaNo
        { 
            get { return _odaNo; }

            set
            {
                if (value > 0 && value <= 120)
                {
                    _odaNo = value;

                }
                else
                {
                    Console.WriteLine("1 ile 120 sayıları arasında olmalıdır!");
                }
            } 
        }
    }
}
