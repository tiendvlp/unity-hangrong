using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using GameSparks.Core;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour {

	void Start () {
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
