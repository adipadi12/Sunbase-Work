using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class APILink : MonoBehaviour
{
    private const string url = "https://qa.sunbasedata.com/sunbase/portal/api/assignment.jsp?cmd=client_data";

    public IEnumerator GetDataFromClient(System.Action<string> callback)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("API request failed: " + webRequest.error);
            }
            else
            {
                string jsonData = webRequest.downloadHandler.text;

                callback(jsonData);
            }
        }
    }
}
