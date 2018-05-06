using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginView : MonoBehaviour {
	public InputField userName, password;
	private LoginPresenter loginPresenter;


	void Start () {
		loginPresenter = new LoginPresenter (this);
		loginPresenter.onLoginSuccess += OnLoginSuccess;
		loginPresenter.onLoginFailed += OnLoginFailed;
	}

	public void OnLoginSuccess () {
		Debug.Log ("Login Success");
	}

	public void OnLoginFailed (string error) {
		Debug.Log ("Error: " + error);
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
