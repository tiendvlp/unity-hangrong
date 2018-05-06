using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;
public class WriteCache : IWriteCache
{
   private CachePath path;
   public WriteCache () {
           path = new CachePath();
   }

    public void write (string FileNameNonExtension, object data) {
        using (FileStream write = File.Open(path.getPath(FileNameNonExtension), FileMode.OpenOrCreate)) {
                BinaryFormatter binary = new BinaryFormatter();
                binary.Serialize(write, data);
        }
    }
}