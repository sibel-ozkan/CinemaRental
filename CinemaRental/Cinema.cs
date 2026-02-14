using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CinemaRental
{
    internal class Cinema
    {
        List<Film> filmler = new List<Film>();
         public void SeedMovies()
        {
            Film f1 = new Film();
            f1.isim  = "Inception";
            f1.tur = "sci-fi";
            f1.stok = 5;
            f1.fiyat = 30;
            filmler.Add(f1);

            Film f2 = new Film();
            f2.isim = "The Godfather";
            f2.tur = "crime";
            f2.stok = 3;
            f2.fiyat = 35;
            filmler.Add(f2);

            Film f3 = new Film();
            f3.isim = "Interstellar";
            f3.tur = "sci-fi";
            f3.stok = 4;
            f3.fiyat = 32;
            filmler.Add(f3);

            Film f4 = new Film();
            f4.isim = "Parasite";
            f4.tur = "drama";
            f4.stok = 6;
            f4.fiyat = 28;
            filmler.Add(f4);

            Film f5 = new Film();
            f5.isim = "Avengers";
            f5.tur = "action";
            f5.stok = 7;
            f5.fiyat = 25;
            filmler.Add(f5);

        }

        public void ListAllMovies()
        {
            Console.WriteLine();
            Console.WriteLine("No  İsim                | Tür          |Stok   |  Fiyat");
            Console.WriteLine("--------------------------------------------------------");

            for (int i = 0; i < filmler.Count; i++)
            {
                Console.WriteLine((i+1).ToString().PadRight(3) + ") " + filmler[i].isim.PadRight(18) + " | " + filmler[i].tur.PadRight(12) + " | " + filmler[i].stok.ToString().PadRight(5) + " | " + filmler[i].fiyat);
            }
        }

        public void turList(string tur)
        {
            Console.WriteLine();
            Console.WriteLine("No  İsim                | Tür          |Stok   |  Fiyat");
            Console.WriteLine("--------------------------------------------------------");
            bool bulunduMu = false;

            for( int i = 0;i < filmler.Count;i++)
            {
                if (filmler[i].tur == tur) 
                {
                    bulunduMu = true;
                    Console.WriteLine((i+1).ToString().PadRight(3) + ") "+ filmler[i].isim.PadRight(18) + " | " + filmler[i].tur.PadRight (12) + " | " + filmler[i].stok.ToString().PadRight(5) + " | "+ filmler[i].fiyat);
                }
            }
        
        
        
        }

        public int Index(string aranan)

        {
        for ( int i = 0; i < filmler.Count;i++)
            {
                if (filmler[i].isim == aranan)
                {
                    return i; 
                }
            }
                return -1;
        
        }
        public void FilmEkle()
        {
            Console.WriteLine(" Film ismi : ");
            string isim = Console.ReadLine();

            int index = Index(isim);
            
            if(index != -1)
            {
                Console.WriteLine(" bu ürün zaten var kaç adet ekleyeceksiniz ?");
                int adet = Convert.ToInt32(Console.ReadLine());

                filmler[index].stok = filmler[index].stok + adet;
                Console.WriteLine("Güncel stok : " + filmler[index].stok);

            }
            else
            {
                Film yeni = new Film();
                yeni.isim = isim;

                Console.WriteLine("Kategori Girin :");
                yeni.tur = Console.ReadLine();

                Console.WriteLine("Fiyat girin :");
                yeni.fiyat = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Stok girin :");
                yeni.stok = Convert.ToInt32(Console.ReadLine());
               

                filmler.Add(yeni);
                Console.WriteLine(" Yeni ürün eklendi .. ");


            }
        }

        public void Cikar()
        {

            Console.WriteLine(" Çıkarmak istediğiniz filmi yazın: ");
            string isim = Console.ReadLine() ;
            int index = Index(isim);
            if (index != -1)
            {
                Console.WriteLine(" Böyle bir film bulunamadı");
                return;
            }
            Console.WriteLine(" Kaç adet çıkarılsın?");
            int adet = Convert.ToInt32(Console.ReadLine());

            if (adet <= 0)
            {
                Console.WriteLine(" adet 1 veya daha büyük olmalı ");
                return;
            }
           if (adet > filmler[index].stok)
            {
                Console.WriteLine(" stok yetersiz. Güncel stok : " + filmler[index].stok);
                return;

            }

            filmler[index].stok = filmler[index].stok - adet;
            if (filmler[index].stok ==0)
            {
                filmler.RemoveAt(index);
                Console.WriteLine(" stok sıfır ürün listeden kaldırıldı");
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine(" Stok azaltıldı. Güncel stok : " + filmler[index].stok);
            }

        }
        public void Kirala()
        {
            double toplam = 0;
            string devam = "e";

            while (devam =="e")
            {

                Console.WriteLine(" almak istediğiniz filmi yazın :");
                string isim = Console.ReadLine();

                int index = Index(isim);

                if(index ==-1) // hiç yoksa 
                {
                    Console.WriteLine(" filmi bulamadım");
                }
                else
                {
                    Console.WriteLine(" Kaç tane alacaksın ?");
                    int adet = Convert.ToInt32(Console.ReadLine());

                    if ( adet <=0) // - bir sayı ya da sıfır girersenin kontrolü 
                    {
                        Console.WriteLine(" 1 veya daha  fazla ürün giriniz ");
                    }
                    else if(adet > filmler[index].stok)
                    {
                        Console.WriteLine(" Stok yetersiz. Güncel Stok " + filmler[index].stok);
                    }

                    else
                    {
                        double AraTutar = adet + filmler[index].stok;
                        toplam = toplam + AraTutar;

                        filmler[index].stok = filmler[index].stok - adet;

                        Console.WriteLine(" sepete eklendi " + isim + "x" + adet + " = " + AraTutar + "TL");
                        Console.WriteLine("ara toplam :" + toplam + "TL");
                    }
                   
                }
                Console.WriteLine(" Başka bir film eklemek ister misin? e/h");
                devam = Console.ReadLine();
            }

            Console.WriteLine(" ---- Toplam : " + toplam + " TL");
                
                
        }



        



    }
}
