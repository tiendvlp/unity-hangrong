using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
public class FeetInfo : IData {
    public int ID;
    public string PrefabPath;
    public int Luxurious;
    public int APower;
    public int DPower;
    public int SellingSkill;
    public int Price;

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
