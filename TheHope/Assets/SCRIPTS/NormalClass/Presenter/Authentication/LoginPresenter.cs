using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using GameSparks.Api.Requests;
using GameSparks.Core;

public class LoginPresenter : ILogin{

	private static string UNRECOGNISED_DETAILS = "UNRECOGNISED";
	private static string WRONG_EMAIL = "Wrong Email";
	private static string TRUE_EMAIL = "True Email";

	private LoginView view;

	public delegate void OnLoginSuccess ();
	public event OnLoginSuccess onLoginSuccess;

	public delegate void OnLoginFailed (string error);
	public event OnLoginFailed onLoginFailed;

	public LoginPresenter (LoginView view) {
		this.view = view;
	}

	public CheckInputInfor info_check = new CheckInputInfor();

	public LoginPresenter () {}
		
	public void FBLogin () {
		FB.LogInWithReadPermissions(new List<string>() {"public_profile", "email", "display_name"}, (result) => { 
			if ((result.Cancelled) || (result.Error != null)) {
				onLoginFailed(result.Error);
				return;
			}

			new FacebookConnectRequest().SetAccessToken(result.AccessToken.TokenString).Send((response) => {
				if (response.HasErrors) {
					onLoginFailed(result.Error);
					return;
				}
				onLoginSuccess();
			});
		});
	}

	public void GSLogin (string email, string password) {
		if (info_check.IsValidInfor(email, password)) {
			new AuthenticationRequest().SetUserName(email).SetPassword(password).Send((response) => {
				if (response.HasErrors)
				{	
					GSData error = (GSData) response.JSONData["error"];
					if (error.GetString("DETAILS") == UNRECOGNISED_DETAILS ) {

						GSData data = (GSData) response.JSONData["scriptData"];

						string message = data.GetString("message");

						if (message == WRONG_EMAIL) onLoginFailed("Your username is not found");

						else if (message == TRUE_EMAIL) onLoginFailed("Your password is not true");

						return;
					}

				}
				onLoginSuccess();
			});
		} else {
			onLoginFailed (info_check.error);
		}
	}
}
