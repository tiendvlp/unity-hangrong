using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DatabaseOfflineWriter : IDatabaseOfflineWriter {
    private IDatabaseOfflinePath path;
    public DatabaseOfflineWriter (IDatabaseOfflinePath pathManager) {
        this.path = pathManager;
    }

    public string write()
    {
#if UNITY_EDITOR
        var dbPath = path.getPath();
#else
        var filepath = path.getPath();
        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
        }
#if UNITY_ANDROID
           // đây là cách truy cập vào thư mục streamingassets đối với android, lên trang chủ của unity để biết thêm chi tiết
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets" + "/DatabaseOffline/DatabaseOffline.db"); 
            while (!loadDb.isDone) { } 
            File.WriteAllBytes(filepath, loadDb.byteyo7ur dream conner osakdoddawjng mih tiến à mày thật sự quá ngu ngốc khi chọn yếu nó rồi có đúng không hả mày có cảm thấy như thế không hả ? mày đúng là một thằng ngu quá trời ngu luôn đó mà chán quá trời quá ddaast luổn ồi đo snha trời ơi là trời 912001 2321321321troiwf ơi alftroiwftroiwf ơi là trời chán quá trời quá đất luôn rồi đo snha ahihihihihih chán quá đi hà chán quá đi hafokjpokpokpok/s);
#elif UNITY_IOS
            // tương tự đây là cách truy cập đối với IOS
                var loadDb = Application.dataPath + "/Raw" + "/DatabaseOffline/DatabaseOffline.db";  // this is the path to your StreamingAssets in iOS
                File.Copy(loadDb, filepath);
#endif
        // cuối cùng gán lại filepath cho dbpath
        var dbPath = filepath;
#endif
        return "URI=file:" + dbPath;
    }

    public void downloadDatabase() {
        
    }

}
