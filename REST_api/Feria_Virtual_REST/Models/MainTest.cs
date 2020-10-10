using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feria_Virtual_REST.Models
{
    public class MainTest
    {
        static void Main(string[] args)
        {
            
            Admin adminTest1 = new Admin("admin1", "admin1@server.com", "passcode");
            Admin adminTest2 = new Admin("admin2", "admin2@server.com", "passcode");
            Admin adminTest3 = new Admin("admin3", "admin3@server.com", "passcode");
            Client clientTest = new Client("client", "client@server.com", "passcode");
            Seller sellerTest = new Seller("seller", "seller@server.com", "passcode");

            UserManager.registerUser(adminTest1);
            UserManager.registerUser(adminTest2);
            UserManager.registerUser(adminTest3);
            UserManager.registerUser(clientTest);
            UserManager.registerUser(sellerTest);

            JsonSerializer.saveUsers(UserManager.getUsers());

        }
    }
}