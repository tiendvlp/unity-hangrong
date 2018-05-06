using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using GameSparks.Api.Requests;

public class LoginPresenter : ILogin{

	public LoginView view;

	public delegate void OnLoginSuccess ();
	public event OnLoginSuccess onLoginSuccess;

	public delegate void OnLoginFailed (string error);
	public event OnLoginFailed onLoginFailed;

	public LoginPresenter (LoginView view) {
		this.view = view;
	}

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
		new AuthenticationRequest().SetUserName(email).SetPassword(password).Send((response) => {
			if (response.HasErrors)
			{
				onLoginFailed(response.Errors.ToString());
				return;
			}
			onLoginSuccess();
		});
	}
}
