using System;
using System.Collections.Generic;
using System.Text;

namespace UmashiOrdersDemo
{
    public class Client
    {
        public Client(string[] order, string orderType)
        {
            this.Order = order;
            this.OrderType = orderType;
        }

        public Client(string[] order, string orderType, int numberOfPeople) : this(order, orderType)
        {
            this.NumberOfPeople = numberOfPeople;
        }
        public int NumberOfPeople { get; set; }

        public string[] Order { get; set; }

        public string OrderType { get; set; }

        static void NewOrderTaken()
        {

        }
    }
}
