using GameSparks.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class New : MonoBehaviour {

    // Use this for initialization
    void Start() {
        DatabaseOfflineReader reader = new DatabaseOfflineReader();
        reader.t = GetComponent<Text>();
        WeaponInfo info = reader.getDataById<WeaponInfo>(1);
        GetComponent<Text>().text = info.PrefabPath;
        JSONObject js = new JSONObject("{\"arr\":[\"abc\", \"xyz\"]}");
        js["arr"].AddField("1", "tiendang");
        GSRequestData data = new GSRequestData(js.ToString());
        Caching cache = new Caching();
        JSONObject str = cache.cache("Info/name/ahihi/fuck", JSONObject.CreateStringObject("Minhtien"), new List<string>());
        Debug.Log(str.ToString());
        Debug.Log(data.GetStringList("arr"));
        Debug.Log(js.IsArray);
        Debug.Log(js.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
