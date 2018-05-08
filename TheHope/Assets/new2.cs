using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using GameSparks.Core;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Compression;
using Ionic.Zip;

public class new2 : MonoBehaviour {
<<<<<<< HEAD
    public Text text;
    void Start() {
        GetData getData = new GetData();
        var login = new GameSparks.Api.Requests.AuthenticationRequest();
        login.SetUserName("tien912001").SetPassword("tiendvlp").Send(call => {
            getData.onGetDataFromGameSparkComplete += getGS;
            getData.getData("Information", "912001123", "Account");

        });
    }

    private void getGS (GetData.Result result )
    {
        if (!result.hasErrors) {
            Debug.Log(result.jsonData.ToString());
        }
        else {
            Debug.Log(result.Errors.GetString("ERROR"));
        }
    }

    void Update() {
    }

    public IEnumerator TestDownload(string url, string savepath)
    {
        WWW www = new WWW(url);
        while (!www.isDone)
        {
            yield return null; 
        }
        byte[] bytes = www.bytes;
        using (FileStream write = File.Create(savepath))
        {
            write.Write(bytes, 0, bytes.Length);
        }
            Debug.Log("Done" + www.isDone);

        ZipUtil.Unzip(Application.dataPath + "/StreamingAssets/DatabaseOffline/Databasezip.zip", Application.dataPath + "/StreamingAssets/DatabaseOffline");
    }


    private void upzipFile(string input, string output) {
        
    }

=======
	public Text text;
	void Start () {
		CachingManager cac = new CachingManager();
        DatabaseOfflineManager mama = new DatabaseOfflineManager();
        mama.writeDatabaseToStorage();
        GetComponent<Text>().text = "write";
        DatabaseOfflinePath p = new DatabaseOfflinePath();
        GetComponent<Text>().text =  mama.get<WeaponInfo>(1).PrefabPath + "";
        cac.save("Fuckyou2", new ditmeem());       
		ditmeem d = cac.get<ditmeem>("Fuckyou2");
	}
	
>>>>>>> 4f32c0b0be3c674efb6f7e4fd7bdcbf68e527165
}

