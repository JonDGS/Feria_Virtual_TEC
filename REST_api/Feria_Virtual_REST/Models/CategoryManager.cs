using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feria_Virtual_REST.Models
{
    public class CategoryManager
    {
        private static LinkedList<Category> registeredCategories = JsonManager.retrieveCategories();
        /*
         * Description: Registers a category in the database
         * Parameters: newProduct-> product being registered
         * Return: None
         */
        public static void registerCategory(Category newCategory)
        {
            registeredCategories.AddLast(newCategory);
            JsonManager.saveCategory(registeredCategories);
        }

    }
}