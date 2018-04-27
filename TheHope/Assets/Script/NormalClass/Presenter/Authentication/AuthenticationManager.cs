using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;
using Facebook.Unity;
using GameSparks.Core;

public class AuthenticationManager : MonoBehaviour, IAuthenticationManager
{
	public InputField UserNameText, PasswordText, OldPasswordText, DisplayName;
    public Text StatusText;
 
	public static string PASSWORD_RECOVERY_REQUEST_ACTION = "passwordRecoveryRequest";
	public static string RESET_PASSWORD_ACTION = "resetPassword";
	public static string ACTION = "action";
	public static string TOKEN = "token";
	public static string ERROR = "error";
	public static string SUCCESS = "success";
	public static string SET_UP_FIRST_USER = "SetupFirstUser";
	public static string DISPLAY_NAME = "DisplayName";
	public static string SEX = "Sex";
	public static string PHONE_NUMBER = "PhoneNumber";

	public static GSRequestData scriptData;




	private void Start () {

		if (!(FB.IsInitialized)) FB.Init ();

	}


    public void Register(string email, string password)
    {
        // nếu đăng ký thành công thì chuyển scene sang màn hình điền thông tin user
        // và gọi setupUserInfo
        if (CheckInputInfo(UserNameText.text, PasswordText.text))
        {
            new RegistrationRequest().SetUserName(UserNameText.text).SetPassword(PasswordText.text).SetDisplayName("admin").Send((response) => {
                if (response.HasErrors)
                {
                    OnRegisterFailed();
                    return;
                }

                OnRegisterSuccess();
            });
        }
    }


    public void LoginWithGS(string email, string password)
    {
        new AuthenticationRequest().SetUserName(email).SetPassword(password).Send((response) => {
            if (response.HasErrors)
            {
                OnLoginFailed();
                return;
            }
            OnLoginSuccess();
        });
    }


    public void LoginWithFB ()
    {
        // xử lý code đăng nhập facebook
        // nếu đây là user mới thì chuyển scene sang màn hình điền thông tin user và gọi setupUserInfo
        // còn không thì
		FB.LogInWithReadPermissions(new List<string>() {"public_profile", "email", "display_name"}, (result) => { 
			if ((result.Cancelled) || (result.Error != null)) {
				OnLoginFailed();
				return;
			}
				
			new FacebookConnectRequest().SetAccessToken(result.AccessToken.TokenString).Send((response) => {
				if (response.HasErrors) {
				    OnLoginFailed();
                    return;
				}

				OnLoginSuccess();
			});
		});

    }


    public void RecoveryAccount(string email)
    {

        scriptData = new GSRequestData();
        scriptData.AddString(ACTION, PASSWORD_RECOVERY_REQUEST_ACTION);

        new AuthenticationRequest().SetUserName(email).SetPassword("admin").SetScriptData(scriptData).Send((response) => {
            if (response.HasErrors)
            {
                StatusText.text = "Error: " + response.Errors.ToString();
                OnRecoveryAcountFailed();
                return;
            }

            Debug.Log(response.ScriptData.GetString(ERROR));
            OnRecoveryAcountSuccess();
        });
    }

    public void ResetPassword (string email, string token, string newPassword)
    {
        // Add token into scriptData
		scriptData = new GSRequestData();
		scriptData.AddString(ACTION, RESET_PASSWORD_ACTION);
		scriptData.AddString (TOKEN, token);

		new AuthenticationRequest().SetUserName("admin").SetPassword(newPassword).SetScriptData(scriptData).Send((response) => { 
			if (response.HasErrors) {
				OnResetPasswordFailed();
				return;
			}	

			OnResetPasswordSuccess();
		});
	}

	

    public void SetupUserInfo(string phoneNumber, string displayName, string male)
    {
        // gửi lệnh lên gs để setup những dữ liệu đầu tiên
        // nếu setup thành công
        new LogEventRequest().SetEventKey(SET_UP_FIRST_USER)
            .SetEventAttribute(DISPLAY_NAME, displayName)
            .SetEventAttribute(PHONE_NUMBER, phoneNumber)
            .SetEventAttribute(SEX, male).Send((response) => {

                if (response.HasErrors)
                {
                    OnLoginFailed();
                    return;
                }
            });

		OnLoginSuccess ();
    }


	public void ChangePassword (string newPassword, string oldPassword)
	{
		// đăng nhập thành công vào game rồi mới cho đổi
		new ChangeUserDetailsRequest ().SetNewPassword (newPassword).SetOldPassword (oldPassword).Send ((response) => {
			if (response.HasErrors) {
				StatusText.text = "Error: " + response.Errors.ToString();
				OnChangePasswordFailed();
				return;
			} 	
		});
        OnChangePasswordSuccess();
	}

    public void LogOut ()
    {
        GS.Reset();
    }


	// tự tạo thêm mấy phương thức như vầy chứ đừng có code chung ở trên kia luôn
	private void OnLoginSuccess () {
        Debug.Log("Log in Success");
	}

	private void OnLoginFailed () {
        Debug.Log("Log in failed");
    }

    private void OnRegisterFailed () {
        Debug.Log("Regis Failed");
	}

	private void OnRegisterSuccess () {
        Debug.Log("Regis Success");
    }

    private void OnResetPasswordSuccess () {
        Debug.Log("Reset Success");
	}

	private void OnResetPasswordFailed () {
        Debug.Log("Reset Failed");
    }

    private void OnRecoveryAcountSuccess () {
        Debug.Log("Recovery Success");
    }

    private void OnRecoveryAcountFailed () {
        Debug.Log("Recovery Failed");
    }

    private void OnChangePasswordSuccess () {
        Debug.Log("Change Password Success");
    }

    private void OnChangePasswordFailed () {
        Debug.Log("Change Password Failed");
    }





    protected bool CheckInputInfo (string userName, string password)
	{
		// Check if the userName is Null
		if ((userName.Equals("")) || (userName.Equals(null)) || !(userName.Contains("@"))) {
			StatusText.text = "Email not specified";
			return false;
		}

		// Check if the password is Null
		if ((password.Equals("")) || (password.Equals(null)))
		{
			StatusText.text = "Password not specified";
			return false;
		}

		// Check if the id containt special character ( ^, &, *, ...);
		char[] arrayID = userName.ToCharArray();
		for (int i = 0; i < arrayID.Length; i ++)
		{
			byte c = ((byte)arrayID[i]);
			if ((InRange(c, 30, 45)) || (InRange(c, 58, 63) || InRange(c, 91, 96)) || InRange(c, 123, 126) || c == 47)
			{
				StatusText.text = "ID must not contain any special character (" + arrayID[i] + ")";
				return false;
			}
		}

		// Check if password length is less than 6
		if (password.Length < 6)
		{
			StatusText.text = "Password length must be longer than 6";
			return false;
		}

		return true;
	}


	protected bool InRange (byte number, byte min, byte max)
	{
		if ((number >= min) && (number <= max)) return true ;

		return false;
	}

		
	}





