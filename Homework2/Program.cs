using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

public delegate void priceCutEvent(Int32 pr, String hotelname);
namespace Homework2
{
    public delegate void priceCutEvent(Int32 pr, String hotelname);
    class Program
    {
       public static TravelAgency ta1 = new TravelAgency("Expedia");
       public static TravelAgency ta2 = new TravelAgency("Clear Trip");
       public static TravelAgency ta3 = new TravelAgency("MakeMyTrip");
       public static TravelAgency ta4 = new TravelAgency("Yatra");
       public static TravelAgency ta5 = new TravelAgency("Kayak");

        public static Order OrderObject = new Order();

        public static MultiCellBuffer mcb = new MultiCellBuffer();

              
        static void Main(string[] args)
        {



            HotelSupplier supplier1 = new HotelSupplier("Hyatt", 100, 80);
            HotelSupplier supplier2 = new HotelSupplier("Sheraton", 200, 150);
           

            Thread hotel1 = new Thread(new ThreadStart(supplier1.PricingModel));
            Thread hotel2 = new Thread(new ThreadStart(supplier2.PricingModel));
       

            hotel1.Start();
            hotel2.Start();
           


            Thread hotel1check = new Thread(new ThreadStart(supplier1.consumeOrder));
            Thread hotel2check = new Thread(new ThreadStart(supplier2.consumeOrder));
            

            hotel1check.Start();
            hotel2check.Start();
          


            HotelSupplier.PriceCut += new priceCutEvent(ta1.HotelOnSale);
            HotelSupplier.PriceCut += new priceCutEvent(ta2.HotelOnSale);
            HotelSupplier.PriceCut += new priceCutEvent(ta3.HotelOnSale);
            HotelSupplier.PriceCut += new priceCutEvent(ta4.HotelOnSale);
            HotelSupplier.PriceCut += new priceCutEvent(ta5.HotelOnSale);


            hotel1.Join();
            hotel2.Join();
          

            Console.WriteLine("Main thread: All threads have been terminated.");
        }
    }
}
