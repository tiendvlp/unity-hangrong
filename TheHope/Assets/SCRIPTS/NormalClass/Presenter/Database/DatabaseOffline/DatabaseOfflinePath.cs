using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseOfflinePath : IDatabaseOfflinePath {
private readonly string DbEditorPath = Application.dataPath + "/StreamingAssets/DatabaseOffline/" + "DatabaseOffline.db";
    private readonly string DbAndroidIOSPath = Application.persistentDataPath + "/DatabaseOffline" + "/DatabaseOffline.db";
    public string getPath()
    {
#if UNITY_EDITOR
        var dbPath = DbEditorPath;
#else
        var filepath = DbAndroidIOSPath;
        System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/DatabaseOffline");
        var dbPath = filepath;
#endif
		return dbPath;
    }
}
