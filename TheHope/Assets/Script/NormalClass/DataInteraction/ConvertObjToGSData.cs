using System;
using System.Collections;
using System.Collections.Generic;
using GameSparks;
using GameSparks.Api;
using GameSparks.Core;
using UnityEngine;

public class ConvertObjToGSData {
	public GSRequestData converFromObj (object obj) {
		GSRequestData gsData = new GSRequestData ();
		gsData.Add ("type", obj.GetType ().ToString ());

		foreach (var field in obj.GetType ().GetFields ()) {
			if (field.FieldType == typeof (string)) {
				gsData.AddString (field.Name, field.GetValue (obj).ToString ());
			} else if (field.FieldType == typeof (bool)) {
				gsData.AddBoolean (field.Name, bool.Parse (field.GetValue (obj).ToString ()));
			} else if (field.FieldType == typeof (int)) {
				gsData.AddNumber (field.Name, (int) Convert.ToInt32 (field.GetValue (obj)));
			} else if (field.FieldType == typeof (float) || field.GetValue (obj).GetType () == typeof (double)) {
				gsData.AddNumber (field.Name, Double.Parse (field.GetValue (obj).ToString ()));
			} else if (field.FieldType == typeof (List<string>) || field.GetValue (obj).GetType () == typeof (string[])) {
				gsData.AddStringList (field.Name, (field.FieldType == typeof (List<string>)) ? field.GetValue (obj) as List<string> : new List<string> (field.GetValue (obj) as string[]));
			} else if (field.FieldType == typeof (List<int>) || field.GetValue (obj).GetType () == typeof (int[])) {
				gsData.AddNumberList (field.Name, (field.FieldType == typeof (List<int>)) ? field.GetValue (obj) as List<int> : new List<int> (field.GetValue (obj) as int[]));
			} else if (field.FieldType == typeof (List<float>) || field.GetValue (obj).GetType () == typeof (float[])) {
				gsData.AddNumberList (field.Name, (field.FieldType == typeof (List<float>)) ? field.GetValue (obj) as List<float> : new List<float> (field.GetValue (obj) as float[]));
			} else if (field.FieldType == typeof (DateTime)) {
				gsData.AddDate (field.Name, (DateTime) field.GetValue (obj));
			} else if (field.FieldType.IsClass && !field.FieldType.IsGenericType && !field.FieldType.IsArray) {	
				gsData.AddObject (field.Name, converFromObj (field.GetValue (obj)));
			} else if (field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition () == typeof (List<>)) {
				List<GSData> gsDataList = new List<GSData> ();
				foreach (var elem in field.GetValue (obj) as IList) {
					gsDataList.Add (converFromObj (elem));
				}
				gsData.AddObjectList (field.Name, gsDataList);
			} else if (field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition () == typeof (List<>) || field.FieldType.IsArray) {
				List<GSData> gsDataList = new List<GSData> ();
				foreach (var elem in field.GetValue (obj) as IList) {
					gsDataList.Add (converFromObj (elem));
				}
				gsData.AddObjectList (field.Name, gsDataList);
			}
		}
		return new GSRequestData(gsData.JSON);
	}
}