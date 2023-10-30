using Cosmetic_App.Utiltes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic_App.Tables
{
    public class Products : DB_Object
    {
        public Products():base(Database_Names.Products, Database_Names.Product_Columes) { }
        public Products(int id):base(Database_Names.Products, Database_Names.Product_Columes) 
        {
            Grab(id);
        }

    }
}
