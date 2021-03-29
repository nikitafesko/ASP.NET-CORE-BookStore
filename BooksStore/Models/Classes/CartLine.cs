namespace BookStore.Models.Classes
{
    public class CartLine
    {
        public int CartLineId { get; set; }
        public string  UserName { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}