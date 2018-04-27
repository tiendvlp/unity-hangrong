using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

public class GSsda : MonoBehaviour {

	// Use this for initialization
	void Start () {
        new FacebookConnectRequest().SetAccessToken("EAAIQLEaWpE0BAP0ZAIVdjf9pJZB73CVjhaI0Ow3LWMz2CDrBSl8UpyPU1JLNN9PSeJbsZBvfCch18bZBSRzUacGaiibNtEYZBIGyHItrFnqqJL4Y9hTY0mWbbMJdAZBUK5NAybDWrM65LjevOr3ckSRwEAz8ipqE1aqA7cYlLPBcxj3VerOf2hiyk1JbLxf0ZAWZAJjJNSkoimvDjPCZClpO0hWtNvugxYaEQgMSZCT6ZB8vC2ezXardFeF").Send((res) =>
        {
            Debug.Log("OH GOD");
        });

        Debug.Log("WTF ?");
	}
	
	
}
