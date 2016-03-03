using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Homework2
{
    class Order
    {
        private string senderid;
        private int cardNo;
        private string receiverID;
        private int amount;
        private double orderTime;
        private DateTime time;
        private double totalPrice;
       
        public Order()
        {
            senderid = null;
            cardNo = 0;
            receiverID = null;
            amount = 0;
            orderTime = 0;
            
        }

        //set order price
        public void setOrderPrice(double newAmount)
        {
            this.totalPrice = newAmount;
        }

        //get order price
        public double getOrderPrice()
        {
            return totalPrice;
        }

        // get Time
        public DateTime getTime()
        {
            return this.time;
        }

        //set system time
        public void setTime(DateTime time)
        {
            this.time = time;
        }

        // constructor of different type
        public Order(string s, int c, string rc,int amt)
        {
            senderid = s;
            cardNo = c;
            receiverID = rc;
            amount = amt;

        }


        // set sender id, card no, receiverID and room amounts
        public void setDataMembers(string s,int c, string rc,int amt)
        {
          
            senderid = s;
            cardNo = c;
            receiverID = rc;
            amount = amt;
         
        }

     
        //Get Sender ID
        public string getSenderid()
        {
            return this.senderid;
        }

        //Get Card No
        public int getCardNo()
        { return this.cardNo; }

        //Get Reciever ID
        public string getRecieverId()
        { return this.receiverID; }

        //getAmount
        public int getAmount()
        {
            return this.amount;
        }


        // set the order time
        public void setOrderTime(double ordertime)
        {
            this.orderTime = ordertime;
        }

        //get the orser completion time

        public double getOrderTime()
        {
            return this.orderTime;
        }


    }
}
