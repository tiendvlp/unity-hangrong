using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class CachingManager : ICachingManager {
	private IWriteCache write;
	private IReadCache read;
	private IClearCache clear;

	public CachingManager () {
		write = new WriteCache();
		read = new ReadCache();
		clear = new ClearCache();
	}

	public void deleteCache (string key) {
		clear.clear(key);
	}

	public void clearAllCache () {
		clear.clearAll();
	}

	public void save (string key, object value) {
		write.write(key, value);
	}

	public T get<T> (string key) {
		T data = read.read<T>(key);
		return data;
	}	
}
