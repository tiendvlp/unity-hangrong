
using System.Collections.Generic;

public interface IDatabaseOfflineManager {
    string writeDatabaseToStorage();
    T get<T> (int id);
    List<T> getAllData<T> ();
}
