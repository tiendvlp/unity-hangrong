using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecoveryView : MonoBehaviour, IRecoveryView {
	public InputField userName, token, newPassword;
	private RecoveryPresenter presenter;

	void Start () {
		presenter = new RecoveryPresenter (this);
	}

	public void OnRecoveryButtonClick () {
		presenter.StartRecovery (userName.text);
	}

	public void OnResetPasswordButtonClick (){
		presenter.ResetPassword (token.text, newPassword.text);
	}

	public void ProcessUI_ResetPasswordSuccess (){

	}

	public void ProcessUI_ResetPasswordFailed (){

	}

	public void ProcessUI_RecoverySuccess (){
		
	}

	public void ProcessUI_RecoveryFailed () {

	}


}
