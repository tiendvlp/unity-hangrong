using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api.Requests;

public class UserInfoCreatingPresenter : IUserInfoCreating {
	public static string SET_UP_FIRST_USER = "SetupFirstUser";
	public static string DISPLAY_NAME = "DisplayName";
	public static string SEX = "Sex";
	public static string PHONE_NUMBER = "PhoneNumber";

	public delegate void OnFirstLoginFailed(string error);
	public event OnFirstLoginSuccess onFirstLoginSuccess;

	public delegate void OnFirstLoginSuccess(string displayName);
	public event OnFirstLoginSuccess onFirstLoginFailed;

	private UserInfoCreatingView view;

	public void SetUpUserInfo (string displayName, string phoneNumber, string male) {
		new LogEventRequest().SetEventKey(SET_UP_FIRST_USER)
			.SetEventAttribute(DISPLAY_NAME, displayName)
			.SetEventAttribute(PHONE_NUMBER, phoneNumber)
			.SetEventAttribute(SEX, male).Send((response) => {

				if (response.HasErrors)
				{
					onFirstLoginFailed(response.Errors.ToString());
					return;
				}
			});

		onFirstLoginSuccess (displayName);
	}
}
