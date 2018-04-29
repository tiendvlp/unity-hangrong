using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfoCreatingView : MonoBehaviour, IUserInfoCreatingView {
	public InputField displayName, phoneNumber;
	public Toggle maleToggle, femaleToggle;
	private UserInfoCreatingPresenter presenter;


	public void OnOKButtonClick () {
		string sex = maleToggle.isOn ? "male" : "female";
		presenter.SetUpUserInfo (displayName.text, phoneNumber.text, sex);

	}

	public void ProcessUI_CreateInfoSuccess () {
	
	}

	public void ProcessUI_CreateInfoFailed () {
	
	}

}
