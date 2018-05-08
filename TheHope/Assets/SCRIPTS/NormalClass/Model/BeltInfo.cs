using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System;

[Serializable]
public class BeltInfo : IData {
    public int ID;
    public string PrefabPath;
    public int Luxurious;
    public int APower;
    public int DPower;
    public int SellingSkill;
    public int Price;

    public void setData(IDataReader reader) {
        
    }

    public string getTable()
    {
        return HR.tableName.Belt;
    }

}
