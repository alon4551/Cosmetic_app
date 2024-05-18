using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Drawing;
public class Access
{
    private static string ConnectionStr = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=db.accdb;Persist Security Info=False;";
    private static string Error;
    public static OleDbCommand OleCommand;
    public static OleDbConnection Connection = new OleDbConnection(ConnectionStr);
    public static OleDbDataReader Reader;
    public static void ConnectionState(bool state)//open's or close the connection to the DB
    {

        try
        {
            if (state)
                Connection.Open();
            else
                Connection.Close();
        }
        catch (Exception err)
        {

        }
    }



    public static bool Execute(string command)//executeing the command
    {
        try
        {
            ConnectionState(true);
            OleCommand = new OleDbCommand(command, Connection);
            OleCommand.ExecuteReader();
        }
        catch (Exception err)
        {
            Error = err.Message;
            ConnectionState(false);
            return false;
        }
        return true;

    }
    public static string ExplaindError()//explaing error if query failds
    {
        return Error;
    }
    public static List<Row> getObjects(string command)//return DB records as List<Row> acording to query
    {
        List<Row> Rows = new List<Row>();
        try
        {
            ConnectionState(true);
            OleCommand = new OleDbCommand(command, Connection);
             Reader = OleCommand.ExecuteReader();
            while (Reader.Read())
            {
                Row row = new Row();
                var table = Reader.GetSchemaTable();
                var nameCol = table.Columns["ColumnName"];
                var fields = new List<string>();
                foreach (DataRow r in table.Rows)
                {
                    fields.Add(r[nameCol].ToString());
                }
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    row.AddColume(new Col(fields[i], Reader[i]));
                }
                Rows.Add(row);
            }
            Reader.Close();
            return Rows;

        }
        catch(Exception err)
        {
            Error = err.Message;
            ConnectionState(false);
            return null;
        }

    }

}