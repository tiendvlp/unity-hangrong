using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Facebook.Unity;

public class LoginView : MonoBehaviour {
	
	public InputField userName, password;

	public Toggle rememberThisAccount;

	private LoginPresenter loginPresenter;

	public ErrorView error_manager;

	public bool isRememberAccount;


	void Start () {
		if (!FB.IsInitialized) FB.Init();
		loginPresenter = new LoginPresenter (this);
		loginPresenter.onLoginSuccess += OnLoginSuccess;
		loginPresenter.onLoginFailed += OnLoginFailed;
	}

	public void OnLoginSuccess () {
		isRememberAccount = rememberThisAccount.isOn;
		Debug.Log ("Login Success");
	}

	public void OnLoginFailed (string error) {
		Debug.Log ("Error: " + error);
		error_manager.showError (error);
	}

	public void LoginWithGameSparks () {
		
		loginPresenter.GSLogin (userName.text, password.text);
	}

	public void LoginWithFacebook () {
		loginPresenter.FBLogin ();
	}

	public void Register () {
		SceneManager.LoadScene ("Register");
	}

	public void Recovery () {
		SceneManager.LoadScene ("Recovery");
	}

}
