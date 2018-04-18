using System;
using System.Collections;
using System.Collections.Generic;
using GameSparks;
using GameSparks.Core;
using UnityEngine;
public class ConvertGSToObj {
	public T fromGSData<T> (GSData gsData) {
		if (typeof(T).Name != gsData.GetString("type")) {
			Debug.LogError("This type of T does not match with type of gsData");
			return  default(T);
		}
		Type objType = Type.GetType (gsData.GetString ("type"));
		object obj = Activator.CreateInstance (objType);
		foreach (var typeField in objType.GetFields ()) {
			if (!typeField.IsNotSerialized && gsData.ContainsKey (typeField.Name))

			{
				if (typeField.FieldType == typeof (string)) {
					typeField.SetValue (obj, gsData.GetString (typeField.Name));
				} else if (typeField.FieldType == typeof (int)) {
					typeField.SetValue (obj, (int) gsData.GetNumber (typeField.Name).Value);
				} else if (typeField.FieldType == typeof (float)) {
					typeField.SetValue (obj, (float) gsData.GetFloat (typeField.Name).Value);
				} else if (typeField.FieldType == typeof (bool)) {
					typeField.SetValue (obj, gsData.GetBoolean (typeField.Name));
				} else if (typeField.FieldType == typeof (DateTime)) {
					typeField.SetValue (obj, gsData.GetDate (typeField.Name));
				} else if ((typeField.FieldType == typeof (List<string>) || typeField.FieldType == typeof (string[]))) {
					typeField.SetValue (obj, (typeField.FieldType == typeof (List<string>)) ? (object) gsData.GetStringList (typeField.Name) : gsData.GetStringList (typeField.Name).ToArray ());
				} else if ((typeField.FieldType == typeof (List<int>) || typeField.FieldType == typeof (int[]))) {
					typeField.SetValue (obj, (typeField.FieldType == typeof (List<int>)) ? (object) gsData.GetIntList (typeField.Name) : gsData.GetIntList (typeField.Name).ToArray ());
				} else if ((typeField.FieldType == typeof (List<float>) || typeField.FieldType == typeof (float[]))) {
					typeField.SetValue (obj, (typeField.FieldType == typeof (List<float>)) ? (object) gsData.GetFloatList (typeField.Name) : gsData.GetFloatList (typeField.Name).ToArray ());
				} else if (typeField.FieldType.IsClass && !typeField.FieldType.IsGenericType && !typeField.FieldType.IsArray) {
					typeField.SetValue (obj, fromGSData<T> (gsData.GetGSData (typeField.Name)));
				} else if (!typeField.FieldType.IsArray && typeof (IList).IsAssignableFrom (typeField.FieldType)) {
					IList genericList = Activator.CreateInstance (typeField.FieldType) as IList;
					foreach (GSData gsDataElem in gsData.GetGSDataList (typeField.Name)) {
						object elem = fromGSData<T> (gsDataElem);
						genericList.Add (elem);
					}
					typeField.SetValue (obj, genericList);
				} else if (typeField.FieldType.IsArray) {
					List<GSData> gsArrayData = gsData.GetGSDataList (typeField.Name);
					Array newArray = Array.CreateInstance (typeField.FieldType.GetElementType (), gsArrayData.Count);
					object[] objArray = new object[gsArrayData.Count];
					for (int i = 0; i < gsArrayData.Count; i++) {
						objArray[i] = fromGSData<T> (gsArrayData[i]);
					}
					Array.Copy (objArray, newArray, objArray.Length);
					typeField.SetValue (obj, newArray);
				}
			}
		}
		return (T) obj;
	}

}