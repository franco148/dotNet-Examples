using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirstExistingDb
{
    /// <summary>
    /// Once our Context is created based on reverse engineering. We need to enable migrations.
    /// - Enable-Migrations
    /// - Add-Migration InitialModel
    /// 
    /// Then, if we run migrations, we will get an exception, So for solving it, we need to use a flag -IgnoreChanges
    /// - Add-Migration InitialModel -IgnoreChanges -Force
    /// - Update-Database
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
