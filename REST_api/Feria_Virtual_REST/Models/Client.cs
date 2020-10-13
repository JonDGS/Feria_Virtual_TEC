using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Feria_Virtual_REST.Models
{
    public class Client : User
    {
        public string cedula;
        public string realName;
        public string lastName1;
        public string lastName2;
        public Address address;
        public Date dateOfBirth;
        public string phoneNumber;

        public Client(string username, string email, string password, string cedula, string realName, string lastName1, string lastName2, string provincia,
            string canton, string distrito, int month, int day, int year, string phoneNumber) : base(username, email, password)
        {
            this.type = "Client";
            this.cedula = cedula;
            this.realName = realName;
            this.lastName1 = lastName1;
            this.lastName2 = lastName2;
            this.address = new Address(provincia, canton, distrito);
            this.dateOfBirth = new Date(month, day, year);
            this.phoneNumber = phoneNumber;
        }
    }
}