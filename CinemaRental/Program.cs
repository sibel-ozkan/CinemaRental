using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaRental
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cinema cinema = new Cinema();
            cinema.SeedMovies();
            string devam = "e";
            while(devam =="e")
            {
                Console.WriteLine();
                Console.WriteLine("===== CINEMA RENTAL =====");
                Console.WriteLine("1 - Tüm Filmleri Listele");
                Console.WriteLine("2 - Türe Göre Listele");
                Console.WriteLine("3 - Film ekle");
                Console.WriteLine("4 - Film Çıkar");
                Console.WriteLine("5 - Film Kirala");
                Console.WriteLine();
                Console.Write("İşleminizi Seçin: ");

                string secim = Console.ReadLine();

                if (secim =="1")
                {
                    cinema.ListAllMovies();
                }

                else if (secim =="2")
                {
                    Console.WriteLine();
                    Console.WriteLine(" Fİlm türü Girin :");
                    string secilentur = Console.ReadLine();

                    cinema.turList(secilentur);
                    

                }
                else if (secim =="3")
                {
                    cinema.FilmEkle();
                    cinema.ListAllMovies();
                }

                else if (secim =="4")
                {
                    cinema.Cikar();
                    cinema.ListAllMovies();
                }
                else if (secim =="5")
                {
                    cinema.Kirala();
                }
                Console.WriteLine();
                Console.WriteLine(" Menüye devam etmek ister misiniz ? e/h");
                devam = Console.ReadLine();
            }
            
        }
    }
}
