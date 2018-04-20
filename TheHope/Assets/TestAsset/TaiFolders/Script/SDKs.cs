
namespace Facebook.Unity
{
    using GameSparks.Api.Requests;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;
    using GameSparks.Api.Responses;

    public class SDKs : MonoBehaviour
    {
        public Text errText, nameText;

        void Start()
        {
            FB.Init();
        }

        public void Login ()
        {
            FB.LogInWithReadPermissions(new List<string> { "public_profile", "email", "user_friends" }, (result) => {
                    if (!string.IsNullOrEmpty(result.Error))
                    {
                        errText.text = "Err: " + result.Error.ToString();
                        return;    
                    }
                    else if (result.Cancelled)
                    {
                        errText.text = "Err: " + result.Error.ToString();
                        return;
                    }
                errText.text = "Success 1";
                nameText.text = "n: " + result.RawResult;
                GameSparkLogin(result.AccessToken.ToString());
            });
        }

        public void GameSparkLogin (string accessToken)
        {
            new FacebookConnectRequest().SetAccessToken(accessToken).Send((response) =>
            {
                nameText.text = "FUCK U";
            });

            new RegistrationRequest().SetDisplayName("adminstrator").SetPassword("admin").SetUserName("admins").Send((response) =>
            {
                if (response.HasErrors)
                {
                    errText.text = "Res : " + response.Errors.ToString();
                }
                errText.text = "Success 3";
                Debug.Log("ĐỤ MÁ");
            });
            Debug.Log("ĐỤ MÁ m");

        }

    }
}
