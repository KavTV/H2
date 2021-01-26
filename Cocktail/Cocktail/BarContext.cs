using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktail
{
    public class BarContext : DbContext
    {
        public BarContext(): base()
        {
            //Make data in database. Will make the database start from new every time. remove this to save changes when closing program.
            Database.SetInitializer(new BarDBInitializer());
        }
        public DbSet<Cocktail> Cocktails { get; set; }
        public DbSet<Liquor> Liquors { get; set; }
        
    }
}
