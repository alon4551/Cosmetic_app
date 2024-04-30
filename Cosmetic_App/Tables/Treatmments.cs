using Cosmetic_App.Utiltes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic_App.Tables
{
    public class Treatments : DB_Object
    {
        public static List<Treatments> All = GrabAll();
       
        public Treatments():base(Database_Names.Treatments, Database_Names.Treatment_Columes) { }
        public Treatments(int id):base(Database_Names.Treatments, Database_Names.Treatment_Columes) 
        {
            Grab(id);

        }
        public Treatments(DB_Object obj) : base(obj) { Table = Database_Names.Treatments; }
        public string GetDuration()
        {
            return GetColValue("duration").ToString();
        }
        public static List<Treatments> GrabAll()
        {
            List<Treatments> treatments = new List<Treatments>();
            List<DB_Object> list = GrabAll(Database_Names.Treatments);
            foreach (DB_Object obj in list)
                treatments.Add(new Treatments(obj));
            return treatments;
        }
        public static Treatments GetTreatment(int id)
        {
            foreach(Treatments treatment in All)
                if((int)treatment.Value == id)
                    return treatment;
            return null;
        }

        internal static void ReloadList()
        {
            All = GrabAll();
        }
    }
}
