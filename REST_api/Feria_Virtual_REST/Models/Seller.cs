namespace Feria_Virtual_REST.Models
{
    public class Seller : User
    {
        public string cedula;
        public string realName;
        public string lastName1;
        public string lastName2;
        public Address address;
        public Date dateOfBirth;
        public string phoneNumber;
        public string sinpe;
        public string lugarDeEntrega;
        public int admitted;

        public Seller(string username, string email, string password, string cedula, string realName, string lastName1, string lastName2,
            string provincia, string canton, string distrito, int month, int day, int year, string phoneNumber, string sinpe, string lugarDeEntrega) : base(username, email, password)
        {
            this.type = "Seller";
            this.cedula = cedula;
            this.realName = realName;
            this.lastName1 = lastName1;
            this.lastName2 = lastName2;
            this.address = new Address(provincia, canton, distrito);
            this.dateOfBirth = new Date(month, day, year);
            this.phoneNumber = phoneNumber;
            this.sinpe = sinpe;
            this.lugarDeEntrega = lugarDeEntrega;
            this.admitted = 1;
        }

        public void setAdmitted(int status)
        {
            this.admitted = status;
        }
    }
}