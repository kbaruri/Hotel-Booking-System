using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Homework2
{
    class TravelAgency
    {
        private string AgencyName;
        Random rnd = new Random();
        int noOfRooms = 0;

        public TravelAgency(String name)
        {
            AgencyName = name;
        }


        public void HotelOnSale(Int32 p, String Hotelname)
        {
            if (p < 50)
                noOfRooms = rnd.Next(1, 10);
            else
                noOfRooms = rnd.Next(10, 20);
            //place order here
            placeOrder(AgencyName, Hotelname, noOfRooms);
            Thread.Sleep(rnd.Next(200, 1000));
        }


        public static void callback(Order oo)
        {
            Console.WriteLine("\n\n\t\tValidation Success!!! Payment Received\n\t\t**********Booking Reciept ***************\n\t\tHotel:{0}\n\t\tTravelAgency:{1}\n\t\tNum Rooms:{2}\n\t\tCard No: {3}\n\t\tAmount: {4} $\n\t\tOrder Duration: {5}\n\t\t************************\n",oo.getRecieverId(),oo.getSenderid(),oo.getAmount(),oo.getCardNo(),oo.getOrderPrice(),oo.getOrderTime()+"s");
        }

     
        public void placeOrder(String agencyName,string HotelName, int noofRooms)
        {
            int cardNumer = rnd.Next(5000, 7500);
            Monitor.Enter(Program.OrderObject);
            try
            {
                EncoderDecoder encoder = new EncoderDecoder();
                Console.WriteLine("Placing order for travel agency ID {0} and ID {1}", HotelName,agencyName);
                Program.OrderObject.setDataMembers(agencyName, cardNumer, HotelName, noOfRooms);
               // Console.WriteLine("Encoded String {0}" + EncoderDecoder.getencodedOrder(Program.OrderObject));
                string encodedstring = encoder.getencodedOrder(Program.OrderObject);
                DateTime CurrentTime = DateTime.UtcNow;
                Program.OrderObject.setTime(CurrentTime);
                Program.mcb.setOne(encodedstring);

            }
            finally
            {
                Monitor.Exit(Program.OrderObject);
            }
            }

            
    }


        
}
