using System.Collections;
using System.Collections.Generic;
using GameSparks.Core;
using UnityEngine;
using UnityEngine.UI;
public class new2 : MonoBehaviour {
	public Text text;
	void Start () {
		CachingManager cac = new CachingManager();
        DatabaseOfflineManager mama = new DatabaseOfflineManager();
        mama.t = GetComponent<Text>();
        mama.writeDatabaseToStorage();
        GetComponent<Text>().text = "write";
        DatabaseOfflinePath p = new DatabaseOfflinePath();
        GetComponent<Text>().text =  mama.get<WeaponInfo>(1).PrefabPath + "";
        cac.save("Fuckyou2", new ditmeem());       
		ditmeem d = cac.get<ditmeem>("Fuckyou2");
	}
	
}
