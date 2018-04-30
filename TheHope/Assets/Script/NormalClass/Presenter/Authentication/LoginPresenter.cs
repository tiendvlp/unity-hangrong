using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using GameSparks.Api.Requests;

public class LoginPresenter {
	private ILoginView view;

	 delegate void fuck ();
	 event fuck abc;
	public LoginPresenter () {
		
	}

	public LoginPresenter (ILoginView view) {
		this.view = view;
	}
		
	public void FBLogin () {
		FB.LogInWithReadPermissions(new List<string>() {"public_profile", "email", "display_name"}, (result) => { 
			if ((result.Cancelled) || (result.Error != null)) {
				OnLoginFailed();
				return;
			}

			new FacebookConnectRequest().SetAccessToken(result.AccessToken.TokenString).Send((response) => {
				if (response.HasErrors) {
					OnLoginFailed();
					return;
				}

				OnLoginSuccess();
			});
		});
	}

	public void GSLogin (string email, string password) {
		new AuthenticationRequest().SetUserName(email).SetPassword(password).Send((response) => {
			if (response.HasErrors)
			{
				OnLoginFailed();
				return;
			}
			OnLoginSuccess();
		});
	}

	public void OnLoginSuccess() {
		view.ProcessUI_LoginSuccess();
		//...
	}

	public void OnLoginFailed() {
		view.ProcessUI_LoginFailed ();
		//...
	}

}
