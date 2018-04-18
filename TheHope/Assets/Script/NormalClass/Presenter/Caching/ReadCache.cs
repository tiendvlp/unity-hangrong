using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
 
public class ReadCache : IReadCache, ICaching {
	public T read<T> (string cacheFolder, string nameNonExtention) {
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream stream = File.Open(cacheFolder+"/" +nameNonExtention, FileMode.Open);
		T result = (T) formatter.Deserialize(stream);
		return result;
	}
}
