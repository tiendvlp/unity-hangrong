using System.Collections;
using System.Collections.Generic;
using System;
using System.Data;
using Mono.Data.Sqlite;
public interface  IData {
    void setData(IDataReader reader);
    string getTable();
}
