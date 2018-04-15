using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
public class DatabaseOfflineReader : IDatabaseOfflineReader, IDatabaseOffline {
    private readonly string connectionString = "URI=file:" + Application.dataPath + "/Data/DatabaseOffline/DatabaseOffline.db"; 

    public T getDataById<T> (int id) {
        var constructor = typeof(T).GetConstructors()[0];
        var dataB = constructor.Invoke(null);
        IData dataA = (IData) dataB;
        using (IDbConnection dbConnect = new SqliteConnection(connectionString)) {
            dbConnect.Open();
            using (IDbCommand cmd = dbConnect.CreateCommand()) {
                string cmdQuery = "select * from " + dataA.getTable() + " where ID = " + id;
                cmd.CommandText = cmdQuery;
                using (IDataReader reader = cmd.ExecuteReader()) {
                    if (reader.Read()) {
                        setData (dataA, reader);
                    }
                    reader.Close();
                }
            }
            dbConnect.Close();
        }
        return (T) dataB;
    } 

    private void setData(IData dataA, IDataReader reader) {
        foreach (var field in dataA.GetType().GetFields()) {
            int indexColumn = reader.GetOrdinal(field.Name);
            if (indexColumn != -1) {
                if (field.FieldType == typeof (string)) {
                    field.SetValue(dataA, reader.GetString(indexColumn));
                } 
                else if (field.FieldType ==  typeof(int)) {
                    field.SetValue(dataA, reader.GetInt32(indexColumn));
                }
                else if (field.FieldType ==  typeof(float) || field.GetType() == typeof(double)) {
                    field.SetValue(dataA, reader.GetDouble(indexColumn));
                }
                else if (field.FieldType == typeof(bool)) {
                    bool result; 
                    bool.TryParse(reader.GetString(indexColumn), out result);
                    field.SetValue(dataA, result);
                }
            }
        }
    }

    public List<T> getAllData<T> () {
        List<T> result = new List<T>();
        var constructor = typeof(T).GetConstructors()[0];
        var dataB = constructor.Invoke(null);
        IData dataA = (IData)dataB;
        using (IDbConnection dbConnect = new SqliteConnection(connectionString))
        {
            dbConnect.Open();
            using (IDbCommand cmd = dbConnect.CreateCommand())
            {
                string cmdQuery = "select * from " + dataA.getTable();
                cmd.CommandText = cmdQuery;
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read()) {
                        dataB = constructor.Invoke(null);
                        dataA = (IData)dataB;
                        setData(dataA, reader);
                        result.Add((T)dataA);
                    }
                    reader.Close();
                }
            }
            dbConnect.Close();
        }
        return result;   
    }
}
