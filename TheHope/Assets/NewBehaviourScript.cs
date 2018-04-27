using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using GameSparks.Core;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour {

	void Start () {
      DatabaseOfflineReader reader = new DatabaseOfflineReader();
      WeaponInfo info = reader.getDataById<WeaponInfo>(1);
      GetComponent<Text>().text = info.APower + " \n" + info.DPower+" \n"  + info.PrefabPath+" \n";
  }	
}
[Serializable]
class aaa : IData {
	public string name = "tien dang";

    public string getTable()
    {
		return "";
    }

    public void setData(IDataReader reader)
    {
    }
}
