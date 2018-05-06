using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
 
public class ReadCache :  IReadCache {
	private CachePath path;
    public ReadCache () {
        path = new CachePath();
    }
    public T read<T> (string FileNameNonExtension) {
        if (File.Exists(path.getPath(FileNameNonExtension))) {
			using (FileStream read = File.OpenRead(path.getPath(FileNameNonExtension))) {
                BinaryFormatter binary = new BinaryFormatter();
                T result = (T) binary.Deserialize(read);
                return result;
            }
        } else {
            Debug.Log("Your cache file does not exist");
    		return default(T);
        }
    }
}
