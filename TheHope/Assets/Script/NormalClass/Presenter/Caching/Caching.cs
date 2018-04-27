using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caching {

    public JSONObject cache(string path, JSONObject value, List<string> whichIsArray) {
        //string json = "{\"Information\":{\"DisplayName\":null,\"Dollar\":null,\"GoldCoin\":null,\"Level\":null,\"LinkToFBAccount\":null,\"AcillaryItem\":{\"ItemId\":{\"startTime\":null,\"Expired\":null}},\"CurrentEquipment\":{\"Pants\":{\"id\":null},\"Shirt\":{\"id\":null},\"Shoe\":{\"id\":null},\"Hat\":{\"id\":null},\"Car\":{\"id\":null},\"weapon\":{\"id\":null}}}}"
        string[] pathChild = path.Split('/');
        JSONObject js = JSONObject.Create("");
        for (int i = 0; i < pathChild.Length-1; i++)
        {
            if (whichIsArray.Exists(x=>x.Equals(pathChild[i])))
            {
                if (!js.HasField(pathChild[i]))
                {
                    js.AddField(pathChild[i], "[]");
                }
                
            }
                if (js.HasField(pathChild[i]))
                {
                    js = js[pathChild[i]];
                } else
                {
                    Debug.Log(i);
                    js.AddField(pathChild[i], JSONObject.Create("{}"));
                    js = js[pathChild[i]];
                       Debug.Log(js[pathChild[i]]);
            }
            if (js.IsArray)
            {
                int index = -1;
                bool b = int.TryParse(pathChild[i], out index);
                if (b)
                {
                    js = js[index];
                }
            }
        }
            js.SetField(pathChild[pathChild.Length - 1], value);
        return js;
    }
    
}
