using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Homework2
{
    enum WeekDays
    {   Sunday, Monday, Tuesday, Wednesday,  Thursday, Friday,Saturday   }

    

    class HotelSupplier
    {
        public static event priceCutEvent PriceCut;
        static Random rnd = new Random();
        int totalAmount;
        private int count = 1;

        private string hotelName;
        private int totalRooms;
        private int initialPrice;

        // constructor for hotel supplier
        public HotelSupplier(string name,int rooms,int price)
        {
            this.hotelName = name;
            this.totalRooms = rooms;
            this.initialPrice = price;
        }
        
        // Get the hotel room price
        public int getPrice()
        {
            return initialPrice;
        }

        //get hotel name
        public string getName()
        {
            return hotelName;
        }

        // Price cut event
       


        // Price Model for Hotel Supplier
        public void PricingModel()
        {
            while (count <= 10)
            {
                Thread.Sleep(rnd.Next(500, 1000));
                DayOfWeek Today = DateTime.Today.DayOfWeek;
                int comparevalues;
                Int32 VarPrice;
                comparevalues = Today.ToString().CompareTo(WeekDays.Thursday.ToString());
                if (comparevalues == -1)
                    VarPrice = rnd.Next(50, 100);
                else
                    VarPrice = rnd.Next(1, 60);

                // Event handling
                if(VarPrice<initialPrice)
                {
                    Console.WriteLine("\n\t***Price Down Count:{0} for {1}!!! Hurry up Book!!*** \n\t\t{2} on sale price : ${3} per room\n\n", count, hotelName, hotelName,VarPrice);
                    count++;
                    PriceCut(VarPrice,this.hotelName);
                }
                else
                {
                    Console.WriteLine("\n\t***Price Up!!! Market is up now !*** \n\t\t{0} on sale price : ${1} per room\n\n", hotelName, VarPrice);
                }
                initialPrice = VarPrice;
            }
        }

        
        // Consume order from multi buffer cells
        
        public void consumeOrder()
        {

            while (true)
            {
                String s = Program.mcb.getOne(this.hotelName);
                if (s != null)
                {
                    EncoderDecoder decoder = new EncoderDecoder();
                    Order obj = decoder.getDecodedOrder(s);
                    OrderProcessing(obj);
                }
            }
                
            
        }

        // process the order
       public void OrderProcessing(Order oo)
        {
           if(oo.getAmount()>totalRooms)
           {
               Console.WriteLine("Sorry {0}!!! The total rooms available at {1} is {2}", oo.getSenderid(),oo.getRecieverId(), totalRooms);
               return;
           }
           
                int CardNo=oo.getCardNo();
                if ( CardNo>=6000 && CardNo <= 7000 )
                {
                    totalRooms = totalRooms - oo.getAmount();
                    totalAmount = initialPrice * oo.getAmount();
                    oo.setOrderPrice(totalAmount);
                    DateTime now = DateTime.UtcNow;
                    TimeSpan difference = now.Subtract(oo.getTime());
                    oo.setOrderTime(difference.TotalSeconds);
                    TravelAgency.callback(oo);
                }
                else
                    Console.WriteLine("Invalid Credit  ! Transaction Aborted !!!!! - Order recieved from {0} for {1} failed ", oo.getSenderid(),oo.getRecieverId());
                
            }
          

    }
}
