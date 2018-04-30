using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : MonoBehaviour {
	public InputField userName, password;
	private LoginPresenter loginPresenter;

	public delegate void OnLoginGameSparksButtonClick(string userName, string password);
	public event OnLoginGameSparksButtonClick onGameSparksLoginButtonClick;

	public delegate void OnLoginFacebookButtonClick();
	public event OnLoginFacebookButtonClick onFacebookLoginButtonClick;

	void Start () {
		loginPresenter = new LoginPresenter (this);
		loginPresenter.onLoginSuccess += OnLoginSuccess;
		loginPresenter.onLoginFailed += OnLoginFailed;
	}

	public void OnLoginSuccess () {
	
	}

	public void OnLoginFailed (string error) {

	}

	public void FacebookLogin_ButtonClick () {
		onFacebookLoginButtonClick ();
	}

	public void GameSparksLogin_ButtonClick () {
		onGameSparksLoginButtonClick (userName.text, password.text);
	}
}
