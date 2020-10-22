namespace Feria_Virtual_REST.Models
{
    public class Admin : User
    {
        public Admin(string username, string email, string password) : base(username, email, password)
        {
            this.type = "Admin";
        }
    }
}