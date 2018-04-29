using System;
using GameSparks.Api.Requests;
using GameSparks.Core;
using UnityEngine;


public class RecoveryPresenter {	
	private string PASSWORD_RECOVERY_REQUEST_ACTION = "passwordRecoveryRequest";
	private string RESET_PASSWORD_ACTION = "resetPassword";
	private string ACTION = "action";
	private string TOKEN = "token";
	private string ERROR = "error";
	private string SUCCESS = "success";
	private IRecoveryView view;
	private static GSRequestData scriptData;
	private static string sentEmail;


	public RecoveryPresenter (IRecoveryView view) {
		this.view = view;
	}

	public void StartRecovery (string userName) {
		scriptData = new GSRequestData();
		scriptData.AddString(ACTION, PASSWORD_RECOVERY_REQUEST_ACTION);

		new AuthenticationRequest().SetUserName(userName).SetPassword("admin").SetScriptData(scriptData).Send((response) => {
			if (response.HasErrors)
			{
				OnRecoveryAcountFailed();
				return;
			}

			Debug.Log(response.ScriptData.GetString(ERROR));
			OnRecoveryAcountSuccess();
		});
	}

	public void ResetPassword (string token, string newPassword) {
		scriptData = new GSRequestData();
		scriptData.AddString(ACTION, RESET_PASSWORD_ACTION);
		scriptData.AddString (TOKEN, token);

		new AuthenticationRequest().SetUserName("admin").SetPassword(newPassword).SetScriptData(scriptData).Send((response) => { 
			if (response.HasErrors) {
				OnResetPasswordFailed ();
				return;
			}	

			OnResetPasswordSuccess ();
		});
	}

	void OnRecoveryAcountSuccess ()
	{
		view.ProcessUI_RecoverySuccess ();
	}

	void OnRecoveryAcountFailed ()
	{
		view.ProcessUI_RecoveryFailed ();
	}

	void OnResetPasswordSuccess ()
	{
		view.ProcessUI_ResetPasswordSuccess ();
	}

	void OnResetPasswordFailed ()
	{
		view.ProcessUI_ResetPasswordFailed ();
	}

}

