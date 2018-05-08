using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;

public class GetData {
    private LogEventRequest callEvent;
    public delegate void getDataFromGameSparksComplete (Result result);
    public event getDataFromGameSparksComplete onGetDataFromGameSparkComplete;

    public GetData() {
        callEvent = new LogEventRequest();
        callEvent.SetEventKey("GetData");
    }

    public void getData(string dataType, string id, string path) {
        callEvent.SetEventAttribute("ID", id);
        callEvent.SetEventAttribute("Path", path);
        callEvent.SetEventAttribute("DataType", dataType);
        callEvent.Send(callback => {
            Result result = new Result();
            result.Errors = callback.Errors;
            result.hasErrors = callback.HasErrors;
            result.jsonData = JSONObject.Create(callback.JSONString);
            result.dataType = dataType;
            result.path = path;
            result.id = id;
            if (onGetDataFromGameSparkComplete != null)
            {
                onGetDataFromGameSparkComplete(result);
            }
        });
    }

    public class Result {
        public string path;
        public string id;
        public string dataType;
        public JSONObject jsonData;
        public bool hasErrors;
        public GSData Errors;
    }

}
