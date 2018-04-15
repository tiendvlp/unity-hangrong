using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DatabaseOfflineReader reader = new DatabaseOfflineReader();
		WeaponInfo wi = reader.getDataById<WeaponInfo>(1);
	}	
}
