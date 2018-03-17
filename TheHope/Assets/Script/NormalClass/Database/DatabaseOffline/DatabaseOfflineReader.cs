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
                    while(reader.Read()) {
                        dataA.setData(reader);
                    }
                    reader.Close();
                }
            }
            dbConnect.Close();
        }
        return (T) dataB;
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
                        dataA.setData(reader);
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
