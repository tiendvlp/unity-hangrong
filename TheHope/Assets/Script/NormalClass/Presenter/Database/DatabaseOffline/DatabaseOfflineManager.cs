using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseOfflineManager : IDatabaseOfflineManager
{
	private IDatabaseOfflineWriter write;
	private DatabaseOfflineReader read;
    private IDatabaseOfflinePath path;

    public DatabaseOfflineManager () {
        path = new DatabaseOfflinePath();
		write = new DatabaseOfflineWriter (path);
        read = new DatabaseOfflineReader(path.getPath());
    }
    public T get<T>(int id)
    {
        return read.getDataById<T>(id);
    }

    public List<T> getAllData<T>()
    {
        return read.getAllData<T>();
    }

    public string writeDatabaseToStorage()
    {
        return write.write();
    }

    public string getPath () {
        return path.getPath();
    }
}
