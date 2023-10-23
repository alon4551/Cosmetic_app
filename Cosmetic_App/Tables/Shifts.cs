using Cosmetic_App.Utiltes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic_App.Tables
{
    public class Shifts:DB_Object
    {
        public Shifts(): base(Database_Names.Shifts, Database_Names.Shifts_Columes) { }
        public Shifts(List<object> values): base(Database_Names.Shifts, Database_Names.Shifts_Columes) 
        {
            for(int i = 0; i < this.Row.Columes.Count(); i++)
                SetColValue(i, values[i]);
        }

    }
}
