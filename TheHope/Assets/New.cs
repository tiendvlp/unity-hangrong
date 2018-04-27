using GameSparks.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class New : MonoBehaviour {

    // Use this for initialization
    void Start() {
        Debug.Log("json String: " + JSONObject.CreateStringObject("Anh cũng muốn được hạnh phúc"));
        ConvertObjToGSData convert = new ConvertObjToGSData();
        ditmeem em = new ditmeem();
        em.ls.Insert(2, "cc");
        Debug.Log(convert.converFromObj(em).JSON);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class ditmeem
{
    public string name = "didi";
    public string properties = "cave";
    public string love;
    public string fuckyou;
    public List<string> ls = new List<string>(100);
}
