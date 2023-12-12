using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ConsoleApp2
{
    internal class Otopark
    {
        private List<Arac> araclar = new List<Arac>();
        private int kapasite;

        public Otopark(int kapasite) {
            this.kapasite = kapasite;
        }

        public void AracEkle(string plaka, string marka, string model, string renk)
        {
            
            if (araclar.Count < kapasite) //EĞER OTOPARK DOLMADIYSA
            {
                if (!araclar.Any(arac =>arac.plaka ==plaka)) //VE EĞER YAZILAN PLAKA HALİ HAZIRDA OTOPARKTA KAYITLI DEĞİLSE
                {
                    Arac yeniArac = new Arac()
                    {
                        plaka = plaka,              
                        marka = marka,                        //ARAC SINIFINDA BELİRTTİĞİMİZ İFADELERİ , GİRİLECEK OLAN İFADELERE EŞİTLE VE ARACLAR.ADD İLE ARACLAR LİSTESİNE AT 
                        model = model,
                        renk = renk,
                        GirisZamani = DateTime.Now,
                    };
                    araclar.Add(yeniArac);
                    Console.WriteLine("Araç Otoparka Eklendi");
                }
                else
                {
                    Console.WriteLine("Bu plakayla kayıt olan bir araç hali hazırda var. "+plaka); //GİRİLEN PLAKA OTOPARKA ZATEN KAYITLIYSA VERİLEN HATA
                }
            }
            
            else
            {
                Console.WriteLine("Otopark Dolu. Yeni araç Ekleyemessiniz."); //OTOPARK DOLU İSE VERİLEN HATA 
            }
            
            
        }
        public void AracCikar (string plaka)
        {
            
            Arac bulunanArac = araclar.Find(arac => arac.plaka == plaka);  //Listenin içinden yazılan plakalı aracı bulur.
            if (bulunanArac != null)                        //bulunanArac değişkeni boş değilse , aracı kaldırma işlemini gerçekleştirir.
            {
                araclar.Remove(bulunanArac);
                Console.WriteLine("Araç Kaldırılmıştır.");
            }
            else
            {
                Console.WriteLine("Araç bulunamadı. "); //bulunanArac değişkeni boş ise verilecek hata;
            }

        }
        public void AracListele()
        {
            if (araclar != null)                //Eğer araclar listesi null değilse yani herhangi bir arac bulunmuşsa
            {
                Console.WriteLine("OTOPARKTAKİ ARAÇ SAYISI = "+araclar.Count());   //Önce toplam araç sayısını yaz
                int sayac = 0;
                foreach (var arac in araclar)
                {
                    sayac++;
                    
                    Console.WriteLine("{0}. Araç = "+"Plaka: {1} , Marka: {2} , Model: {3} , Renk: {4} " ,sayac, arac.plaka, arac.marka, arac.model, arac.renk);
                    //Foreach ile tüm araclar listesinin içerisini gezip arabaları yazdır.
                }
                
            }
            else
            {
                Console.WriteLine("Listelenecek Araç bulunamadı."); //Eğer araclar listesi null ise verilecek hata
            }          
            
        }

        public bool BosYerKontrolu()
        {
            if (araclar.Count <kapasite) 
            {
                Console.WriteLine("Otoparktaki boş yer sayısı = " +(kapasite- araclar.Count));
            }
            else if (araclar.Count >=kapasite)
            {
                Console.WriteLine("Otoparkta boş yer yok !!");
            }
            return araclar.Count < kapasite;
        }

        public void AracArama(string plaka)
        {
            var aArama = araclar.Find(arac => arac.plaka == plaka);
            if (aArama != null)
            {
                Console.WriteLine("Aracın plakası =" +aArama.plaka);
                Console.WriteLine("Aracın markası =" +aArama.marka);
                Console.WriteLine("Aracın modeli =" +aArama.model);
                Console.WriteLine("Aracın rengi =" +aArama.renk);               
            }
            else
            {
                Console.WriteLine("Araç bulunamadı");
            }

        }
        public int ToplamAracSayisi()
        {
            return araclar.Count;
        }

        public void BelirliRenktekiAraclarıListele(string renk)
        {
            int sayac = 0;
            var renkListe = araclar.FindAll(arac => arac.renk == renk);
            if (renkListe != null)
            {
                foreach (var item in renkListe)
                {
                    sayac++;
                    Console.WriteLine("{0}. Araç = " + "Plaka: {1} , Marka: {2} , Model: {3} , Renk: {4} ", sayac, item.plaka, item.marka, item.model, item.renk);
                }
            }
            else
            {
                Console.WriteLine("Belirtilen renkte araç bulunamadı.");
            }
            
        }
        public void BelirliModeldekiAraclarıListele(string model)
        {
            int sayac = 0;
            var modelListe = araclar.FindAll(arac => arac.model == model);
            if (modelListe != null)
            {
                foreach (var item in modelListe)
                {
                    sayac++;
                    Console.WriteLine("{0}. Araç = " + "Plaka: {1} , Marka: {2} , Model: {3} , Renk: {4} ", sayac, item.plaka, item.marka, item.model, item.renk);
                }
            }
        }
        public void AracBilgileriniGuncelle (string plaka , string yeniModel , string yeniMarka , string yeniRenk)
        {
            

            bool aracVarMi = araclar.Any(arac => arac.plaka == plaka);
            if (aracVarMi)
            {                
                Arac guncellencekArac = araclar.Find(arac => arac.plaka == plaka);
                
                guncellencekArac.model= yeniModel;
                guncellencekArac.marka = yeniMarka;
                guncellencekArac.renk = yeniRenk;
                Console.WriteLine("Araç bilgileri güncellendi.");
            }
            else
            {
                Console.WriteLine("Güncellenmek istenen araç bulunamadı.");
            }
        }
        public void AracDetaylarınıGoruntuleme(string plaka)
        {
            Arac detayGoruntulencekArac = araclar.Find(arac =>arac.plaka ==plaka);
            if (detayGoruntulencekArac !=null)
            {
                Console.WriteLine("Plaka: {0} , Model: {1} , Marka: {2} , Renk: {3}" , detayGoruntulencekArac.plaka,detayGoruntulencekArac.model,detayGoruntulencekArac.marka,detayGoruntulencekArac.renk);
            }
            else
            {
                Console.WriteLine("Detaylıca Görüntülencek Araç bulunamadı.");
            }
        }
        
        public void OtoparkiSifirlama (string onay)
        {
            if (onay == "Onay")
            {
                araclar.Clear();

            }
            else
            {
                Console.WriteLine("Onay vermediniz. İşlem iptal ediliyor.");
            }
        }
        

    }
}
