using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserInfoCreatingView{
	void OnOKButtonClick ();

	void ProcessUI_CreateInfoSuccess ();

	void ProcessUI_CreateInfoFailed ();
}
