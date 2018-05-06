using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CachePath : MonoBehaviour {
public readonly string CacheEditorFolderPath = Application.dataPath + "/Data/Cache";
public readonly string CacheAndroidIOSFolderPath = Application.persistentDataPath + "/Cache";

    public string getPath(string FileNameNonExtension) {
#if UNITY_EDITOR
        var filePath = CacheEditorFolderPath + (FileNameNonExtension != "" ? ("/" + FileNameNonExtension + ".dat") : "");
        System.IO.Directory.CreateDirectory(CacheEditorFolderPath);  
        return filePath;
#else
	var filePath = "";
    filePath = CacheAndroidIOSFolderPath + (FileNameNonExtension != "" ? ("/" + FileNameNonExtension + ".dat") : "");
    System.IO.Directory.CreateDirectory(CacheAndroidIOSFolderPath);  
#endif
		return filePath;
    }
}
