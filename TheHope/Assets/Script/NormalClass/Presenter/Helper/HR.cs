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

    public class CachePath {
        public class Android_IOS
        {
          public static readonly string Folder = Storage.Android_IOS + "/Cache";
          public static readonly string UserInfo = Folder + "/UserInfo.txt";
          public static readonly string WareHouse = Folder + "/WareHouse.txt";
          public static readonly string Employee = Folder + "/Employee.txt";
          public static readonly string TownStreet = Folder + "/TownStreet.txt";
          public static readonly string HomeStreet = Folder + "/HomeStreet.txt";

        }

        public class Editor
        { 
            public static readonly string Folder = Application.dataPath + "/StreamingAssets/Cache";
            public static readonly string UserInfo = Application.dataPath + "/StreamingAssets/Cache/651651561.txt";
            public static readonly string WareHouse = Application.dataPath + "/StreamingAssets/Cache/WareHouse.txt";
            public static readonly string Employee = Application.dataPath + "/StreamingAssets/Cache/Employee.txt";
            public static readonly string TownStreet = Application.dataPath + "/StreamingAssets/Cache/TownStreet.txt";
            public static readonly string HomeStreet = Application.dataPath + "/StreamingAssets/Cache/HomeStreet.txt";
        }
    }

    public class DatabaseOfflinePath
    {
            public static readonly string Editor = Application.dataPath + "/StreamingAssets/DatabaseOffline/" + "DatabaseOffline.db";
            public static readonly string Android_IOS = Storage.Android_IOS + "/DatabaseOffline.db";
    }

    public class Storage {
        public static readonly string Android_IOS = Application.persistentDataPath;
    }

    public class StreamingAssets {
        public static readonly string Android = "jar:file://" + Application.dataPath + "!/assets";
        public static readonly string IOS = Application.dataPath + "/Raw";
        public static readonly string Editor = Application.dataPath + "/StreamingAssets";
    }

    public static string databaseOfflineName = "DatabaseOffline.db";
    public class CacheFileName
    {
        public static readonly string UserInfo = "UserInfo.txt";
        public static readonly string WareHouse = "WareHouse.txt";
        public static readonly string Employee = "Employee.txt";
        public static readonly string TownStreet = "TownStreet.txt";
        public static readonly string HomeStreet = "HomeStreet.txt";
    }

}
