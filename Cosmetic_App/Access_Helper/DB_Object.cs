using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;

public class DB_Object //represend a record in a table access
{
    public Row Row { get; set; } = new Row(); //the list of Cols in a row object
    public string Table { get; set; }//name of the table
    public string Field { get; set; } //key field
    public object Value { get; set; } = null; // key value
    public DB_Object(Row row)//copying record
    {
        Table = row.Table;
        Row = row;
        Value = row.GetColValue(0);
        Field = row.Columes[0].GetField();
    }
    public DB_Object(DB_Object dB_Object)//copying record
    {
        Row = dB_Object.Row;
        Table = dB_Object.Table;
        Field = dB_Object.Field;
        Value = dB_Object.Value;
    }
    public DB_Object(string table, List<Col> Cols)//copying record
    {
        Row = new Row(Cols);
        Table = table;
        Value = Cols[0].GetValue() ;
        Field = Cols[0].GetField();
    }
    public DB_Object(string table,Row r)//copying record
    {
        Row = r;
        Table = table;
        Value = r.GetColValue(0);
        Field = r.Columes[0].GetField();
    }
    public DB_Object(string table, List<string> fields)//creating new record
    {
        Table = table;
        Field = fields[0];
        Row.Columes=new List<Col>();
        foreach (string filed in fields)
            Row.AddColume(new Col(filed, null));
    }
    public static object GetColValue(string table, List<string> fields,string id,string field)//getting value form access database
    {
        DB_Object db = new DB_Object(table,fields);
        if(!db.Grab(id))
            return null;
        else
            return db.GetColValue(field);
    }
    public void AddCol(string field,object value)// adding a col into the object
    {
        Row.Columes.Add(new Col(field, value));
    }
    public void SetColValue(int index,object value) //seting col value into object row
    {
        Row.Columes[index].Set(value);
    }
    public void SetColValue(string field, object value) //seting col value into object row
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
    public List<DB_Object> GrabAll()//getting all records from a spesific table in DB access
    {
        List<DB_Object> objects = new List<DB_Object>();
        foreach(Row r in Access.getObjects(SQL_Queries.Select(Table)))
            objects.Add(new DB_Object(Table, r));
        return objects;
    }
    public List<DB_Object> Grab_Join(DB_Object otherObject) //joining 2 connected tables by comment field 
    {
        List<Row> list= Access.getObjects(SQL_Queries.SelfJoin(Table, otherObject.Table, Field));
        List<DB_Object> objects= new List<DB_Object>();
        foreach (Row r in list)
            objects.Add(new DB_Object(Table,r));
        return objects;
    }
    public static List<DB_Object> GrabAll(string Table) //getting all records from a spesific table in DB access
    {
        List<DB_Object> records = new List<DB_Object>();
        foreach (Row row in Access.getObjects(SQL_Queries.Select(Table)))
            records.Add(new DB_Object(Table, row));
        return records;
    }
    public bool Grab(object id)//getting 1 record from  DB access by id
    {
        List<Row> rows = Access.getObjects(SQL_Queries.Select(Table, new Condition(Field, id)));
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
    public List<DB_Object> Grab(List<string> fileds, List<object> ids, string Table)//getting records from  DB access by multiple conditions 
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

    public List<DB_Object> Grab(string filed, object id, string Table)//getting records from  DB access by 1 condition
    {
        List<Row> Rows = Access.getObjects(SQL_Queries.Select(Table, new Condition(filed, id)));
        List<DB_Object> objects = new List<DB_Object>();
        foreach(Row r in Rows)
            objects.Add(new DB_Object(Table, r));
        return objects;
    }
    public List<DB_Object> Grab(List<Col> Values, string Table) //getting records from  DB access by multiple conditions
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

    public bool IsExist() // checks if object is exist in DB
    {
        if(Value == null) return false;
        List<Row> rows = Access.getObjects(SQL_Queries.Select(Table, new Condition(Field, Value)));
        foreach (Row r in rows)
            if (r.GetColValue(0).ToString() == Value.ToString())
                return true;
        return false;
    }
    public bool IsExist(object id)// checks if object by id is exist in DB
    {
        List<Row> rows = Access.getObjects(SQL_Queries.Select(Table, new Condition(Field, id)));
        foreach (Row r in rows)
            if (r.GetColValue(0).ToString() == id.ToString())
                return true;
        return false;
    }
    public bool Update()//update access record by object data
    {
        if (Value == null) Value = Row.Columes[0].GetValue();
        if (Value == null)
        {
            Value = GetNewIndex();
            SetColValue(0, Value);
        }
        Row r = Row;
       // r.DeleteColume(0);
        string query = SQL_Queries.Update(Table, r.Columes, new Condition(Field, Value));
        
        if (IsExist(Value))
            return Access.Execute(query);
        else
            return Insert();
        
    }
    public bool Insert()//inseting new object into db
    {
        Value = GetNewIndex();
        SetColValue(0, Value);
        string query = SQL_Queries.Insert(Table, Row.Columes);
        if(Access.Execute(query))
        {
            Value = Row.GetColValue(0);
            return true;
        }
        return false;
    }
    public List<Col> GetCols()//return all ocjects fields and values
    {
        return Row.Columes;
    }
    public bool Delete()//deleting object form DB
    {
        string query = SQL_Queries.Delete(Table, new Condition(Row.Columes[0]));
        return Access.Execute(query);
    }
    public int GetNewIndex()//getting new index to new object in table
    {
        List<Row> rows = Access.getObjects(SQL_Queries.SelectAndOrderBy(Table, Row.Columes[0].GetField()));
        if (rows.Count == 0) return 0;
        return (int)rows[rows.Count-1].GetColValue(0)+1;
    }
    public bool IsEmpty()//cheking if at least 1 field is empty 
    {
        foreach (Col c in Row.Columes)
            if (c.GetValue() != null)
                return false;
        return true;
    }
    public void Reload()//reload data from access DB
    {
        Grab(Value);
        
    }
}
