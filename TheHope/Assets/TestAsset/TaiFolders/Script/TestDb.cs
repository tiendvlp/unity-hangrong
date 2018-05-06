using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDb : MonoBehaviour {
	public Text text;
	DatabaseOfflineReader reader;
	void Start () {
		reader = new DatabaseOfflineReader ();		
		WeaponInfo info = reader.getDataById<WeaponInfo> (1);
		text.text = "power: " + info.APower;
	}

	public void Add () {

			

	}
	
}
