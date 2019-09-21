using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirstExistingDb
{
    /// <summary>
    /// NAMING MIGRATIONS
    /// Model Centric: AddCategory
    /// Database Centric: AddCategoriesTable
    /// </summary>
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
