using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api.Requests;
using GameSparks.Core;


public class RegisterPresenter : IRegister {


	public delegate void OnRegisterSuccess ();
	public event OnRegisterSuccess onRegisterSuccess;

	public delegate void OnRegisterFailed (string error);
	public event OnRegisterFailed onRegisterFailed;

	private CheckInputInfor inputInforChecker = new CheckInputInfor();

	public RegisterPresenter () {

	}

	public void Register (string userName, string password) {
		if (inputInforChecker.IsValidInfor (userName, password)) {
			new RegistrationRequest ().SetUserName (userName).SetPassword (password).SetDisplayName("").Send ((response) => {
				if (response.HasErrors) {
					GSData error = (GSData) response.JSONData["error"];
					if (error.GetString("USERNAME") == "TAKEN") onRegisterFailed ("Your username was taken, please choose another");
					Debug.Log(response.JSONString);
					return;
				}

				onRegisterSuccess ();
			});
		} else {
			onRegisterFailed (inputInforChecker.error);
		}
	}


}




