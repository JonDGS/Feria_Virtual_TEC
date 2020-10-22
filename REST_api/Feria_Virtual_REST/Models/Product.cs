namespace Feria_Virtual_REST.Models
{
    public class Product
    {
        public string pName;
        public string category;
        public int price;
        public string packageMode;
        public int availability;
        public string seller;
        public int sold;
        public int revenue;

        public Product(string pName, string category, int price, string packageMode, int availability, string seller)
        {
            this.pName = pName;
            this.category = category;
            this.price = price;
            this.packageMode = packageMode;
            this.availability = availability;
            this.seller = seller;
        }

        public void addSale()
        {
            this.sold++;
        }
    }
}