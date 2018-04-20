using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GetConnectionString
{
    public string getConnectionString()
    {
#if UNITY_EDITOR
        // nếu đang ở Editor thì bình thường không gì cả
        var dbPath =  Application.dataPath + "/StreamingAssets/" + "DatabaseOffline.db";
        // nhưng nếu không ở editor => đang chạy trên máy thật mà ở đây là android hoặc ios thì cần phải chép qua storage của tụi nó
#else
        // đây là đường dẫn để truy cập vào storage nếu không sử dụng Editor
        var filepath = string.Format(Application.persistentDataPath + "/DatabaseOffline.db");
        // kiểm tra xem thằng database có tồn tại trong phần storage của mấy nền tảng khác chưa
        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");

#if UNITY_ANDROID
           // đây là cách truy cập vào thư mục streamingassets đối với android, lên trang chủ của unity để biết thêm chi tiết
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/DatabaseOffline.db"); 
            while (!loadDb.isDone) { } 
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
            // tương tự đây là cách truy cập đối với IOS
                var loadDb = Application.dataPath + "/Raw/DatabaseOffline.db";  // this is the path to your StreamingAssets in iOS
                File.Copy(loadDb, filepath);
#endif
}
        // cuối cùng gán lại filepath cho dbpath
        var dbPath = filepath;
#endif
        return "URI=file:"+dbPath;
    }
}
