namespace Feria_Virtual_REST.Models
{
    public class Date
    {
        public int month;
        public int day;
        public int year;

        public Date(int month, int day, int year)
        {
            this.month = month;
            this.day = day;
            this.year = year;
        }
    }
}