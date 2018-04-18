using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HR {
    public class tableName {
        public static readonly string Torso = "Torso";
        public static readonly string Hands = "Hands";
        public static readonly string Outer = "Outer";
        public static readonly string Weapon = "Weapon";
        public static readonly string Hair = "Hair";
        public static readonly string Hat = "Hat";
        public static readonly string GauzeMask = "GauzeMask";
        public static readonly string Belt = "Belt";
        public static readonly string Eyes = "Eyes";
        public static readonly string Glass = "Glass";
        public static readonly string Mask = "Mask";
        public static readonly string Legs = "Legs";
        public static readonly string Feet = "Feet";
    }

    public class dataType {
        public static readonly string UserInfo = "UserInfo";
        public static readonly string WareHouse = "WareHouse";
        public static readonly string Employee = "Employee";
        public static readonly string TownStreet = "TownStreet";
        public static readonly string HomeStreet = "HomeStreet";
    }

    public class CacheFolder {
        public static readonly string UserInfo = Application.dataPath + "/Data/Cache/UserInfo";
        public static readonly string WareHouse = Application.dataPath + "/Data/Cache/WareHouse";
        public static readonly string Employee = Application.dataPath + "/Data/Cache/Employee";
        public static readonly string TownStreet = Application.dataPath + "/Data/Cache/TownStreet";
        public static readonly string HomeStreet = Application.dataPath + "/Data/Cache/HomeStreet";
    }

}
