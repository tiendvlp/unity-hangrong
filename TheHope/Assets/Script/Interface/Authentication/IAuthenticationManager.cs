using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAuthenticationManager {
    void LoginWithGS(string email, string password);
    void LoginWithFB();
    void Register(string email, string password);
    void setupUserInfo(string phoneNum, string displayName, bool male);
    void ChangePassword(string newPassword);
    void ResetPassword(string email, string token, string newPassword);
    void SendEmailToken(string email);
}
