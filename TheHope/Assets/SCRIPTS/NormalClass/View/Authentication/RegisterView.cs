using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegisterView : MonoBehaviour{

	private RegisterPresenter presenter;
	public InputField userName, password;
	public ErrorView error_manager;

	void Start () {
		presenter = new RegisterPresenter();
		presenter.onRegisterFailed += OnRegisterFailed;
		presenter.onRegisterSuccess += OnRegisterSuccess;
	}

	public void OnRegisterButtonClick () {
		presenter.Register (userName.text, password.text);
	}

	public void OnRegisterSuccess () {
		Debug.Log ("Register Success");
	}

	public void OnRegisterFailed (string error) {
		error_manager.showError (error);
	}

	public void OnBackButtonClick () {
		SceneManager.LoadScene ("Login");
	}

}
