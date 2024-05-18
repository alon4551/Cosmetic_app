using Cosmetic_App.Utiltes;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cosmetic_App.Tables
{
    public class backup:DB_Object
    {//backup object in DB TO income table
        public backup():base(Database_Names.Backup,Database_Names.Backup_Columes) {
            Table = Database_Names.Backup;
        }
        public backup(Income income):base(Database_Names.Backup, Database_Names.Backup_Columes)
        {//create new backup object in the income information
            Table = Database_Names.Backup;
            Value = income.Value;
            foreach (Col col in income.Row.Columes)
                SetColValue(col.GetField(), col.GetValue());
        }
        
    }
}
