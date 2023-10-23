using System;
using System.Collections.Generic;
using System.Text;


public class DataName
{
    public List<Row> Table { get; set; }
    public string Table_Name { get; set; }
    public DataName() { }
    public DataName(string table)
    {
        Table_Name = table;
        Table = Access.getObjects(SQL_Queries.Select(table));
    }
    public DataName(string table,Condition condition)
    {
        Table_Name = table;
        Table = Access.getObjects(SQL_Queries.Select(table,condition));
    }
    public DataName(string table, List<Condition> conditions,string type)
    {
        Table_Name = table;
        Table = Access.getObjects(SQL_Queries.Select(table, conditions,type));
    }
    public void Join(string table)
    {
        Table = Access.getObjects(SQL_Queries.SelfJoin(Table_Name, table, Table[0].GetColumes()[0].GetField()));
    }
    public void Separate(string table)
    {
        Table = Access.getObjects(SQL_Queries.Seperate(Table_Name, table, Table[0].GetColumes()[0].GetField()));
    }
    public void RemoveDuplicate(DataName data)
    {
        foreach(Row r in data.Table)
        {
            string id = r.GetColValue(0).ToString();
            foreach(Row row in Table)
                if(row.GetColValue(0).ToString()==id)
                {
                    Table.Remove(row);
                    break;
                }
        }
    }
    public List<string> getNames(List<int> indexes)
    {
        List<string> names = new List<string>();
        string name;
        foreach(Row r in Table)
        {
            name = "";
            foreach (int i in indexes)
                name += r.GetColValue(i).ToString() + " ";
            names.Add(name);
        }
        return names;
    }
    public List<string> getNames(List<string> fields)
    {
        List<string> names = new List<string>();
        string name;
        foreach (Row r in Table)
        {
            name = "";
            foreach (string i in fields)
                name += r.GetColValue(i).ToString() + " ";
            names.Add(name);
        }
        return names;
    }
    public List<string> getNames(int index)
    {
        List<string> names = new List<string>();
        foreach (Row r in Table)
            names.Add(r.GetColValue(index).ToString());
        return names;
    }
    public object GetColValueFromRow(int row,string field) { return Table[row].GetColValue(field); }
    public object GetColValueFromRow(int row,int index) { return Table[row].GetColValue(index); }

    public List<string> getNames(string field)
    {
        List<string> names = new List<string>();
        foreach (Row r in Table)
            names.Add(r.GetColValue(field).ToString());
        return names;
    }
}