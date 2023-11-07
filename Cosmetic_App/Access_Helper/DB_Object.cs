using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;

public class DB_Object
{
    public Row Row { get; set; } = new Row();
    public string Table { get; set; }
    public string Id { get; set; } 
    public object Value { get; set; } = null;
    public static object GetColValue(string table, List<string> fields,string id,string field)
    {
        DB_Object db = new DB_Object(table,fields);
        if(!db.Grab(id))
            return null;
        else
            return db.GetColValue(field);
    }
    public DB_Object(DB_Object dB_Object)
    {
        Row = dB_Object.Row;
        Table = dB_Object.Table;
        Id = dB_Object.Id;
        Value = dB_Object.Value;
    }
    public DB_Object(string table, List<Col> Cols)
    {
        Row = new Row(Cols);
        Table = table;
        Value = Cols[0].GetValue() ;
        Id = Cols[0].GetField();
    }

    public DB_Object(string table,Row r)
    {
        Row = r;
        Table = table;
        Value = r.GetColValue(0);
        Id = r.Columes[0].GetField();
    }
    public DB_Object(string table, List<string> fields)
    {
        Table = table;
        Id = fields[0];
        Row.Columes=new List<Col>();
        foreach (string filed in fields)
            Row.AddColume(new Col(filed, null));
    }
    public void SetColValue(int index,object value) 
    {
        Row.Columes[index].Set(value);
    }
    public void SetColValue(string field, object value) 
    {
        foreach (Col col in Row.Columes)
            if (col.GetField() == field)
                col.Set(value);
    }
    public object GetColValue(string field)
    {
        return Row.GetColValue(field);
    }
    public object GetColValue(int index)
    {
        return Row.GetColValue(index);
    }
    public void ClearValues()
    {
        foreach (Col col in Row.GetColumes())
            col.Set(col.GetField(), null);
    }
    public List<DB_Object> GrabAll()
    {
        List<DB_Object> objects = new List<DB_Object>();
        foreach(Row r in Access.getObjects(SQL_Queries.Select(Table)))
            objects.Add(new DB_Object(Table, r));
        return objects;
    }
    public List<DB_Object> Grab_Join(DB_Object otherObject)
    {
        List<Row> list= Access.getObjects(SQL_Queries.SelfJoin(Table, otherObject.Table, Id));
        List<DB_Object> objects= new List<DB_Object>();
        foreach (Row r in list)
            objects.Add(new DB_Object(Table,r));
        return objects;
    }
    public static List<DB_Object> GrabAll(string Table)
    {
        List<DB_Object> records = new List<DB_Object>();
        foreach (Row row in Access.getObjects(SQL_Queries.Select(Table)))
            records.Add(new DB_Object(Table, row));
        return records;
    }
    public  bool Grab(object id)
    {
        List<Row> rows = Access.getObjects(SQL_Queries.Select(Table, new Condition(Id, id)));
        foreach (Row r in rows)
        {
            if (r.GetColValue(0).ToString() == id.ToString())
            {
                Row.Columes = r.GetColumes();
                Value = r.GetColValue(0);
                return true;
            }
        }
        return false;
    }
    public List<DB_Object> Grab(List<string> fileds, List<object> ids, string Table)
    {
        List<Condition> conditions = new List<Condition>();
        for(int i = 0; i < fileds.Count; i++)
            conditions.Add(new Condition(fileds[i], ids[i]));
        List<Row> Rows = Access.getObjects(SQL_Queries.Select(Table,conditions,"AND"));
        List<DB_Object> objects = new List<DB_Object>();
        foreach (Row r in Rows)
            objects.Add(new DB_Object(Table, r));
        return objects;
    }
    public List<DB_Object> Grab(string filed, object id, string Table)
    {
        List<Row> Rows = Access.getObjects(SQL_Queries.Select(Table, new Condition(filed, id)));
        List<DB_Object> objects = new List<DB_Object>();
        foreach(Row r in Rows)
            objects.Add(new DB_Object(Table, r));
        return objects;
    }
    public List<DB_Object> Grab(List<Col> Values, string Table)
    {
        List<Condition> conditions = new List<Condition>();
        foreach (Col col in Values)
            conditions.Add(new Condition(col));
        List<Row> Rows = Access.getObjects(SQL_Queries.Select(Table, conditions,"AND"));
        List<DB_Object> objects = new List<DB_Object>();
        foreach (Row r in Rows)
            objects.Add(new DB_Object(Table, r));
        return objects;
    }

    public bool IsExist()
    {
        if(Value == null) return false;
        List<Row> rows = Access.getObjects(SQL_Queries.Select(Table, new Condition(Id, Value)));
        foreach (Row r in rows)
            if (r.GetColValue(0).ToString() == Value.ToString())
                return true;
        return false;
    }
    public bool IsExist(object id)
    {
        List<Row> rows = Access.getObjects(SQL_Queries.Select(Table, new Condition(Id, id)));
        foreach (Row r in rows)
            if (r.GetColValue(0).ToString() == id.ToString())
                return true;
        return false;
    }
    public bool Update()
    {
        if (Value == null) Value = Row.Columes[0].GetValue();
        string query = SQL_Queries.Update(Table, Row.Columes, new Condition(Id, Value));
        
        if (IsExist(Value))
            return Access.Execute(query);
        else
            return Insert();
        
    }
    public bool Insert()
    {
        string query = SQL_Queries.Insert(Table, Row.Columes);
        if(Access.Execute(query))
        {
            Value = Row.GetColValue(0);
            return true;
        }
        return false;
    }
    public List<Col> GetCols()
    {
        return Row.Columes;
    }
    public bool Delete()
    {
        string query = SQL_Queries.Delete(Table, new Condition(Row.Columes[0]));
        return Access.Execute(query);
    }
    public int GetNewIndex()
    {
        List<Row> rows = Access.getObjects(SQL_Queries.Select(Table));
        if (rows.Count == 0) return 0;
        return (int)rows[rows.Count-1].GetColValue(0)+1;
    }
    public bool IsEmpty()
    {
        foreach (Col c in Row.Columes)
            if (c.GetValue() != null)
                return false;
        return true;
    }
   
}
