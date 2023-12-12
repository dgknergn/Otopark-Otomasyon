using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {          
            Otopark otopark = new Otopark(20);
            
            bool geridonus = true;
            do
            {
                Console.WriteLine("OTOPARK OTOMASYON UYGULAMASI");
                Console.WriteLine();
                Console.WriteLine("-------------------------------");

                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçin:");
                Console.WriteLine("1. Araç Ekleme");
                Console.WriteLine("2. Araç Çıkarma");
                Console.WriteLine("3. Tüm Araçları Listeleme");
                Console.WriteLine("4. Boş Yer Kontrolü");
                Console.WriteLine("5. Aracı Güncelleme");
                Console.WriteLine("6. Aracı Bulma");
                Console.WriteLine("7. Belirli Renkteki Araçları Listeleme");
                Console.WriteLine("8. Belirli Modeldeki Araçları Listeleme");
                Console.WriteLine("9. Otoparkı Sıfırlama");
                string secilenIslem = Console.ReadLine();



            

            switch (secilenIslem)
            {
                    case "1":
                
                    Console.Clear();
                    Console.WriteLine("Araç ekleme işlemini seçtiniz.");
                    Console.WriteLine();
                    Console.WriteLine("Araç eklemek için bilgileri girin:");

                    Console.Write("Plaka: ");
                    string plaka = Console.ReadLine();
                    Console.Write("Marka: ");
                    string marka = Console.ReadLine();
                    Console.Write("Model: ");
                    string model = Console.ReadLine();
                    Console.Write("Renk: ");
                    string renk = Console.ReadLine();
                    otopark.AracEkle(plaka, marka, model, renk);


                        break;
                         

                    case "2":
                    Console.Clear();
                    Console.WriteLine("Araç Ekleme işlemini seçtiniz.");
                    Console.WriteLine();
                    Console.WriteLine("Araç çıkarmak için plakayı girin: ");
                    string cikarPlaka = Console.ReadLine();
                    cikarPlaka.ToUpper();
                    otopark.AracCikar(cikarPlaka);

                    
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("OTOPARKTAKİ TÜM ARAÇLAR ;");
                    Console.WriteLine("--------------------------");
                    otopark.AracListele();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("OTOPARKTAKİ BOŞ YER SAYISI");
                    otopark.BosYerKontrolu();
                    break;

                case "5":
                        Console.Clear();
                        Console.WriteLine("Araç güncelleme işlemini seçtiniz");
                        Console.WriteLine("Güncellemek istediğiniz aracın Plakasını yazınız");

                        string guncellencekAracPlaka = Console.ReadLine();

                        Console.WriteLine("Aracınızın güncel bilgilerini giriniz.");
                        Console.Write("Aracın yeni modeli = ");
                        string yeniModel = Console.ReadLine();
                        Console.Write("Aracın yeni markası = ");
                        string yeniMarka = Console.ReadLine();
                        Console.Write("Aracın yeni rengi = ");
                        string yeniRenk = Console.ReadLine();

                        otopark.AracBilgileriniGuncelle(guncellencekAracPlaka,yeniModel,yeniMarka,yeniRenk);
                        Console.WriteLine("ARACINIZ GÜNCELLENMİŞTİR");
                        break;

                    case "6":
                        Console.Clear();
                        Console.WriteLine("Araç bulma işlemini seçtiniz.");
                        Console.WriteLine("Lütfen aracınızın plakasını giriniz");
                        string arancakPlaka = Console.ReadLine();

                        otopark.AracArama(arancakPlaka);
                        break;

                    case "7":
                        Console.Clear();
                        Console.WriteLine("Lütfen listelemek istediğiniz rengi giriniz: ");
                        string listelencekRenk= Console.ReadLine();
                        listelencekRenk.ToLower();

                        otopark.BelirliRenktekiAraclarıListele(listelencekRenk);
                        break;

                    case "8":
                        Console.Clear();
                        Console.Write("Lütfen listelemek istediğiniz Modeli Giriniz");
                        string listelencekModel = Console.ReadLine();
                        listelencekModel.ToLower();
                        otopark.BelirliModeldekiAraclarıListele(listelencekModel);
                        break;

                    case "9":
                        Console.Clear();
                        Console.WriteLine("Otoparkı tamamıyla boşaltmak üzeresiniz. İşlemin gerçekleşmesi için lütfen 'Onay' yazınız.");
                        string onay = Console.ReadLine();
                        otopark.OtoparkiSifirlama(onay);
                        Console.WriteLine("Otopark Sıfırlanmıştır.");
                        break;
                }


            } while (geridonus == true);


            Console.ReadKey();
            }
        }
    }

