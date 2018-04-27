
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

                nameText.text = "n: " + result.ResultDictionary;
                GameSparkLogin(result.AccessToken.TokenString);
            });
        }

        public void GameSparkLogin (string accessToken)
        {
            new FacebookConnectRequest().SetAccessToken("EAAIQLEaWpE0BAOC3X3ySKJhghrcIHSUFK8LG7dZA7QIjcDtFj2MjNxAgoyi1cdjNyKFkVqP7ZAP7b2ZAbBUZBi6imAhApTYypiF90pva5dTGYLyZCYUH9ZA3o8FGWtFb1cW4cJtALcjOfRtqXDPPQLh37hP2toKCC5KG09eNZBQ4VWbQRzsgZAhpxdPWjDnEZAVJ2ZAy5pCINumjCmZBGeiZC7m3FoDdbUa6NBPNSy0OoGrzX51BRdAQmmbi")
                .SetCode("")
                .SetDoNotLinkToCurrentPlayer(false)
                .SetErrorOnSwitch(false)
                .SetSwitchIfPossible(false).SetSyncDisplayName(false)
                .Send((response) =>
            {
                if (response.HasErrors)
                {
                    if (response.Errors.ToString().Equals("GameSparks.Core.GSData"))
                    Debug.Log(response.HasErrors + " " + response.Errors.ToString());
                    return;
                }
                errText.text = "Success";
                nameText.text = "Name: " + response.DisplayName ;
            });
        }

        public void LogOut ()
        {
            FB.LogOut();
        }

    }
}
