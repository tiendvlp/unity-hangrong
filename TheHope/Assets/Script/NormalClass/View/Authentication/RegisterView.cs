using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterView : MonoBehaviour{
	private RegisterPresenter presenter;
	public InputField userName, password;

	void Start () {
		presenter = new RegisterPresenter (this);
	}

	public void OnRegisterButtonClick () {
		presenter.Register (userName.text, password.text);
	}

	public void ProcessUI_RegisterSuccess () {
	
	}

	public void ProcessUI_RegisterFailed () {
	
	}

}
