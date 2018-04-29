using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api.Requests;
public class RegisterPresenter {
	private IRegisterView view;

	public RegisterPresenter (IRegisterView view) {
		this.view = view;
	}

	public void Register (string userName, string password) {
		if (CheckInputInfo(userName, password))
		{
			new RegistrationRequest().SetUserName(userName).SetPassword(password).SetDisplayName("admin").Send((response) => {
				if (response.HasErrors)
				{
					OnRegisterFailed();
					return;
				}

				OnRegisterSuccess();
			});
		}
	}

	public void OnRegisterSuccess() {
		view.ProcessUI_RegisterSuccess ();
		//...
	}

	public void OnRegisterFailed () {
		view.ProcessUI_RegisterFailed ();
		//...
	}

	private bool CheckInputInfo (string userName, string password)
	{
		// Check if the userName is Null
		if ((userName.Equals("")) || (userName.Equals(null)) || !(userName.Contains("@"))) {
			return false;
		}

		// Check if the password is Null
		if ((password.Equals("")) || (password.Equals(null)))
		{
			return false;
		}

		// Check if the id containt special character ( ^, &, *, ...);
		char[] arr = userName.ToCharArray();
		for (int i = 0; i < arr.Length; i ++)
		{
			byte c = (byte) arr[i];
			if ((InRange(c, 30, 45)) || (InRange(c, 58, 63) || InRange(c, 91, 96)) || InRange(c, 123, 126) || c == 47)
			{
				return false;
			}
		}

		// Check if password length is less than 6
		if (password.Length < 6)
		{
			return false;
		}

		return true;
	}


	private bool InRange (byte number, byte min, byte max)
	{
		if ((number >= min) && (number <= max)) return true ;

		return false;
	}		
}




