using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : MonoBehaviour, ILoginView {
	public InputField userName, password;
	private LoginPresenter loginPresenter; 

	void Start () {
		loginPresenter = new LoginPresenter (this);
	}
	
	public void OnLoginGameSparksButtonClick () {
		loginPresenter.GSLogin (userName.text, password.text);
	}

	public void	OnLoginFacebookButtonClick () {
		loginPresenter.FBLogin ();
	}

	public void ProcessUI_LoginSuccess () {
	
	}

	public void ProcessUI_LoginFailed () {
	
	}
}
