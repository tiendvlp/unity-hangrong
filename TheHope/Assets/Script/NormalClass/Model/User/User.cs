using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User {
	public Information information;

	public WareHouse wareHouse;

	public List<Employee> employees;

	public TownStreet townStreet;

	public HomeStreet homeStreet;

	public PersonalChat personalChat;

	public class Information {

		public string displayName;

		public int dollar;

		public int goldCoin;

		public int level;

		public string linkToFBAccount;

		public int Apower;

		public int Dpower;

		public Equipment currentEquipment;

		public List<AncillaryItem> ancillaryItems;
	}
		
}
