using System;

namespace Education_dotNet_Serialization_class
{
    [Serializable]
    public class Order
    {
        public int Count;

        public decimal Price;

        [NonSerialized]
        public decimal TotalPrice;

        public Order(int count, decimal price)
        {
            this.Count = count;
            this.Price = price;

            this.TotalPrice = count * price;
        }
    }
}