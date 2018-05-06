using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDatabaseOfflineReader {
    T getDataById<T>(int id);
    List<T> getAllData<T>();
    
}
