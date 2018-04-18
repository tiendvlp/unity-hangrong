using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public class WriteCache : IWriteCache, ICaching
{
    public void write(object data, string cacheFolder, string nameNonExtension)
    {
        Stream stream = File.Open(cacheFolder + "/" + nameNonExtension, FileMode.Create);
		BinaryFormatter formatter = new BinaryFormatter();
		formatter.Serialize(stream, data);
		stream.Close();
    }
}