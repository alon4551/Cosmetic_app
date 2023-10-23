using Cosmetic_App.Utiltes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic_App.Tables
{
    public class Treatments : DB_Object
    {
        public Treatments():base(Database_Names.Treatments, Database_Names.Treatment_Columes) { }
        public Treatments(int id):base(Database_Names.Treatments, Database_Names.Treatment_Columes) 
        {
            Grab(id);
        }

    }
}
