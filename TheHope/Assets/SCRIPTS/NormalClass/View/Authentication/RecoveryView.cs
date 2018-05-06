using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecoveryView : MonoBehaviour{
	public InputField userName, token, newPassword;
	public GameObject recoveryView, resetPasswordView ;
	public ErrorView error_manager;

	private RecoveryPresenter presenter;

	void Start () {
		presenter = new RecoveryPresenter (this);
		presenter.onRecoverySuccess += OnRecoverySuccess;
		presenter.onRecoveryFailed += OnRecoveryFailed;
		presenter.onResetPasswordSuccess += OnResetPasswordSuccess;
		presenter.onResetPasswordFailed += OnResetPasswordFailed;
	
		recoveryView.SetActive (true);
		resetPasswordView.SetActive(false);
	}

	public void OnRecoveryButtonClick () {
		presenter.StartRecovery (userName.text);
	}

	public void OnResetPasswordButtonClick (){
		presenter.ResetPassword (token.text, newPassword.text);
	}

	public void OnResetPasswordSuccess (){
		Debug.Log ("Reset Password Success");

	}

	public void OnResetPasswordFailed (string error){
		error_manager.showError (error);
	}

	public void OnRecoverySuccess (){
		Debug.Log ("Recovery Success");
		recoveryView.SetActive (false);
		resetPasswordView.SetActive (true);
	}

	public void OnRecoveryFailed (string error) {
		error_manager.showError (error);
	}

	public void OnBackButtonClick () {
		SceneManager.LoadScene ("Login");
	}


}
