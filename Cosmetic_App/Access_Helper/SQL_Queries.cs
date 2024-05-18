using Cosmetic_App.Access_Helper;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;

public class SQL_Queries //giving me the correct string syntax sql queries, Each Function return is a sql query
{
   
    private static string SQL_Syntax(object item)//return correct string syntax by values types
    {
        if(item == null) return "";
        switch (item.GetType().ToString())
        {

            case "System.String":
                {
                    return $"'{item.ToString()}'";

                }
            case "System.DateTime":
                {
                    DateTime time = (DateTime)item;
                    return $"#{time.Day}-{time.Month}-{time.Year}#";
                }
            default:
                {
                    return $"{item.ToString()}";
                }
        }
    }
    private static string SQL_Syntax(Col value)
    {
        return $"{value.GetField()} = {value.Value_SQL_Syntax()}";
    } 

    public static string Insert(string table,List<Col> cols)
    {
        string values = "";
        foreach (Col item in cols)
        {
            values += $"{SQL_Syntax(item.GetValue())},";
        }
        return $"insert into {table} values({values.Trim(',')});";
    }
    public static string Insert(string table, List<object> list)
    {
        string values = "";
        foreach (object item in list)
        {
                values += $"{SQL_Syntax(item)},";
        }
        return $"insert into {table} values({values.Trim(',')});";
    }
    public static string Update(string table, List<Col> Updated_Values,List<Condition> Conditions,string ConditionType)
    {
        string values =Col.Values_SQL_Syntax(Updated_Values,","),selector= Condition.SQL_Syntax(Conditions,ConditionType);
        return $"update {table} set {values} where {selector};";
    }
    public static string Update(string table, List<Col> Updated_Values, Condition Condition)
    {
        string values = Col.Values_SQL_Syntax(Updated_Values,",");
        return $"update {table} set {values.Trim(',')} where {Condition.SQL_Syntax()};";
    }
    public static string Delete(string table, List<Condition> Condition,string Contition_Type)
    {
        return $"delete from {table} where {(global::Condition.SQL_Syntax(Condition, Contition_Type))}";
    }
    public static string Delete(string table,Condition Condition)
    {
        return $"delete from {table} where {Condition.SQL_Syntax()};";
    }
    public static string Select_And_Sort(string table,string field,string value)
    {
        return $"select * from {table} where {new Condition(field,value).SQL_Syntax()} order by {field};";
    }

    public static string Select(string table,List<string>Columns,List<Condition> Conditions,string ConditionType)
    {
        return $"select {Col.Values_SQL_Syntax(Columns, ",")} from {table} where {Condition.SQL_Syntax(Conditions, ConditionType)};";
    }
    public static string Select(string table, List<Condition> Conditions, string ConditionType)
    {
        return $"select * from {table} where {Condition.SQL_Syntax(Conditions, ConditionType)};";
    }
    public static string Select(string table, Condition Condition)
    {
        return $"select * from {table} where {Condition.SQL_Syntax()};";
    }
    public static string Select(string table,string keyfield, DateTime start,DateTime end)
    {
        return $"select * from {table} where {keyfield} between {SQL_Syntax(start)} and {SQL_Syntax(end)};";
    }
    public static string Select(string table)
    {
        return $"select * from {table};";
    }
    public static string SelectAndOrderBy(string table,string keyfield)
    {
        return $"select * from {table} order by {keyfield};";
    }
    public static string Select(string table,List<string> Columes)
    {
        return $"select {Col.Values_SQL_Syntax(Columes,",")} from {table};";
    }
    public static string LeftOuterJoin(string MainTable,string InharetTable,string commonField)
    {
        return $"select * from {MainTable} LEFT OUTER JOIN {InharetTable} on {MainTable}.{commonField} = {InharetTable}.{commonField};";
    }
    public static string SelfJoin(string MainTable, string InharetTable, string commonField)
    {
        return $"select * from {MainTable},{InharetTable} where {MainTable}.{commonField} = {InharetTable}.{commonField};";
    }
    public static string Join(Row MainTable, List<Row> SeconderyTables)//the seco
    {
        string query = $"select * from {MainTable.Table}, ";
        foreach(Row R in SeconderyTables)
        {
            query += $"{R.Table}, ";
        }
        query += $"from {MainTable.Table} ";
        for(int i = 0; i < MainTable.Columes.Count; i++)
        {
            query += $"JOIN {SeconderyTables[i].Table} ON {MainTable.Table}.{MainTable.Columes[i].GetField()} = {SeconderyTables[i].Table}.{SeconderyTables[i].Columes[0].GetField()}";
        }
        return query+=";";
    }
    public static string Join(Row MainTable, List<Row> SeconderyTables, Col Condition)//the seco
    {
        string query = $"select * from {MainTable.Table} ";
        for (int i = 0; i < MainTable.Columes.Count; i++)
        {
                if (SeconderyTables[i].Additional_Name=="")
                    query += $"JOIN {SeconderyTables[i].Table} ON {MainTable.Table}.{MainTable.Columes[i].GetField()} = {SeconderyTables[i].Table}.{SeconderyTables[i].Columes[0].GetField()} ";
                else
                    query += $"JOIN {SeconderyTables[i].Table} AS {SeconderyTables[i].Additional_Name} ON {MainTable.Table}.{MainTable.Columes[i].GetField()} = {SeconderyTables[i].Table}.{SeconderyTables[i].Columes[0].GetField()} ";
        }
        return query += $"where {MainTable.Table}.{Condition.GetField()} = {SQL_Syntax(Condition.GetValue())};";
    }
    public static string Seperate(string MainTable, string Sparate, string commonfield)
    {
        return $"select * from {MainTable} where {commonfield} not in (select {commonfield} from {Sparate});";
    }
    public static string SeperateAndOrder(string MainTable, string Sparate, string commonfield,string keyfield)
    {
        return $"select * from {MainTable} where {commonfield} not in (select {commonfield} from {Sparate}) order by {keyfield};";
    }
}


