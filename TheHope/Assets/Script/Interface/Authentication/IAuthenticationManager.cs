using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAuthenticationManager {
    void LoginWithGS(string email, string password);
    void LoginWithFB();
    void Register(string email, string password);
    void SetupUserInfo(string phoneNum, string displayName, string male);
	void ChangePassword(string newPassword, string oldPassword);
    void ResetPassword(string email, string token, string newPassword);
    void RecoveryAccount(string email);
}
