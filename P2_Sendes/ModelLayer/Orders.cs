using System;
namespace ModelLayer
{
    public class Order : UserBase
    {
        public Guid OrderID { get; set; }
        public Cart? UserCart { get; set; }
        public decimal Total { get; set; }
        public DateTime DatePurchased { get; set; }
        public Order()
        {
        }
        /// <summary>
        /// This is new orders
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="email"></param>
        public Order(string first, string last, string email) : base(first, last, email)
        {
            this.OrderID = Guid.NewGuid();
            this.First = first;
            this.Last = last;
            this.Email = email;
            this.Role = Status.User;
            this.UserCart = new Cart();
            decimal total = 0;
            if(this.UserCart != null)
            {
                foreach(Product p in this.UserCart._Cart)
                {
                    total += p.Price;
                }
            }
            this.Total = total;
            this.DatePurchased = DateTime.Now;


        }
    }
}

