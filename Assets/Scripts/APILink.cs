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
    

    APILink apiLink;

    void Start()
    {
        apiLink = GetComponent<APILink>();
        StartCoroutine(apiLink.GetDataFromClient(HandleAPIData));
    }

    [System.Serializable]
    public class ClientData
    {
        public int id;
        public string label;
        public bool isManager;
    }

    [System.Serializable]
    public class ClientDataWrapper
    {
        public List<ClientData> clients;
        public Dictionary<string, ClientDetails> data;
    }

    [System.Serializable]
    public class ClientDetails
    {
        public string name;
        public int points;
        public string address;
    }
       public void HandleAPIData(string jsonData)
    {
        ClientDataWrapper clientDataWrapper = JsonUtility.FromJson<ClientDataWrapper>(jsonData);

        foreach (ClientData clientData in clientDataWrapper.clients)
        {
            // Update UI elements with client data
            // nameLabel.text = clientData.label;
            // pointsLabel.text = clientDataWrapper.data[clientData.id.ToString()].points.ToString();
            // addressLabel.text = clientDataWrapper.data[clientData.id.ToString()].address;
        }
    }
}
