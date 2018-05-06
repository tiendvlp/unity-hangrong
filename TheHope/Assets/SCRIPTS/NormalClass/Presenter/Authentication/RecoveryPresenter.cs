using System;
using GameSparks.Api.Requests;
using GameSparks.Core;
using UnityEngine;


public class RecoveryPresenter : IRecovery {	
	private string PASSWORD_RECOVERY_REQUEST_ACTION = "passwordRecoveryRequest";
	private string RESET_PASSWORD_ACTION = "resetPassword";
	private string ACTION = "action";
	private string TOKEN = "token";
	private string ERROR = "error";
	private string SUCCESS = "success";
	private RecoveryView view;
	private static GSRequestData scriptData;
	private string sentEmail;

	public delegate void OnRecoverySuccess ();
	public event OnRecoverySuccess onRecoverySuccess;

	public delegate void OnRecoveryFailed (string error);
	public event OnRecoveryFailed onRecoveryFailed;

	public delegate void OnResetPasswordSuccess ();
	public event OnResetPasswordSuccess onResetPasswordSuccess;

	public delegate void OnResetPasswordFailed (string error);
	public event OnResetPasswordFailed onResetPasswordFailed;

	public RecoveryPresenter (RecoveryView view) {
		this.view = view;
	}

	public void StartRecovery (string userName) {
		scriptData = new GSRequestData();
		scriptData.AddString(ACTION, PASSWORD_RECOVERY_REQUEST_ACTION);

		new AuthenticationRequest().SetUserName(userName).SetPassword("").SetScriptData(scriptData).Send((response) => {
			GSData error = (GSData) response.JSONData["error"];
			string action = error.GetString("action");
			if (action != "Complete") {
				onRecoveryFailed(action);
				return;
			}

			sentEmail = userName;
			onRecoverySuccess();
		});
	}

	public void ResetPassword (string token, string newPassword) {
		scriptData = new GSRequestData();
		scriptData.AddString(ACTION, RESET_PASSWORD_ACTION);
		scriptData.AddString (TOKEN, token);

		new AuthenticationRequest().SetUserName(sentEmail).SetPassword(newPassword).SetScriptData(scriptData).Send((response) => { 
			GSData error = (GSData) response.JSONData["error"];
			string action = error.GetString("action");
			if (action != "complete. Error: null") {
				onResetPasswordFailed(action);
				return;
			}

			onResetPasswordSuccess();
		});
	}

}

