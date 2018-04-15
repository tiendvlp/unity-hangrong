using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
public class FeetInfo : IData {
    public int ID { private set; get; }
    public string PrefabPath { private set; get; }
    public int Luxurious { private set; get; }
    public int APower { private set; get; }
    public int DPower { private set; get; }
    public int SellingSkill { private set; get; }
    public int Price { private set; get; }

    public void setData(IDataReader reader)
    {
        ID = reader.GetInt32(0);
        PrefabPath = reader.GetString(1);
        APower = reader.GetInt32(2);
        DPower = reader.GetInt32(3);
        Luxurious = reader.GetInt32(4);
        SellingSkill = reader.GetInt32(5);
        Price = reader.GetInt32(6);
    }

    public string getTable()
    {
        return HR.tableName.Feet;
    }

    public string getPrefabPath()
    {
        return PrefabPath;
    }
}
