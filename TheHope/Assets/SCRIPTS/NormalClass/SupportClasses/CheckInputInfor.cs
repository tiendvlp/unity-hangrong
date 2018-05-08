using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInputInfor {
	public string error;

	public bool IsValidInfor(string userName, string password)
	{
		return IsValidUserName(userName) && IsValidPassword(password);
	}

	public bool IsValidUserName (string userName) {
		// Check if the userName is Null
		if ((userName.Equals("")) || (userName.Equals(null)) || !(userName.Contains("@"))) {
			error = "Email not specified";
			return false;
		}

		// Check if the id containt special character ( ^, &, *, ...);
		char[] arr = userName.ToCharArray();
		for (int i = 0; i < arr.Length; i ++)
		{
			byte c = (byte) arr[i];
			if ((InRange(c, 30, 45)) || (InRange(c, 58, 63) || InRange(c, 91, 96)) || InRange(c, 123, 126) || c == 47)
			{
				error = "Invalid username, it should not contain special character (" + arr [i] + ")";
				return false;
			}
		}

		return true;
	}

	public bool IsValidPassword(string password) {
		// Check if the password is Null
		if ((password.Equals("")) || (password.Equals(null)))
		{
			error = "Password field is empty. Please check again";
			return false;
		}

		// Check if password length is less than 6
		if (password.Length < 6)
		{
			error = "Password length must be more than 6";
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
