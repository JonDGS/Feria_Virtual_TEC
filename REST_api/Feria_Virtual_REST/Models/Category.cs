namespace Feria_Virtual_REST.Models
{
    public class Category
    {
        public string code;
        public string categoryName;
        public Category(string code, string categoryName)
        {
            this.code = code;
            this.categoryName = categoryName;
        }
        public void setCode(string code)
        {
            this.code = code;
        }
        public void setCategoryName(string categoryName)
        {
            this.categoryName = categoryName;
        }
    }
}