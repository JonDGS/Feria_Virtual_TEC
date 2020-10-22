namespace Feria_Virtual_REST.Models
{
    public class Address
    {

        public string provincia;
        public string canton;
        public string distrito;

        public Address(string provincia, string canton, string distrito)
        {
            this.provincia = provincia;
            this.canton = canton;
            this.distrito = distrito;
        }

        public string getProvincia()
        {
            return this.provincia;
        }

        public string getCanton()
        {
            return this.canton;
        }

        public string getDistrito()
        {
            return this.distrito;
        }



    }
}